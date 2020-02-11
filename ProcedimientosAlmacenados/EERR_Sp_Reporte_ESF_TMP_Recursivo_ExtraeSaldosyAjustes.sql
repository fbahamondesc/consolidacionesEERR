use CONSOLIDADO_EERR_DESARROLLO
--use CONSOLIDADO_EERR_PRODUCCION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( '[EERR_Sp_Reporte_ESF_TMP_Recursivo_ExtraeSaldosyAjustes]', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Reporte_ESF_TMP_Recursivo_ExtraeSaldosyAjustes;
GO

CREATE PROCEDURE EERR_Sp_Reporte_ESF_TMP_Recursivo_ExtraeSaldosyAjustes
	  @sToken as varchar(24)
	, @iIdConsolidado as int
	, @sPeriodo as varchar(6)
	, @sLibros as Varchar(100)
	, @sDeep as varchar(30)
	, @iNivel as int
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
Declare @iNivelM as int;
Declare @iPadre as int;
Declare @iHijo as int;
Declare @iCuenta as int;
-- Cursores
Declare @curAnidados as Cursor;
Declare @curSumatoria as Cursor;
-- Variables para insertar
Declare @sTokenX as varchar(24)
Declare @iIdConsolidadoX as int 
Declare @sDescripcionConsolidadoX as varchar(500)
Declare @sIdCompaniaX as varchar(18)
Declare @sDescripcionCompaniaX as varchar(500)
Declare @sIdGrupoX as varchar(4)
Declare @sDescripcionGrupoX as varchar(500)
Declare @sIdConceptoX as varchar(10)
Declare @sDescripcionConceptoX as varchar(500)
Declare @sIdCuentaX as varchar(8)
Declare @sDescripcionCuentaX as varchar(500)
Declare @sIdPeriodoX as varchar(6)
Declare @nValorX numeric(25, 0)
Declare @iFlagImprimeX as int 
Declare @sTipoX varchar(2)
Declare @iFlagPatrimonioX varchar(2)
Declare @sDescripcionFlagX varchar(10)
--
Declare @TablaLibros Table ( Libro varchar(20) ); -- Tabla para transformar en registro los libros enviados por parameto
Declare @TablaPaso Table ( 
								  Token varchar(24)
								, IdConsolidado int
								, DescripcionConsolidado varchar(500)
								, IdCompania varchar(18)
								, DescripcionCompania varchar(500)
								, IdGrupo varchar(4)
								, DescripcionGrupo varchar(500)
								, IdConcepto varchar(10)
								, DescripcionConcepto varchar(500)
								, IdCuenta varchar(8)
								, DescripcionCuenta varchar(500)
								, IdPeriodo varchar(6)
								, Valor numeric(25, 0)
								, FlagImprime int
								, FlagPatrimonio varchar(2)
								, DescripcionFlag varchar(10)
								, Tipo varchar(2)
							 );
BEGIN
	SET NOCOUNT ON;
	--
	Set @sName = 'EERR_Sp_Reporte_ESF_TMP_Recursivo_ExtraeSaldosyAjustes';
	Set @sDeepP = @sDeep +'__';
	--
	Set @sTexto = @sDeep + ' Parametros Entrada';
	Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar, @iIdConsolidado) + '}' ;
	Set @sTexto = @sTexto + ' Periodo {' + @sPeriodo + '}' ;
	Set @sTexto = @sTexto + ' Libros {' + @sLibros + '}' ;
	Set @sTexto = @sTexto + ' Nivel {' + convert( varchar, @iNivel) + '}' ;	
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
--print @sTexto
	Begin Try
		Set @sTexto = @sDeep + '__ Inicio Recursivo';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
--print @sTexto
		--
			Set @iHijo = @iIdConsolidado;
			Set @iPadre = ( Select IdConsolidadoPadre From EERR_TMP_TOKEN_ESF_TMP_NIVEL Where Token = @sToken And IdNivel = @iNivel And IdConsolidado = @iIdConsolidado  )
