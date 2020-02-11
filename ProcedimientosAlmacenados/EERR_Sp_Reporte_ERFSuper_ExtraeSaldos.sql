SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( '[EERR_Sp_Reporte_ERFSuper_ExtraeSaldos]', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Reporte_ERFSuper_ExtraeSaldos;
GO

CREATE PROCEDURE EERR_Sp_Reporte_ERFSuper_ExtraeSaldos
	  @iIdConsolidado as int
	, @sPeriodo as varchar(6)
	, @sLibros as Varchar(100)
	, @sDeep as varchar(30)
	, @CursorSaldos CURSOR VARYING OUTPUT
AS
--
Declare @sName AS Varchar(100);
Declare @sTexto as nVarchar(500);
--
Declare @TablaLibros Table ( Libro varchar(20) ); -- Tabla para transformar en registro los libros enviados por parameto
--
BEGIN
	SET NOCOUNT ON;
	--
	Set @sName = 'EERR_Sp_Reporte_ERFSuper_ExtraeSaldos'; 
	--
	Set @sTexto = @sDeep + ' Parametros Entrada';
	Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar, @iIdConsolidado) + '}' ;
	Set @sTexto = @sTexto + ' Periodo {' + @sPeriodo + '}' ;
	Set @sTexto = @sTexto + ' Libros {' + @sLibros + '}' ;
	Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;

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
		Set @sTexto = @sDeep + '__ Inicio Insercion de Saldos';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		Set @CursorSaldos = CURSOR  FORWARD_ONLY STATIC FOR 
			Select
				C.IdRegistro
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
				, 'sa'
			From EERR_Tbl_Consolidados C
				, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
				, EERR_Tbl_Maestro_Grupos MG
				, EERR_Tbl_Maestro_Conceptos MCO
				, EERR_Tbl_Maestro_Cuentas MCU
				, EERR_Tbl_Saldos_Contables SC
				, EERR_Tbl_Companias CO
			Where 1=1
				AND C.IdRegistro = @iIdConsolidado
				AND CO.IdCompania in ( SELECT codigo FROM EERR_Tbl_Consolidados where idPadre = @iIdConsolidado and TipoNodo = 2  )
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
		Open @CursorSaldos;  		
		Set @sTexto = @sDeep + '__ Fin Insercion de Saldos';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		
		--
		Return (0);
	End Try
	Begin Catch
		--
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_NUMBER()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;
		--
		Return (1);
	End Catch
END;