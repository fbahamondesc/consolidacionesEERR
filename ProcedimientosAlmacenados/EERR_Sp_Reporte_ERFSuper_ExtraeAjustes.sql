SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( '[EERR_Sp_Reporte_ERFSuper_ExtraeAjustes]', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Reporte_ERFSuper_ExtraeAjustes;
GO

CREATE PROCEDURE EERR_Sp_Reporte_ERFSuper_ExtraeAjustes
	  @iIdConsolidado as int
	, @sPeriodo as varchar(6)
	, @sDeep as varchar(30)
	, @CursorAjustes CURSOR VARYING OUTPUT
AS

Declare @sName AS Varchar(100);
Declare @sTexto as nVarchar(500);

BEGIN
	SET NOCOUNT ON;
	--
	Set @sName = 'EERR_Sp_Reporte_ERFSuper_ExtraeAjustes'; 
	--
	Set @sTexto = @sDeep + ' Parametros Entrada';
	Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar, @iIdConsolidado) + '}' ;
	Set @sTexto = @sTexto + ' Periodo {' + @sPeriodo + '}' ;
	Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;

	Begin Try
		Set @sTexto = @sDeep + '__ Inicio Insercion de Ajustes';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;

		Set @CursorAjustes = CURSOR  FORWARD_ONLY STATIC FOR 
			Select
				C.IdRegistro
				, C.Codigo +'-'+ C.Descripcion
				, '0' 
				, 'Ajustes'
				, MG.Tipo +  CG.IdGrupo
				, MG.Descripcion MGDescripcion
				, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
				, MCO.Descripcion MCODescripcion
				, CG.IdCuenta
				, rtrim(CG.IdCuenta) + '-' +MCU.Descripcion MCUDescripcion
				, AJ.PeriodoVista
				, Case When  CG.IdCuenta = 'ERF_NC' THEN (AJ.Debito - AJ.Credito)
					Else (AJ.Credito - AJ.Debito) 
					End Valor
				, MCU.FlagImprime
				, 'aj'
			From EERR_Tbl_Consolidados C
				, EERR_Tbl_Ajustes AJ
				, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
				, EERR_Tbl_Maestro_Grupos MG
				, EERR_Tbl_Maestro_Conceptos MCO
				, EERR_Tbl_Maestro_Cuentas MCU
			Where 1=1
				--
				And C.IdRegistro = @iIdConsolidado
				AND AJ.IdConsolidado = C.IdRegistro
				AND AJ.PeriodoVista = @sPeriodo
				AND MCU.Tipo in ( '3I', '3E' )
				And CG.IdCuenta = AJ.IdCuenta
				--
				And CG.IdConsolidado = C.IdRegistro
				And CG.IdGrupo = MG.Codigo
				And CG.IdConcepto = MCO.Codigo
				And CG.IdCuenta = MCU.IdCuenta
		Open @CursorAjustes;  		
		Set @sTexto = @sDeep + '__ Fin Insercion de Ajustes';
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
