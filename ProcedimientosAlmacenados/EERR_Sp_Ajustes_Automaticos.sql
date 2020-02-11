use CONSOLIDADO_EERR_DESARROLLO
--use CONSOLIDADO_EERR_PRODUCCION


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Ajustes_Automaticos', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Ajustes_Automaticos;
GO

CREATE PROCEDURE EERR_Sp_Ajustes_Automaticos
	  @iIdConsolidado as int
	, @sPeriodoAfecta as varchar(8)
	, @sLibros as varchar(100)
AS
------- Variables
Declare @iRetVal as int;
Declare @sName as varchar(100);
Declare @sTexto as nVarchar(500);
Declare @sError as nVarchar(30);
--
Declare @iBloqueo as int;
Declare @iAsiento as int;
Declare @iTipoNodo as Int;
Declare @iIndicadorMatriz as Int;
Declare @iIdRegistro as int;
declare @iCodigoReferenciado as int;
Declare @sDescripcion as varchar(350);
Declare @sCodigo as varchar(10);
Declare @sCodigoMatriz as varchar(10);
Declare @iDiferencia as Numeric(20);
Declare @sGlosa as varchar(350);
Declare @iCuantos as int;
Declare @nResultado as numeric(30,15);
Declare @nResultadoRedondeo as Numeric(20);
Declare @nResto as Numeric(20);
Declare @nPorcentajeParticipacion as Numeric(30,15);
Declare @iTipo as int;
Declare @sCuentaOrigen as varchar(8);
Declare @sCuentaAjuste as varchar(8);
Declare @sCuentaDestino as varchar(8);
Declare @sCuentaDestinoNC as varchar(8);
Declare @sContraCuenta as varchar(8);
Declare @sNgCuentaDestino as varchar(8);
Declare @sNgCuentaDestinoNC as varchar(8);
Declare @sNgContraCuenta as varchar(8);
------- Cursores
Declare @curConsolidado as Cursor;
Declare @nSaldos as Cursor;
------- Tabla temporales
Declare @TablaLibros Table ( Libro varchar(20) );
--
Begin
	Set @sName = 'EERR_Sp_Ajustes_Automaticos'; 

	Begin Try
		Execute EERR_sp_Log4Sql_Info @sName, 'Inicio Proceso de Calculo de Ajustes Automaticos';
		--
		Set @sTexto = '__ Parametros Entrada';
		Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar(20), @iIdConsolidado) + '}' ;
		Set @sTexto = @sTexto + ' PeriodoAfecta {' + @sPeriodoAfecta + '}' ;
		Set @sTexto = @sTexto + ' Libros {' + @sLibros + '}' ;
		Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
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
		Execute EERR_sp_Log4Sql_Debug @sName, '__ Revisamos que el consolidado no este bloqueado';
		Select @iBloqueo = Bloqueo  From EERR_Tbl_Consolidados Where 1 = 1 And IdRegistro = @iIdConsolidado
		If ( @iBloqueo = 1 )
			Begin
				Set @sError = '____ Consolidado bloqueado';
				Execute EERR_sp_Log4Sql_Debug @sName, @sError;
				Return (3);
			End;
		--
		Execute EERR_sp_Log4Sql_debug @sName, '__ Limpiamos las tabla de Ajustes antes de la carga de registros';
			Delete From EERR_Tbl_Ajustes 
				Where  1=1
				And IdConsolidado = @iIdConsolidado
				And PeriodoAfectado = @sPeriodoAfecta
				And TipoTransaccion = 0;
			Delete From EERR_Tbl_Ajustes_Cabecera
				Where  1=1
				And IdConsolidado = @iIdConsolidado
				And PeriodoAfectado = @sPeriodoAfecta
				And TipoTransaccion in( 0); --automaticos
				
		Execute EERR_sp_Log4Sql_Debug @sName, '__ Comienzo de proceso de Calculo Ajustes Automaticos';
		--
			Set @iTipo = 0;
			Set @sError = '____ Devolvio Error';
			--
		--
		Set @curConsolidado = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR
			Select IdRegistro, Codigo, Descripcion, PorcentajeParticipacion, TipoNodo, CodigoReferenciado, IndicadorMatriz
					From EERR_Tbl_Consolidados
					Where 1=1
						And idPadre = @iIdConsolidado
					Order By TipoNodo;
		Open @curConsolidado;
		Fetch Next From @curConsolidado Into @iIdRegistro, @sCodigo, @sDescripcion, @nPorcentajeParticipacion, @iTipoNodo, @iCodigoReferenciado, @iIndicadorMatriz
		While @@FETCH_STATUS = 0
			Begin
				Select @iAsiento = isNull( Min(CorrelativoAsiento)-1, -1) From EERR_Tbl_Ajustes
					Where IdConsolidado = @iIdConsolidado
					And PeriodoAfectado = @sPeriodoAfecta
					And TipoTransaccion = 0
				--
				Set @sTexto = '____ Sacamos el valor del ultimo asiento automatico generado para el consolidado, Asiento {' + Convert(varchar, @iAsiento) + '}' ;
				Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
				--
				If @iTipoNodo = 1 -- Consolidado
					Begin
						Set @sTexto = '____ Consolidado, Extraigo el valor del consolidado con empresa matriz' ;
						Set @sTexto = @sTexto + ' Consolidado(Ref) {' + Convert(varchar, @iCodigoReferenciado) + '}';
						Set @sTexto = @sTexto + ' Consolidado {' + @sCodigo + '}';
						Set @sTexto = @sTexto + ' Descripcion {'+ @sDescripcion + '}';
						Set @sTexto = @sTexto + ' % {'+ Convert(varchar(40), @nPorcentajeParticipacion ) + '}';
						Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
						-- Obtenemos el codigo de la empresa matriz
						Select @sCodigoMatriz = Codigo from eerr_tbl_consolidados 
							Where 1=1
							And idPadre = @iCodigoReferenciado And TipoNodo = 2 And IndicadorMatriz = 1
						--
						Set @sTexto = '______ Sacamos el listado de configuracion de cuentas para la compania matriz {' + @sCodigoMatriz + '}' ;
						Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
						Set @nSaldos =  CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR
							Select
								TC.CuentaOrigen
								, Case 
									when CuentaOrigen = '0' Then 
										( Select CuentaEjercicio From eerr_tbl_companias where idCompania = TC.idCompania )
									Else CuentaOrigen
								End CuentaAjuste
								, CuentaDestino, CuentaDestinoNC, ContraCuenta, NgCuentaDestino, NgCuentaDestinoNC, NgContraCuenta										
								, isnull( (
									Select Sum( Credito-Debito ) 
									From EERR_Tbl_Saldos_Contables
									Where 1=1	
									And idCompania = TC.idCompania 
									And Periodo = @sPeriodoAfecta
									And Libro IN ( Select Libro From @TablaLibros )
									And idCuenta = ( 
													Case When CuentaOrigen = '0' Then 
															( Select CuentaEjercicio From eerr_tbl_companias Where idCompania = TC.idCompania )
														Else CuentaOrigen
													End
													)
								), 0) Diferencia
								, rTrim(Glosa) + ' ' + @sCodigo
							From EERR_TbT_Conf_Ajuste_Resultado_x_Inversion TC
							Where 1=1
							And TC.idCompania = @sCodigoMatriz
							Order by TC.CuentaOrigen;
						Open @nSaldos;
						Fetch Next From @nSaldos Into @sCuentaOrigen, @sCuentaAjuste, @sCuentaDestino, @sCuentaDestinoNC, @sContraCuenta,
																				@sNgCuentaDestino, @sNgCuentaDestinoNC, @sNgContraCuenta, @iDiferencia, @sGlosa
						While @@FETCH_STATUS = 0
							Begin
								Set @sTexto = '________ Diferencia  {' + Convert(varchar, @iDiferencia) +'}';
								Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
								--
								If @iDiferencia > 0
									Begin
										Set @sTexto ='________ Diferencias Positiva --';
										Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
										--
										Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Diferencia_Positiva
													@iIdConsolidado, @sPeriodoAfecta, @iAsiento, @iDiferencia, @nPorcentajeParticipacion, @iTipo
													, @sCuentaOrigen, @sCuentaAjuste, @sCuentaDestino, @sCuentaDestinoNC, @sContraCuenta, @sGlosa;
										If @iRetVal = 1
											Begin
												Execute EERR_sp_Log4Sql_Debug @sName, @sError;
												Return @iRetVal;
											End;
									End;
								--
								If @iDiferencia < 0
									Begin
										Set @sTexto ='________ Diferencias Negativa --';
										Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
										--
										Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Diferencia_Negativa
													@iIdConsolidado, @sPeriodoAfecta, @iAsiento, @iDiferencia, @nPorcentajeParticipacion, @iTipo
													, @sCuentaOrigen, @sCuentaAjuste, @sNgCuentaDestino, @sNgCuentaDestinoNC, @sNgContraCuenta, @sGlosa;
										If @iRetVal = 1
											Begin
												Execute EERR_sp_Log4Sql_Debug @sName, @sError;
												Return @iRetVal;
											End;
									End;
								--
								Select @iCuantos = Count(0)
									From EERR_Tbl_Ajustes
									Where 1 = 1
									And idConsolidado = @iIdConsolidado
									And PeriodoAfectado = @sPeriodoAfecta
									And CorrelativoAsiento = @iAsiento;
								If ( @iCuantos > 0)
									Begin
										Select @iCuantos = Count(0)
											From EERR_Tbl_Ajustes_Cabecera
											Where 1 = 1
											And idConsolidado = @iIdConsolidado
											And PeriodoAfectado = @sPeriodoAfecta
											And CorrelativoAsiento = @iAsiento
										If ( @iCuantos = 0)
											Begin
												-- Insertar en la tabla de ajustes -- No Controladora
												Set @sTexto = '__________ Inserta datos Cabecera' ;
												Set @sTexto = @sTexto + ' Consolidado {' + convert(varchar, @iIdConsolidado)+ '}';
												Set @sTexto = @sTexto + ' Correlativo  {'+Convert( varchar, @iAsiento)+'}';
												Set @sTexto = @sTexto + ' Periodo {' + convert(varchar, @sPeriodoAfecta)+ '}';
												Set @sTexto = @sTexto + ' PeriodoV {' + convert(varchar, @sPeriodoAfecta)+ '}';
												Set @sTexto = @sTexto + ' TipoTransaccion {0}';
												Set @sTexto = @sTexto + ' Descripcion {' + @sGlosa  + '}';
												Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
												--
												Insert Into EERR_Tbl_Ajustes_Cabecera
													( idConsolidado, CorrelativoAsiento, PeriodoAfectado, PeriodoVista, TipoTransaccion, Descripcion )
													Values
													( @iIdConsolidado, @iAsiento, @sPeriodoAfecta, @sPeriodoAfecta, 0, @sGlosa  );
											End;
											-- Calcula cambio de contador de asiento
											Set @iAsiento = Case	
																	When @sCuentaOrigen = 0 Then @iAsiento - 1
																	When @sCuentaOrigen <> 0 Then @iAsiento
																	Else @iAsiento
															End;
									End;
									--
									Fetch Next From @nSaldos Into @sCuentaOrigen, @sCuentaAjuste, @sCuentaDestino, @sCuentaDestinoNC, @sContraCuenta,
									@sNgCuentaDestino, @sNgCuentaDestinoNC, @sNgContraCuenta, @iDiferencia, @sGlosa
							End;
						Set @sTexto = '______ Fin de proceso Consolidado-Matriz';
						Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
					End;
				Else
					Begin
						If @iTipoNodo = 2 -- Empresa
							Begin
								Set @sTexto = '____ Empresa' ;
								Set @sTexto = @sTexto + ' compania {' + @sCodigo + '}';
								Set @sTexto = @sTexto + ' Nombre {'+ @sDescripcion + '}';
								Set @sTexto = @sTexto + ' % {'+ Convert(varchar(40), @nPorcentajeParticipacion ) + '}';
								Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
								If @iIndicadorMatriz = 0 -- Es Filial (no matriz)
									Begin
										Set @sTexto = '______ Sacamos el listado de configuracion de cuentas para la compania {' + @sCodigo + '}' ;
										Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
										Set @nSaldos =  CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR
											Select
												TC.CuentaOrigen
												, Case 
													when CuentaOrigen = '0' Then 
														( Select CuentaEjercicio From eerr_tbl_companias where idCompania = TC.idCompania )
													Else CuentaOrigen
												End CuentaAjuste
												, CuentaDestino, CuentaDestinoNC, ContraCuenta, NgCuentaDestino, NgCuentaDestinoNC, NgContraCuenta										
												, isnull( (
													Select Sum( Credito-Debito ) 
													From EERR_Tbl_Saldos_Contables
													Where 1=1	
													And idCompania = TC.idCompania 
													And Periodo = @sPeriodoAfecta
													And Libro IN ( Select Libro From @TablaLibros )
													And idCuenta = ( 
																	Case When CuentaOrigen = '0' Then 
																			( Select CuentaEjercicio From eerr_tbl_companias Where idCompania = TC.idCompania )
																		Else CuentaOrigen
																	End
																	)
												), 0) Diferencia
												, Glosa + ' ' + @sCodigo
											From EERR_TbT_Conf_Ajuste_Resultado_x_Inversion TC
											Where 1=1
											And TC.idCompania = @sCodigo
											Order by TC.CuentaOrigen;
										Open @nSaldos;
										Fetch Next From @nSaldos Into @sCuentaOrigen, @sCuentaAjuste, @sCuentaDestino, @sCuentaDestinoNC, @sContraCuenta,
																					@sNgCuentaDestino, @sNgCuentaDestinoNC, @sNgContraCuenta, @iDiferencia, @sGlosa
										While @@FETCH_STATUS = 0
											Begin
												Set @sTexto = '________ Diferencia  {' + Convert(varchar, @iDiferencia) +'}';
												Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
												--
												If @iDiferencia > 0
													Begin
														Set @sTexto ='________ Diferencias Positiva --';
														Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
														--
														Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Diferencia_Positiva
																@iIdConsolidado, @sPeriodoAfecta, @iAsiento, @iDiferencia, @nPorcentajeParticipacion, @iTipo
																	, @sCuentaOrigen, @sCuentaAjuste, @sCuentaDestino, @sCuentaDestinoNC, @sContraCuenta, @sGlosa;
														If @iRetVal = 1
															Begin
																Execute EERR_sp_Log4Sql_Debug @sName, @sError;
																Return @iRetVal;
															End;
													End;
												--
												If @iDiferencia < 0
													Begin
														Set @sTexto ='________ Diferencias Negativa --';
														Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
														--
														Execute @iRetVal = EERR_Sp_Ajustes_Automaticos_Diferencia_Negativa
																@iIdConsolidado, @sPeriodoAfecta, @iAsiento, @iDiferencia, @nPorcentajeParticipacion, @iTipo
																	, @sCuentaOrigen, @sCuentaAjuste, @sNgCuentaDestino, @sNgCuentaDestinoNC, @sNgContraCuenta, @sGlosa;
														If @iRetVal = 1
															Begin
																Execute EERR_sp_Log4Sql_Debug @sName, @sError;
																Return @iRetVal;
															End;
													End;
												--
												Select @iCuantos = Count(0)
													From EERR_Tbl_Ajustes
													Where 1 = 1
													And idConsolidado = @iIdConsolidado
													And PeriodoAfectado = @sPeriodoAfecta
													And CorrelativoAsiento = @iAsiento;
												If ( @iCuantos > 0)
													Begin
														Select @iCuantos = Count(0)
															From EERR_Tbl_Ajustes_Cabecera
															Where 1 = 1
															And idConsolidado = @iIdConsolidado
															And PeriodoAfectado = @sPeriodoAfecta
															And CorrelativoAsiento = @iAsiento
														If ( @iCuantos = 0)
															Begin
																-- Insertar en la tabla de ajustes -- No Controladora
																Set @sTexto = '__________ Inserta datos Cabecera' ;
																Set @sTexto = @sTexto + ' Consolidado {' + convert(varchar, @iIdConsolidado)+ '}';
																Set @sTexto = @sTexto + ' Correlativo  {'+Convert( varchar, @iAsiento)+'}';
																Set @sTexto = @sTexto + ' Periodo {' + convert(varchar, @sPeriodoAfecta)+ '}';
																Set @sTexto = @sTexto + ' PeriodoV {' + convert(varchar, @sPeriodoAfecta)+ '}';
																Set @sTexto = @sTexto + ' TipoTransaccion {0}';
																Set @sTexto = @sTexto + ' Descripcion {' + @sGlosa  + '}';
																Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
																--
																Insert Into EERR_Tbl_Ajustes_Cabecera
																	( idConsolidado, CorrelativoAsiento, PeriodoAfectado, PeriodoVista, TipoTransaccion, Descripcion )
																	Values
																	( @iIdConsolidado, @iAsiento, @sPeriodoAfecta, @sPeriodoAfecta, 0, @sGlosa  );
															End;
														-- Calcula cambio de contador de asiento
														Set @iAsiento = Case	
																			When @sCuentaOrigen = 0 Then @iAsiento - 1
																			When @sCuentaOrigen <> 0 Then @iAsiento
																			Else @iAsiento
																		End;
													End;
												--
												Fetch Next From @nSaldos Into @sCuentaOrigen, @sCuentaAjuste, @sCuentaDestino, @sCuentaDestinoNC, @sContraCuenta,
												@sNgCuentaDestino, @sNgCuentaDestinoNC, @sNgContraCuenta, @iDiferencia, @sGlosa
											End;
										--
										Set @sTexto = '______ Fin de proceso Empresa';
										Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
									End;
							End;
					End;
				--
				Fetch Next From @curConsolidado Into @iIdRegistro, @sCodigo, @sDescripcion, @nPorcentajeParticipacion, @iTipoNodo, @iCodigoReferenciado, @iIndicadorMatriz
			End;
		--
		Set @sTexto = 'Fin de proceso ajustes Automaticos';
		Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
		--
		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num Err {' + Convert(varchar, ERROR_NUMBER()) + '} Linea {'+ Convert(varchar,ERROR_LINE()) +' } Mensaje {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;
		Return (1);
	End Catch
End;
