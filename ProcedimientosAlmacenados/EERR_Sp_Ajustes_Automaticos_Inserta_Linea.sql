SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Ajustes_Automaticos_Inserta_Linea', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Ajustes_Automaticos_Inserta_Linea;
GO

CREATE PROCEDURE EERR_Sp_Ajustes_Automaticos_Inserta_Linea
	  @iIdConsolidado as int
	, @iAsiento as int
	, @sIdCuenta as varchar(8)
	, @sPeriodoAfecta as varchar(8)
	, @sPeriodoVista as varchar(8)
	, @iTipoTransaccion as int
	, @nDebito as numeric(20)
	, @nCredito as numeric(20)
	, @sGlosaAjuste as varchar(350)
AS
--
Declare @sName AS Varchar(100);
Declare @sTexto as nVarchar(4000);

BEGIN
	Set @sName = 'EERR_Sp_Ajustes_Automaticos_Inserta_Linea'; 

	Begin Try
		-- Insertar en la tabla de ajustes -- Cuenta Origen
		Set @sTexto = '____________ Inserta datos ' ;
		Set @sTexto = @sTexto + ' Consolidado {' + Convert(varchar, @iIdConsolidado)+ '}';
		Set @sTexto = @sTexto + ' Correlativo  {'+ Convert(varchar, @iAsiento) + '}';
		Set @sTexto = @sTexto + ' IdCuenta {' + Convert(varchar, @sIdCuenta)+ '}';
		Set @sTexto = @sTexto + ' Periodo {' + Convert(varchar, @sPeriodoAfecta)+ '}';
		Set @sTexto = @sTexto + ' PeriodoV {' + Convert(varchar, @sPeriodoVista)+ '}';
		Set @sTexto = @sTexto + ' TipoTransaccion {' + Convert( varchar, @iTipoTransaccion) + '}';
		Set @sTexto = @sTexto + ' Debito {'+ Convert(varchar, @nDebito) + '}';
		Set @sTexto = @sTexto + ' Credito {'+ Convert(varchar, @nCredito) + '}';
		Set @sTexto = @sTexto + ' Descripcion {' + @sGlosaAjuste + '}';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		Insert Into EERR_Tbl_Ajustes (
			idConsolidado, CorrelativoAsiento, IdCuenta, PeriodoAfectado, PeriodoVista, TipoTransaccion, Debito, Credito, Descripcion )
		Values ( 
			@iIdConsolidado, @iAsiento, @sIdCuenta, @sPeriodoAfecta, @sPeriodoVista, @iTipoTransaccion, @nDebito, @nCredito, @sGlosaAjuste );
		--
		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_NUMBER()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;

		Return (1);
	End Catch
End;