--print @sDeepP+' padre:'+convert(varchar,@iPadre)
--print @sDeepP+' hijo:'+convert(varchar,@iHijo)
			Set @curAnidados = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
				Select CodigoReferenciado, Codigo, TipoNodo, idRegistro From EERR_Tbl_Consolidados Where idPadre = @iIdConsolidado order by TipoNodo;
			Open @curAnidados;
			Fetch Next From @curAnidados Into @iIdAnidado, @sCodigo, @iTipoNodo, @iIdRegistroOrg
			While @@FETCH_STATUS = 0
				Begin
					Set @sTexto = @sDeep + '____ idRegistro {' + convert(varchar, @iIdAnidado) +'}';
					Set @sTexto = @sTexto + ' sCodigo {' + convert(varchar,@sCodigo) + '}'
					Set @sTexto = @sTexto + ' TipoNodo {' + Convert( varchar, @iTipoNodo) + '}';
					Set @sTexto = @sTexto + ' IdRegistroOrg {' + Convert( varchar, @iIdRegistroOrg) + '}';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
--print @sTexto
					--
					--
					If @iTipoNodo = 1
						Begin
							-- prevalidacion de envio de anidado
							Set @iIdAnidado = case when @iIdAnidado = 0 then @iIdRegistroOrg else @iIdAnidado end;
							Set @iNivelM = @iNivel + 1;
							-- insertamos auxiliar de navegacion
								Insert into EERR_TMP_TOKEN_ESF_TMP_NIVEL Values( @sToken, @iNivelM, @iIdAnidado, @iIdConsolidado);
							--							
							Execute @iRetVal = EERR_Sp_Reporte_ESF_TMP_Recursivo_ExtraeSaldosyAjustes @sToken, @iIdAnidado, @sPeriodo, @sLibros, @sDeepP, @iNivelM;
							If @iRetVal = 1 
								Begin
									Set @sTexto = @sDeep + '____ Devolvio Error';
									Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
									Return @iRetVal;
								End;
							Set @sTexto = @sDeep + '____ Inserta Registros de ajustes del consolidado';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Insert into @TablaPaso
								Select
									  @sToken
									, @iPadre
									, 'x'
									, @iHijo
									, 'x'
									, CG.idGrupo
									, 'x'
									, CG.IdConcepto
									, 'x'
									, CG.IdCuenta
									, 'x'
									, @sPeriodo
									, Case 
										When MCU.Tipo = '2L' and  MCO.Tipo = 1 Then (AJ.Credito - AJ.Debito) 
										When MCU.Tipo = '1A' And MCO.Tipo = 0 Then (AJ.Debito - AJ.Credito ) 
										Else (AJ.Credito - AJ.Debito)
									End	Valor
									, MCU.FlagImprime
									, Case when MCO.Tipo = 0 Then 'AC'
										Else
											Case When MCU.FlagPatrimonio = 1 Then 'PR'
												Else 'PA'
											End
										End FlagPatrimonio
									, Case when MCO.Tipo = 0 Then 'Activos'
										Else
											Case When MCU.FlagPatrimonio = 1 Then 'Patrimonio'
												Else 'Pasivos'
											End
										End DescripcionFlag
									, 'AR'
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
									AND MCO.Tipo in (0,1)
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
							Insert into @TablaPaso
								Select
									  @sToken
									, @iPadre -- C.IdRegistro
									, 'y'
									, @iHijo -- SC.IdCompania 
									, 'y' -- SC.IdCompania + '-' + CO.Nombre
									, CG.idGrupo
									, 'y' -- MG.Descripcion MGDescripcion
									, CG.IdConcepto --Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
									, 'y' -- MCO.Descripcion MCODescripcion
									, CG.IdCuenta
									, 'y' -- CG.IdCuenta + '-' + MCU.Descripcion MCUDescripcion
									, SC.Periodo
									, Case 
										When MCU.Tipo = '2L' and  MCO.Tipo = 1 Then (SC.Credito - SC.Debito) 
										When MCU.Tipo = '1A' And MCO.Tipo = 0 Then (SC.Debito - SC.Credito ) 
										Else (SC.Credito - SC.Debito)
									End	Valor
									, MCU.FlagImprime
									, Case when MCO.Tipo = 0 Then 'AC'
										Else
											Case When MCU.FlagPatrimonio = 1 Then 'PR'
												Else 'PA'
											End
										End FlagPatrimonio
									, Case when MCO.Tipo = 0 Then 'Activos'
										Else
											Case When MCU.FlagPatrimonio = 1 Then 'Patrimonio'
												Else 'Pasivos'
											End
										End DescripcionFlag
									, 'SR'
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
									AND MCO.Tipo in (0,1)
									And CG.IdConsolidado = C.IdRegistro
									And CG.IdGrupo = MG.Codigo
									And CG.IdConcepto = MCO.Codigo
									And CG.IdCuenta = MCU.IdCuenta
									And SC.IdCompania = CO.IdCompania
									And SC.IdCuenta = MCU.IdCuenta
									
