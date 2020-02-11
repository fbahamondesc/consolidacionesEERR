--use CONSOLIDADO_EERR_PRODUCCION;
use CONSOLIDADO_EERR_DESARROLLO;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Ajustes_Automaticos_Diferencia_Positiva', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Ajustes_Automaticos_Diferencia_Positiva;
GO

CREATE PROCEDURE EERR_Sp_Ajustes_Automaticos_Diferencia_Positiva
	  @iIdConsolidado as int
	, @sPeriodoAfecta as varchar(6)
	, @iAsiento as int
	, @iDiferencia as Numeric(20)
	, @nPorcentajeParticipacion as Numeric(35,15)
	, @iTipo as int
	, @sCuentaOrigen as varchar(8)
	, @sCuentaAjuste  as varchar(8)
	, @sCuentaDestino  as varchar(8)
	, @sCuentaDestinoNC  as varchar(8)
	, @sContraCuenta  as varchar(8)
	, @sGlosa  as varchar(350)
AS
--
Declare @iRetVal as int;
Declare @sName AS varchar(100);
Declare @sTexto as nvarchar(4000);
Declare @sError as varchar(100);
-- Variables 
Declare @nResultado as numeric( 35, 15);
Declare @nResultadoRedondeo as numeric(20);
Declare @nResto as Numeric(20);
Declare @nCuadra as Numeric(20);

BEGIN
	Set @sName = 'EERR_Sp_Ajustes_Automaticos_Diferencia_Positiva'; 

	Begin Try

		Set @nResultado = (@iDiferencia * @nPorcentajeParticipacion)/100;
		Set @nResultadoRedondeo = Round(@nResultado, 0); 
		Set @nResto = @iDiferencia - @nResultadoRedondeo;
		Set @nCuadra = @nResultado - @nResto;
		Set @iRetVal = 0;
		Set @sError = '** Sub proceso devolvio error';
		--
		Set @sTexto ='__________ Evaluacion de cuenta ';
		Set @sTexto = @sTexto + ' {' + @sCuentaAjuste +'}';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		If @sCuentaOrigen = 0
			Begin
				-- Insertar Ajuste ContraCuenta
				--Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Inserta_Linea
				--	@iIdConsolidado, @iAsiento, @sContraCuenta, @sPeriodoAfecta, @sPeriodoAfecta, @iTipo, 0, @iDiferencia, @sGlosa;
				Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Inserta_Linea
					@iIdConsolidado, @iAsiento, @sContraCuenta, @sPeriodoAfecta, @sPeriodoAfecta, @iTipo, 0, @nCuadra, @sGlosa;
			End;
		Else
			Begin
				-- Insertar Ajuste Cuenta Destino
				Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Inserta_Linea
					@iIdConsolidado, @iAsiento, @sCuentaAjuste, @sPeriodoAfecta, @sPeriodoAfecta, @iTipo, @iDiferencia, 0, @sGlosa;
			End;
		If @iRetVal = 1
			Begin
				Execute EERR_sp_Log4Sql_Debug @sName, @sError;
				Return @iRetVal;
			End;
		--
		--
		If @nResultadoRedondeo <> 0
			Begin
				If @sCuentaOrigen = 0
					Begin
						-- Insertar Ajuste Cuenta destino Debito	
						Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Inserta_Linea
							@iIdConsolidado, @iAsiento, @sCuentaDestino, @sPeriodoAfecta, @sPeriodoAfecta, @iTipo, @nResultadoRedondeo, 0, @sGlosa;
					End;
				Else
					Begin
						-- Insertar Ajuste Cuenta destino Credito
						Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Inserta_Linea
							@iIdConsolidado, @iAsiento, @sCuentaDestino, @sPeriodoAfecta, @sPeriodoAfecta, @iTipo, 0, @nResultadoRedondeo, @sGlosa;
					End;
			End;
		If @iRetVal = 1
			Begin
				Execute EERR_sp_Log4Sql_Debug @sName, @sError;
				Return @iRetVal;
			End;
		--
		--
		If @nResto <> 0
			Begin
				If @sCuentaOrigen = 0
					Begin
						-- Insertar Ajuste NoControladora Debito
						Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Inserta_Linea
							@iIdConsolidado, @iAsiento, @sCuentaDestinoNC, @sPeriodoAfecta, @sPeriodoAfecta, @iTipo, 0, @nResto, @sGlosa;
					End;
				Else
					Begin
						-- Insertar Ajuste NoControladora Credito
						Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Inserta_Linea
							@iIdConsolidado, @iAsiento, @sCuentaDestinoNC, @sPeriodoAfecta, @sPeriodoAfecta, @iTipo, 0, @nResto, @sGlosa;
					End;
			End;
		If @iRetVal = 1
			Begin
				Execute EERR_sp_Log4Sql_Debug @sName, @sError;
				Return @iRetVal;
			End;
		--
		--
		Set @sTexto ='__________ Fin Evaluacion de cuenta ';
		Set @sTexto = @sTexto + ' {' + @sCuentaAjuste +'}';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		Return @iRetVal;
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_NUMBER()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;

		Return (1);
	End Catch
End;
