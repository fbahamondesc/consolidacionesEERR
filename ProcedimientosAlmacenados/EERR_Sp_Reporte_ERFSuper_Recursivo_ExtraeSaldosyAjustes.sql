SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( '[EERR_Sp_Reporte_ERFSuper_Recursivo_ExtraeSaldosyAjustes]', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Reporte_ERFSuper_Recursivo_ExtraeSaldosyAjustes;
GO

CREATE PROCEDURE EERR_Sp_Reporte_ERFSuper_Recursivo_ExtraeSaldosyAjustes
	  @sToken as varchar(24)
	, @iIdConsolidado as int
	, @sPeriodo as varchar(6)
	, @sLibros as Varchar(100)
	, @sDeep as varchar(30)
AS

Declare @iretVal as int;
Declare @sName AS Varchar(100);
Declare @sTexto as nVarchar(500);
Declare @sDeepP as varchar(30);
--
Declare @iIdAnidado as int;
Declare @sCodigo as varchar(18);
Declare @iTipoNodo as int;
Declare @iIdRegistroOrg as int;
-- Cursores
Declare @curAnidados as Cursor;
--
Declare @TablaLibros Table ( Libro varchar(20) ); -- Tabla para transformar en registro los libros enviados por parameto

BEGIN
	SET NOCOUNT ON;
	--
	Set @sName = 'EERR_Sp_Reporte_ERFSuper_Recursivo_ExtraeSaldosyAjustes';
	Set @sDeepP = @sDeep +'__';
	--
	Set @sTexto = @sDeep + ' Parametros Entrada';
	Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar, @iIdConsolidado) + '}' ;
	Set @sTexto = @sTexto + ' Periodo {' + @sPeriodo + '}' ;
	Set @sTexto = @sTexto + ' Libros {' + @sLibros + '}' ;
	Execute EERR_sp_Log4Sql_info @sName, @sTexto;

	-- Transforma los libros en una tabla
	WITH Separa(pn, start, stop) AS (
		SELECT 1, 1, CASE WHEN CHARINDEX(',', @sLibros)>0 THEN CHARINDEX(',', @sLibros) ELSE LEN(@sLibros)+1 END
		UNION ALL
		SELECT pn + 1, stop + 1, CASE WHEN CHARINDEX(',', @sLibros, stop + 1)> 0 THEN CHARINDEX(',', @sLibros, stop + 1) ELSE LEN(@sLibros)+1 END
		FROM Separa
		WHERE stop > 0 AND stop<LEN(@sLibros)-1
	)
	Insert Into @TablaLibros
		SELECT SUBSTRING(@sLibros, start, stop - start) Libro
		FROM Separa
	--
	Begin Try
		Set @sTexto = @sDeep + '__ Inicio Recursivo';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
			Set @curAnidados = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
				Select CodigoReferenciado, Codigo, TipoNodo, idregistro From EERR_Tbl_Consolidados Where idPadre = @iIdConsolidado order by TipoNodo;
			Open @curAnidados;
			Fetch Next From @curAnidados Into @iIdAnidado, @sCodigo, @iTipoNodo, @iIdRegistroOrg
			While @@FETCH_STATUS = 0
				Begin
					Set @sTexto = @sDeep + '____ idRegistro {' + CONVERT(varchar, @iIdAnidado ) +'}';
					Set @sTexto = @sTexto + ' sCodigo {' + @sCodigo + '} TipoNodo {' + Convert( varchar(1), @iTipoNodo) + '}';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;

					--
					If @iTipoNodo = 1
						Begin
							Set @iIdAnidado = case when @iIdAnidado = 0 then @iIdRegistroOrg else @iIdAnidado end;

							Execute @iRetVal = EERR_Sp_Reporte_ERFSuper_Recursivo_ExtraeSaldosyAjustes @sToken, @iIdAnidado, @sPeriodo, @sLibros, @sDeepP;
							If @iRetVal = 1 
								Begin
									Set @sTexto = @sDeep + '____ Devolvio Error';
									Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
									Return @iRetVal;
								End;
							Set @sTexto = @sDeep + '____ Inserta Registros de ajustes del consolidado';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Insert into EERR_Tmp_Token_ERF
								Select
									 @sToken
									, C.IdRegistro
									, C.Codigo +'-'+ C.Descripcion
									, @sCodigo 
									, 'Ajustes'
									, MG.Tipo +  CG.IdGrupo
									, MG.Descripcion MGDescripcion
									, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
									, MCO.Descripcion MCODescripcion
									, CG.IdCuenta
									, rtrim(CG.IdCuenta) + '-' +MCU.Descripcion MCUDescripcion
									, @sPeriodo
									, Case When  CG.IdCuenta = 'ERF_NC' THEN (AJ.Debito - AJ.Credito)
										Else (AJ.Credito - AJ.Debito) 
										End Valor
									, MCU.FlagImprime
									, 'aa'
								From EERR_Tbl_Consolidados C
									, EERR_Tbl_Ajustes AJ
									, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
									, EERR_Tbl_Maestro_Grupos MG
									, EERR_Tbl_Maestro_Conceptos MCO
									, EERR_Tbl_Maestro_Cuentas MCU
								Where 1=1
									--
									And C.IdRegistro = @iIdAnidado
									AND AJ.IdConsolidado = C.IdRegistro
									AND AJ.PeriodoAfectado = @sPeriodo
									AND AJ.PeriodoVista = @sPeriodo
									AND MCU.Tipo in ( '3I', '3E' )
									And CG.IdCuenta = AJ.IdCuenta
									--
									And CG.IdConsolidado = C.IdRegistro
									And CG.IdGrupo = MG.Codigo
									And CG.IdConcepto = MCO.Codigo
									And CG.IdCuenta = MCU.IdCuenta
						End;
					Else
						Begin
							Set @sTexto = @sDeep + '____ Inserta Registros de saldos de la empresa';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Insert into EERR_Tmp_Token_ERF
								Select
									  @sToken
									, C.IdRegistro
									, C.Codigo + '-' + C.Descripcion
									, SC.IdCompania 
									, SC.IdCompania + '-' + CO.Nombre
									, MG.Tipo + CG.idGrupo
									, MG.Descripcion MGDescripcion
									, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
									, MCO.Descripcion MCODescripcion
									, CG.IdCuenta
									, rtrim(CG.IdCuenta) + '-' + MCU.Descripcion MCUDescripcion
									, SC.Periodo
									, Case When  CG.IdCuenta = 'ERF_NC' then (SC.Debito - SC.Credito)
										Else (SC.Credito - SC.Debito) 
										End Valor
									, MCU.FlagImprime
									, 'aa'
								From EERR_Tbl_Consolidados C
									, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
									, EERR_Tbl_Maestro_Grupos MG
									, EERR_Tbl_Maestro_Conceptos MCO
									, EERR_Tbl_Maestro_Cuentas MCU
									, EERR_Tbl_Saldos_Contables SC
									, EERR_Tbl_Companias CO
								Where 1=1
									AND C.IdRegistro = @iIdConsolidado
									AND CO.IdCompania = @sCodigo
									AND SC.Periodo = @sPeriodo
									AND SC.Libro in ( Select Libro from @TablaLibros )
									AND MCU.Tipo in ( '3I', '3E' )
									--
									And CG.IdConsolidado = C.IdRegistro
									And CG.IdGrupo = MG.Codigo
									And CG.IdConcepto = MCO.Codigo
									And CG.IdCuenta = MCU.IdCuenta
									And SC.IdCompania = CO.IdCompania
									And SC.IdCuenta = MCU.IdCuenta	
						End;
					--
					Fetch Next From @curAnidados Into @iIdAnidado, @sCodigo, @iTipoNodo, @iIdRegistroOrg
				End;

			Close @curAnidados;
			Deallocate @curAnidados;
		Set @sTexto = @sDeep + '__ Fin Recursivo';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		Return (0);
	End Try
	Begin Catch
		--
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_LINE()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;
		--
		Return (1);
	End Catch
END;