--print @sDeepP+' @iIdConsolidado:'+convert(varchar,@iIdConsolidado)+' @sCodigo:'+convert(varchar,@sCodigo)+' @sPeriodo:'+convert(varchar,@sPeriodo)
						End;
					--
--print @sTexto + ' Padre:'+convert(varchar,@iPadre)+' Hijo:'+convert(varchar,@iHijo)
					Fetch Next From @curAnidados Into @iIdAnidado, @sCodigo, @iTipoNodo, @iIdRegistroOrg
				End;

			Close @curAnidados;
			Deallocate @curAnidados;
		Set @sTexto = @sDeep + '__ Fin Recursivo';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		-- Ciclo para sumas los regitros por cuenta
		Set @sTexto = @sDeep + '__ Ciclo para sumas los regitros por cuenta';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
--print @sTexto
		Set @curSumatoria = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
			Select Token, IdConsolidado, DescripcionConsolidado, IdCompania, DescripcionCompania
				, IdGrupo, DescripcionGrupo, IdConcepto, DescripcionConcepto, IdCuenta
				, DescripcionCuenta, IdPeriodo, Valor, FlagImprime, FlagPatrimonio, DescripcionFlag, Tipo
			From @TablaPaso
		Open @curSumatoria;
		Fetch Next From @curSumatoria Into 
				  @sTokenX, @iIdConsolidadoX, @sDescripcionConsolidadoX, @sIdCompaniaX
				, @sDescripcionCompaniaX, @sIdGrupoX, @sDescripcionGrupoX, @sIdConceptoX
				, @sDescripcionConceptoX, @sIdCuentaX, @sDescripcionCuentaX, @sIdPeriodoX
				, @nValorX, @iFlagImprimeX, @iFlagPatrimonioX, @sDescripcionFlagX, @sTipoX
		While @@FETCH_STATUS = 0
			Begin
				Set @iCuenta = (
								Select Count(0)
								From EERR_TMP_TOKEN_ESF_TMP
								Where 1 = 1
									And Token = @sTokenX
									And idConsolidado = @iIdConsolidadoX
									And idCompania = @sIdCompaniaX
									And idGrupo = @sIdGrupoX
									And idConcepto = @sIdConceptoX
									And idCuenta = @sIdcuentaX
								)
				If @iCuenta = 0
					Begin
						Insert into EERR_TMP_TOKEN_ESF_TMP Values
						(
							  @sTokenX
							, @iIdConsolidadoX
							, @sDescripcionConsolidadoX
							, @sIdCompaniaX
							, @sDescripcionCompaniaX
							, @sIdGrupoX
							, @sDescripcionGrupoX
							, @sIdConceptoX
							, @sDescripcionConceptoX
							, @sIdCuentaX
							, @sDescripcionCuentaX
							, @sIdPeriodoX
							, @nValorX
							, @iFlagImprimeX
							, @iFlagPatrimonioX
							, @sDescripcionFlagX
							, @sTipoX	, 0, '', '', ''
						)
					End;
				Else
					Begin
						Update EERR_TMP_TOKEN_ESF_TMP Set
							Valor = Valor + @nValorX
						Where 1 = 1
							And Token = @sTokenX
							And idConsolidado = @iIdConsolidadoX
							And idCompania = @sIdCompaniaX
							And idGrupo = @sIdGrupoX
							And idConcepto = @sIdConceptoX
							And idCuenta = @sIdcuentaX
					End;
				--
				Fetch Next From @curSumatoria Into 
						  @sTokenX, @iIdConsolidadoX, @sDescripcionConsolidadoX, @sIdCompaniaX
						, @sDescripcionCompaniaX, @sIdGrupoX, @sDescripcionGrupoX, @sIdConceptoX
						, @sDescripcionConceptoX, @sIdCuentaX, @sDescripcionCuentaX, @sIdPeriodoX
						, @nValorX, @iFlagImprimeX, @iFlagPatrimonioX, @sDescripcionFlagX, @sTipoX
			End;
		Close @curSumatoria; 
		Deallocate @curSumatoria;
--print 'Salio'
		--
		Return (0);
	End Try
	Begin Catch
		--
		Declare @sErr as Varchar(2000);
		set @sErr = ' Num : {' + Convert(varchar, ERROR_LINE()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
--print @sName + @sErr
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;
		--
		Return (1);
	End Catch
END;
