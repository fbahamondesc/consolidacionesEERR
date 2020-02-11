SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Carga_Datos_Contables', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Carga_Datos_Contables;
GO

CREATE PROCEDURE EERR_Sp_Carga_Datos_Contables
AS

-- Variables
Declare @sName as Varchar(100);
Declare @sSql as nVarchar(4000);
Declare @sTexto as nVarchar(500);
Declare @sCodigo as Varchar(10);
Declare @sBasedatos as Varchar(100);
Declare @sEjercicio as Varchar(10);
Declare @sAcumulado as Varchar(10);
Declare @sPeriodo as Varchar(6);
Declare @sPeriodoAcumulado as Varchar(6);
Declare @sLibro as Varchar(10);
Declare @sLibroAnterior as Varchar(10);
Declare @sLibroAcumulado as Varchar(10);
Declare @nDebito as Numeric(35,15);
Declare @nCredito as Numeric(35,15);
Declare @nDebitoEjercicio as Numeric(35,15);
Declare @nCreditoEjercicio as Numeric(35,15);
Declare @nDebitoAcumulado as Numeric(35,15);
Declare @nCreditoAcumulado as Numeric(35,15);
Declare @nDebitoAcumuladoP as Numeric(35,15);
Declare @nCreditoAcumuladoP as Numeric(35,15);
Declare @nDebitoAcumuladoX as Numeric(35,15);
Declare @nCreditoAcumuladoX as Numeric(35,15);
Declare @sCuenta as Varchar(8);
Declare @sCuentaAcumulado as Varchar(8);
Declare @sAnio as Varchar(4);
Declare @iCuenta as Int;
Declare @sPeriodoVigente as Char(6);
Declare @iInicio as Int;
Declare @iTermino as Int;
Declare @sPerMes as Varchar(6);
Declare @sAnioBusca as Varchar(4);
Declare @iAnio as Int;
Declare @iAnioVigente as Int;
Declare @iAnioInicio as Int;
Declare @sPeriodoCiclo as Varchar(8);
Declare @sAnioTop as Varchar(8);
Declare @iMesVigente as int;

Begin
	Set @sName = 'EERR_Sp_Carga_Datos_Contables'; 

	Begin Try
		Execute EERR_sp_Log4Sql_Info @sName, '_ Limpiamos la tabla de EERR_Tbl_Saldos_Contables antes de la carga de registros';
		Delete From EERR_Tbl_Saldos_Contables Where Origen = 0;
		-- Extraemos periodo Vigente
		Select @sPeriodoVigente = pernbr from APP0101CONSTRUCTORA..glsetup
		--Tomamos el año vigente desde el periodo vigente
		Set @iAnioVigente = Convert( int, substring( @sPeriodoVigente, 1,4) )
		Set @iMesVigente =  Convert( int, substring( @sPeriodoVigente, 5,2) )
		--
		Set @sTexto = '_ Periodo vigente {' + @sPeriodoVigente + '}'
		Set @sTexto = @sTexto +' Anio vigente {' + Convert(varchar(5), @iAnioVigente) + '}'
		Set @sTexto = @sTexto +' Mes vigente {' + Convert(varchar(2), @iMesVigente) + '}'
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		-------------------------------------------------------------------------------------------------------------------------
		Declare curCompanias Cursor LOCAL STATIC READ_ONLY FORWARD_ONLY  For 
			Select rTrim(idCompania), rTrim(BaseDatos), rTrim(CuentaEjercicio), rTrim(CuentaAcumulado) 
				From EERR_Tbl_Companias 
				Where Origen = 0
				--And idCompania = '0171';
		Open curCompanias;
		Fetch Next From curCompanias Into @sCodigo, @sBasedatos, @sEjercicio, @sAcumulado;
		While @@FETCH_STATUS = 0
		Begin
			Set @sTexto = '_ Comienzo de proceso para Empresa {' + @sCodigo + '}'
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
			Set @sTexto = '__ Obtencion de Datos contables';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Set @sSql = 
					N'Insert Into EERR_Tbl_Saldos_Contables
						Select 
							''' + @sCodigo + ''' as IdCompania
							, A.acct as Cuenta
							,A.PerPost as Periodo
							,0 as Origen
							,A.LedgerID as Libro
							,sum(a.CuryDrAmt) as Debito
							,sum(a.CuryCrAmt) as Credito
						From ' + @sBasedatos + '.dbo.GLTran A 
							LEFT join ' + @sBasedatos + '.dbo.Account b on ( a.Acct=b.Acct )
						Where Posted in (''P'')
						Group by A.acct, A.PerPost, A.LedgerID'
--							,sum(a.DrAmt) as Debito
--							,sum(a.CrAmt) as Credito
--						And fiscyr >= ''' + '2016' + ''' 
			Set @sTexto = '__' + @sSql;
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Execute sp_executesql @sSql;
			-----------------------------------------------------------------------------------------------------------------------
			Set @sTexto = '__ Obtencion de Libros y Anios de inicio para el Calculo para empresa {' + @sCodigo + '}';
			Set @sTexto = @sTexto + ' hasta periodo vigente {' + @sPeriodoVigente + '}';
			Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
			-- Inicializo las variables de libro y anio de inicio de cada ciclo
			Set @iAnioInicio = 0;
			Set @sLibroAnterior = '';
			-- Obtencion de Periodos por libro
			Declare curAcumulaEjercicio Cursor LOCAL STATIC READ_ONLY FORWARD_ONLY  For
				select distinct libro
					, min( substring( periodo, 1, 4) )
					from EERR_Tbl_Saldos_Contables
					where 1= 1
					And idCompania = @sCodigo
					And origen = 0
					group by libro
					order by libro
			Open curAcumulaEjercicio;
			Fetch Next From curAcumulaEjercicio into @sLibro, @sAnio
			While @@FETCH_STATUS = 0
				Begin
					Set @sLibro = rtrim(@sLibro);
					Set @sTexto = '____ Registro del ciclo ';
					Set @sTexto = @sTexto + ' Libro = {' + @sLibro + '}';
					Set @sTexto = @sTexto + ' inicia en Anio {' + @sAnio + '}';
					Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
					-- Verifica Corte de control
					If @sLibro != @sLibroAnterior
						Begin
							-- Limpieza de acumuladores por Libro, Anio
							Set @nDebitoAcumulado = 0;
							Set @nCreditoAcumulado = 0;
							-- Cambio el libro y el anio de inicio del ciclo para el libro
							Set @sLibroAnterior = @sLibro;
							Set @iAnioInicio = @sAnio;
						End;
					-- Ciclo que va desde anio inicio hasta anio vigente
					While @iAnioInicio <= @iAnioVigente
						Begin
							--------------------------------------------------------------------------------------------------------------------
							--------------------------------------------------------------------------------------------------------------------
							--------------------------------------------------------------------------------------------------------------------
							-- Limpio variables
							Set @nDebito = 0;
							Set @nCredito = 0;
							-- armo año anterior mes diciembre para tomar los montos a acumular
							Set @sAnioBusca = Cast((Cast(@iAnioInicio as int) - 1) as Varchar(4));
							--
							Set @sTexto = '______ Calculo de Resultado Acumulado para Empresa {' + @sCodigo + '} Libro {' + @sLibro + '} Anio {' + convert(varchar(4), @iAnioInicio) + '}';
							Set @sTexto = @sTexto + ' CodAcumulado {' + @sAcumulado + '}';
							Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
							-- Calculo de valores acumulados hasta el año  y se agregan luego 12 por año salvo el ultimo activo
							Set @sTexto = '________  Busco saldo anio anterior = {' + @sAnioBusca + '12}';
							Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
							-- Query de busqueda
							Select @nDebito = Sum(Debito) , @nCredito = Sum(Credito)
								From EERR_Tbl_Saldos_Contables SC, EERR_Tbl_Cuentas_x_Compania CC
								Where 1=1
								And SC.IdCompania = CC.IdCompania
								And SC.IdCuenta = CC.IdCuenta
								And SC.IdCompania = @sCodigo
								And SC.Origen = 0
								And SC.Periodo =  Convert( varchar(4), (@iAnioInicio -1)) + '12'
								And SC.Libro = @sLibro
								And CC.Tipo IN ('3I', '3E')
								Group By SC.IdCompania, SC.Libro
								Order By SC.IdCompania, SC.Libro
							--
							Set @sTexto = '________  Extrae Debito {' + convert( varchar(30), isnull(@nDebito, 0)) + '} Credito {' + convert(varchar(30), isnull(@nCredito, 0)) + '}';
							Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
							-- Acumuladores
							Set @nDebitoAcumulado = isnull(@nDebito, 0) + @nDebitoAcumulado
							Set @nCreditoAcumulado = isnull(@nCredito, 0) + @nCreditoAcumulado
							--
							Set @sTexto = '____________ Acumulado Debito {' + Cast(@nDebitoAcumulado as varchar(35)) + '} Credito {' + cast(@nCreditoAcumulado as Varchar(35)) + '}';
							Set @sTexto = @sTexto + ' Diferencia {' + Cast((@nCreditoAcumulado-@nDebitoAcumulado) as varchar(35)) + '}';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							-- Determino Periodo Inicio y Termino del ciclo para el anio
							Set @iInicio = 1;
							If @iAnioInicio = @iAnioVigente
								Set @iTermino = @iMesVigente;
							Else
								Set @iTermino = 12;
							--
							Set @sTexto = '__________ Inicio  {' + Convert(varchar(4),@iAnioInicio) + Right( '00' + (Convert(varchar,@iInicio)), 2)  + '} ';
							Set @sTexto = @sTexto + ' Termino {' + Convert(varchar(4),@iAnioInicio) + Right( '00' + (Convert(varchar,@iTermino)), 2) + '}';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							-- Ciclo de creacion de registros
							While @iInicio <= @iTermino
								Begin
									-- Armo el periodo
									Set @sPerMes = Convert(varchar(4),@iAnioInicio) + Right( '00' + (Convert(varchar,@iInicio)), 2);
									-- Verifico si hay registros para la cuenta
									Select @iCuenta = isNull(Count(0), 0)
										, @nDebitoAcumuladoP = isNull(@nDebitoAcumulado + Sum(Debito), 0)
										, @nCreditoAcumuladoP = isNull(@nCreditoAcumulado + Sum(Credito), 0)
											From EERR_Tbl_Saldos_Contables
											Where 1=1
											And idCompania = @sCodigo
											And idCuenta = @sAcumulado
											And Libro = @sLibro
											And Periodo = @sPerMes;
									--
									Set @sTexto = '____________ Cuantos {' + Convert(varchar,@iCuenta) + '}' ;
									Set @sTexto = @sTexto + ' Compania {' + @sCodigo + '}';
									Set @sTexto = @sTexto + ' Cuenta {' + @sAcumulado + '}';
									Set @sTexto = @sTexto + ' Libro {' + @sLibro + '}';
									Set @sTexto = @sTexto + ' Periodo {' + @sPerMes + '}';
									Set @sTexto = @sTexto + ' Debito {' + cast(@nDebitoAcumulado as varchar(35)) + '}';
									Set @sTexto = @sTexto + ' Credito {' + cast(@nCreditoAcumulado as varchar(35)) + '}';
									Set @sTexto = @sTexto + ' Diferencia {' + cast((@nCreditoAcumulado-@nDebitoAcumulado) as varchar(35)) + '}';
									Set @sTexto = @sTexto + ' DebitoP {' + cast(@nDebitoAcumuladoP as varchar(35)) + '}';
									Set @sTexto = @sTexto + ' CreditoP {' + cast(@nCreditoAcumuladoP as varchar(35)) + '}';
									Set @sTexto = @sTexto + ' DiferenciaP {' + cast((@nCreditoAcumuladoP-@nDebitoAcumuladoP) as varchar(35)) + '}';
									Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
									--
									If @iCuenta > 0
										Begin
											-- Sumo cantidad obtenida de la consulta
											Set @nDebitoAcumulado = @nDebitoAcumuladoP;
											Set @nCreditoAcumulado = @nCreditoAcumuladoP;
											--
											Set @sTexto = '____________ Actualiza la Cuenta de Acumulado por que existe ';
											Set @sTexto = @sTexto + ' Periodo {' + @sPerMes + '}';
											Set @sTexto = @sTexto + ' Cuenta {' + @sAcumulado + '}';
											Set @sTexto = @sTexto + ' Libro {' + @sLibro + '}';
											Set @sTexto = @sTexto + ' Credito {' + cast(@nDebitoAcumulado as varchar(35)) + '}';
											Set @sTexto = @sTexto + ' Debito {' + cast(@nCreditoAcumulado as varchar(35)) + '}';
											Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
											-- Actualizar el registro con los valores
											Update EERR_Tbl_Saldos_Contables Set
													Debito = @nDebitoAcumuladoP
													,Credito = @nCreditoAcumuladoP
												Where 1=1
												And idCompania = @sCodigo
												And idCuenta = @sAcumulado
												And Libro = @sLibro
												And Periodo = @sPerMes;
										End;
									Else
										Begin
											Set @sTexto = '____________ Agrega la Cuenta de Acumulado por que no existe {';
											Set @sTexto = @sTexto + ' Periodo {' + @sPerMes + '}';
											Set @sTexto = @sTexto + ' Cuenta {' + @sAcumulado + '}';
											Set @sTexto = @sTexto + ' Libro {' + @sLibro + '}';
											Set @sTexto = @sTexto + ' Credito {' + cast(@nDebitoAcumulado as varchar(35)) + '}';
											Set @sTexto = @sTexto + ' Debito {' + cast(@nCreditoAcumulado as varchar(35)) + '}';
											Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
											-- Actualizar el registro con los valores
											Insert Into EERR_Tbl_Saldos_Contables Values ( 
													@sCodigo, @sAcumulado, @sPerMes, 0 , @sLibro, @nDebitoAcumulado, @nCreditoAcumulado );
										End;
									Set @iInicio = @iInicio + 1;
								End;
							--------------------------------------------------------------------------------------------------------------------
							--------------------------------------------------------------------------------------------------------------------
							--------------------------------------------------------------------------------------------------------------------
							Set @sTexto = '______ Calculo Acumulado Mensual para cuenta de resultado por Empresa {' + @sCodigo + '} Libro {' + @sLibro + '}';
							Set @sTexto = @sTexto + ' Anio {' + Convert( varchar(4), @iAnioInicio) + '}';
							Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
							--
							Declare curAcumuladoCuentas Cursor LOCAL STATIC READ_ONLY FORWARD_ONLY For
								Select SC.IdCuenta
									From EERR_Tbl_Saldos_Contables SC, EERR_Tbl_Cuentas_x_Compania CC
									Where 1=1
									And SC.IdCompania = CC.IdCompania
									And SC.IdCuenta = CC.IdCuenta
									And SC.Origen = 0
									And CC.Tipo IN ('3I', '3E')
									And SC.IdCompania = @sCodigo
									And Substring(sc.Periodo, 1, 4) = Convert( varchar(4), @iAnioInicio)
									And SC.Libro = @sLibro
									Group BY SC.IdCuenta
									Order By SC.IdCuenta;
							Open curAcumuladoCuentas;
							Fetch Next From curAcumuladoCuentas into @sCuentaAcumulado;
							While @@FETCH_STATUS = 0
								Begin
									Set @sTexto = '________ sCuentaAcumulado {' + @sCuentaAcumulado + '}';
									Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
									-- Limpiamos Variables de Acumulacion 
									Set @nDebitoAcumuladoX = 0;
									Set @nCreditoAcumuladoX = 0;
									Set @nDebito = 0;
									Set @nCredito = 0;
									Set @iInicio = 1;
									-- Ciclo que toma los periodos hasta el anio vigente y mes vigente
									Set @iInicio = 1;
									While @iInicio <= @iTermino
										Begin
											-- Armo el periodo
											Set @sPerMes = Convert(varchar(4),@iAnioInicio) + Right( '00' + (Convert(varchar,@iInicio)), 2);
											--
											Set @sTexto = '__________ Arma Periodo {' + @sPerMes + '}';
											Set @sTexto = @sTexto + ' Anio {' + Convert( varchar(4), @iAnioInicio) + '}';
											Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
											--
											Select 
												@iCuenta = isNull(Count(0), 0)
												,@nDebito = isNull(Sum(SC.Debito),0)
												,@nCredito = isNull(Sum(SC.Credito), 0)
												From EERR_Tbl_Saldos_Contables SC
												Where 1=1
												And SC.Origen = 0
												And SC.IdCompania = @sCodigo
												And SC.Periodo = @sPerMes
												And SC.Libro = @sLibro
												And sc.IdCuenta = @sCuentaAcumulado
											-- Acumulamos valores
											Set @nDebitoAcumuladoX = @nDebitoAcumuladoX + @nDebito;
											Set @nCreditoAcumuladoX = @nCreditoAcumuladoX + @nCredito;
											-- Evulo la cantidad de registro encontrados
											If @iCuenta > 0
												Begin
													Set @sTexto = '____________ Actualiza registro Cuenta ';
													Set @sTexto = @sTexto + ' Periodo {' + @sPerMes + '}';
													Set @sTexto = @sTexto + ' Cuenta {' + @sCuentaAcumulado + '}';
													Set @sTexto = @sTexto + ' Libro {' + @sLibro + '}';
													Set @sTexto = @sTexto + ' Credito {' + cast(@nDebitoAcumuladoX as varchar(35)) + '}';
													Set @sTexto = @sTexto + ' Debito {' + cast(@nCreditoAcumuladoX as varchar(35)) + '}';
													Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							
													Update EERR_Tbl_Saldos_Contables Set
															Debito = @nDebitoAcumuladoX
															,Credito = @nCreditoAcumuladoX
														Where 1 = 1
														And IdCompania = @sCodigo
														And Libro = @sLibro
														And IdCuenta = @sCuentaAcumulado
														And Periodo = @sPerMes;
												End;
											Else
												Begin
													Set @sTexto = '____________ Agrega registro Cuenta   ';
													Set @sTexto = @sTexto + ' Periodo {' + @sPerMes + '}';
													Set @sTexto = @sTexto + ' Cuenta {' + @sCuentaAcumulado + '}';
													Set @sTexto = @sTexto + ' Libro {' + @sLibro + '}';
													Set @sTexto = @sTexto + ' Credito {' + cast(@nDebitoAcumuladoX as varchar(35)) + '}';
													Set @sTexto = @sTexto + ' Debito {' + cast(@nCreditoAcumuladoX as varchar(35)) + '}';
													Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;

													Insert Into EERR_Tbl_Saldos_Contables Values ( 
															@sCodigo, @sCuentaAcumulado, @sPerMes, 0 , @sLibro, @nDebitoAcumuladoX, @nCreditoAcumuladoX );
												End;
											Set @iInicio = @iInicio + 1;
										End;
									--
									Fetch Next From curAcumuladoCuentas into @sCuentaAcumulado;
								End;
							Close curAcumuladoCuentas;
							Deallocate curAcumuladoCuentas;
							--------------------------------------------------------------------------------------------------------------------
							--------------------------------------------------------------------------------------------------------------------
							--------------------------------------------------------------------------------------------------------------------
							Set @sTexto = '______ Calculo de Resultado Ejercicio para Empresa {' + @sCodigo + '} Libro {' + @sLibro + '}';
							Set @sTexto = @sTexto + ' Anio {' + convert( varchar(4), @iAnioInicio) + '}';
							Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
							-- Limpieza de Acumuladores
							Set @nDebitoEjercicio = 0;
							Set @nCreditoEjercicio = 0;
							-- Obtencion de registros del año
							Declare cuRecorrePeriodos Cursor LOCAL STATIC READ_ONLY FORWARD_ONLY For
								Select rTrim(SC.Periodo), Sum(Debito), Sum(Credito)
									From EERR_Tbl_Saldos_Contables SC, EERR_Tbl_Cuentas_x_Compania CC
									Where 1=1
									And SC.IdCompania = CC.IdCompania
									And SC.IdCuenta = CC.IdCuenta
									And SC.Origen = 0
									And CC.Tipo IN ('3I', '3E')
									And SC.IdCompania = @sCodigo
									And Substring(sc.Periodo, 1, 4) = Convert( varchar(4), @iAnioInicio)
									And SC.Libro = @sLibro
									Group BY SC.IdCompania, SC.Libro, SC.Periodo
									Order By SC.IdCompania, SC.Libro, SC.Periodo
							Open cuRecorrePeriodos;
							Fetch Next From cuRecorrePeriodos into @sPeriodo, @nDebito, @nCredito
							While @@FETCH_STATUS = 0
								Begin
									Set @sTexto = '__________ Acumula ejercicio Empresa {' + @sCodigo + '} Libro {' + @sLibro + '} Anio {' + Convert( varchar(4), @iAnioInicio) + '} ';
									Set @sTexto = @sTexto + ' Periodo {' + @sPeriodo + '} Debito {' + cast(@nDebito As varchar(35)) + '}';
									Set @sTexto = @sTexto + ' Credito {' + Cast(@nCredito as Varchar(35))  + '}';
									Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
									-- Acumulamos el valor del ejercicio
									Set @nDebitoEjercicio = @nDebito;
									Set @nCreditoEjercicio = @nCredito;
									-- Verifico si hay registros para la cuenta
									Select @iCuenta = isNull(count(0), 0) 
										From EERR_Tbl_Saldos_Contables
										Where 1=1
											And idCompania = @sCodigo
											And idCuenta = @sEjercicio
											And Libro = @sLibro
											And Periodo = @sPeriodo;
									--
									If @iCuenta > 0
										Begin
											Set @sTexto = '__________ Actualiza la cuenta de ejercicio por que existe';
											Set @sTexto = + @sTexto + ' Compania {' + @sCodigo + '}  Cuenta {' +  @sEjercicio + '}';
											Set @sTexto = + @sTexto + ' Libro {' + @sLibro + '} Periodo {' + @sPeriodo + '}'
											Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
											Update EERR_Tbl_Saldos_Contables Set
												Debito = Debito + @nDebitoEjercicio
												,Credito = Credito + @nCreditoEjercicio
											Where 1=1
											And idCompania = @sCodigo
											And idCuenta =  @sEjercicio
											And Libro = @sLibro
											And Periodo = @sPeriodo;
										End;
									Else
										Begin
											Set @sTexto = '__________ Agrega la cuenta de ejercicio por que no existe';
											Set @sTexto = + @sTexto + ' Compania {' + @sCodigo + '}  Cuenta {' +  @sEjercicio + '}';
											Set @sTexto = + @sTexto + ' Libro {' + @sLibro + '} Periodo {' + @sPeriodo + '}'
											Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
											Insert Into EERR_Tbl_Saldos_Contables Values ( 
													@sCodigo, @sEjercicio, @sPeriodo, 0, @sLibro, @nDebitoEjercicio, @nCreditoEjercicio);
										End;
									Fetch Next From cuRecorrePeriodos into @sPeriodo, @nDebito, @nCredito
								End;
							Close cuRecorrePeriodos;
							Deallocate cuRecorrePeriodos;
							Set @iAnioInicio = @iAnioInicio + 1;
						End;
					--
					Fetch Next From curAcumulaEjercicio into @sLibro, @sAnio
				End;
			Close curAcumulaEjercicio;
			Deallocate curAcumulaEjercicio;
			--------------------------------------------------------------------------------------------------------------------
			--------------------------------------------------------------------------------------------------------------------
			--------------------------------------------------------------------------------------------------------------------
			Set @sTexto = '__ Actualizacion de Registros Acumulando Valores para empresa {' + @sCodigo + '}';
			Set @sTexto = @sTexto + ' Tipo IN (''1A'', ''2L'')'
			Set @sTexto = @sTexto + ' para todas las Cuentas Not In ( ''241001'',''240801'' )' 
			Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
			--
			Declare curAcumular Cursor LOCAL STATIC READ_ONLY FORWARD_ONLY  For
				Select  rTrim(SC.Libro) Libro, rTrim(SC.IdCuenta) Cuenta
				From EERR_Tbl_Saldos_Contables SC, EERR_Tbl_Cuentas_x_Compania CC
				Where 1=1
					And SC.IdCompania = @sCodigo
					And SC.IdCompania = CC.IdCompania
					And SC.IdCuenta = CC.IdCuenta
					And CC.Tipo IN ('1A', '2L')
					And SC.Origen = 0
					And CC.IdCuenta Not In ( '241001','240801' )
					Group By Sc.Libro, SC.IdCuenta
					Order By Sc.Libro, SC.IdCuenta;
			Open curAcumular;
			Fetch Next from curAcumular Into @sLibro, @sCuenta;
			While @@FETCH_STATUS = 0
			Begin
				Set @sTexto = '____ Ciclo Acumulacion de Registros por Empresa {' + @sCodigo + '} Libro  {' + @sLibro + '}';
				Set @sTexto = @sTexto + ' Cuenta {' + @sCuenta + '}';
				Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
				-- Limpiamos las variables para el libro cuenta
				Set @nDebitoAcumulado = 0;
				Set @nCreditoAcumulado = 0;
				--Set @iAnio = 2005;
				Set @iAnioVigente = Convert(int, Substring(@sPeriodoVigente, 1, 4));
				-- Buscamos el anio menor
				Select top 1 @sAnioTop = Substring(Periodo, 1,4)
						From EERR_Tbl_Saldos_Contables
						Where 1=1
							And IdCompania = @sCodigo
							And Libro = @sLibro
							And IdCuenta = @sCuenta
							--And Periodo = @sPeriodoCiclo
							And Origen = 0
						Order by Periodo;
				If (@sAnioTop is null)
					Begin;
						Set @iAnio = @iAnioVigente+1;
					End;
				Else
					Begin
						Set @iAnio = Convert( int, @sAnioTop);
					End;
				--
				While @iAnio <= @iAnioVigente
				Begin
					Set @iInicio = Case When @iAnio = 2005 Then 1 Else 1 End;
					Set @iTermino = Case When @iAnio = @iAnioVigente Then Convert(Int,Substring(@sPeriodoVigente, 5, 2)) Else 12 End;
					--
					Set @sTexto = '______ Ciclo para Empresa {' + @sCodigo + '}';
					Set @sTexto = @sTexto + ' Libro {' + @sLibro + '}';
					Set @sTexto = @sTexto + ' Cuenta {' + @sCuenta + '}';
					Set @sTexto = @sTexto + ' Anio {' + Convert(varchar, @iAnio) + '}';
					Set @sTexto = @sTexto + ' Inicio {' + Convert(varchar,@iInicio) + '} Termino {' + convert(varchar,@iTermino) + '}';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					While @iInicio <= @iTermino
					Begin
						Set @sPeriodoCiclo = Convert( Varchar, @iAnio) + Right( '00' + Convert(varchar, @iInicio), 2);
						--
						Set @sTexto = '________ PeriodoCiclo {' + @sPeriodoCiclo + '}';
						Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
						--
						Set @nDebitoAcumuladoP = 0;
						Set @nCreditoAcumuladoP = 0;
						--						
						Select @iCuenta = count(0)
							, @nDebitoAcumuladoP = Sum(Debito)
							, @nCreditoAcumuladoP = Sum(Credito)
						From EERR_Tbl_Saldos_Contables
						Where 1=1
							And IdCompania = @sCodigo
							And Libro = @sLibro
							And IdCuenta = @sCuenta
							And Periodo = @sPeriodoCiclo
							And Origen = 0;
						--
						Set @sTexto = '________ Cantidad {' + Convert( varchar, @iCuenta) + '}';
						Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
						--
						If @iCuenta = 0
							Begin
								Set @sTexto = '__________ Inserta ';
								Set @sTexto = @sTexto + ' Codigo {' + @sCodigo + '}';
								Set @sTexto = @sTexto + ' Cuenta {' + @sCuenta + '}';
								Set @sTexto = @sTexto + ' Periodo {' + @sPeriodoCiclo + '}';
								Set @sTexto = @sTexto + ' Libro {' + @sLibro + '}';
								Set @sTexto = @sTexto + ' Debito {' + Convert( varchar(100), @nDebitoAcumulado) + '}';
								Set @sTexto = @sTexto + ' Credito {' + Convert( varchar(100), @nCreditoAcumulado) + '}';
								Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
								--
								Insert Into EERR_Tbl_Saldos_Contables
									( IdCompania, idCuenta, Periodo, Origen, Libro, Debito, Credito )
									Values
									( @sCodigo, @sCuenta, @sPeriodoCiclo, 0, @sLibro, @nDebitoAcumulado, @nCreditoAcumulado );
							End;
						Else
							Begin
								Set @sTexto = '__________ Actualiza ';
								Set @sTexto = @sTexto + ' Codigo {' + @sCodigo + '}';
								Set @sTexto = @sTexto + ' Cuenta {' + @sCuenta + '}';
								Set @sTexto = @sTexto + ' Periodo {' + @sPeriodoCiclo + '}';
								Set @sTexto = @sTexto + ' Libro {' + @sLibro + '}';
								Set @sTexto = @sTexto + ' Debito {' + Convert( varchar(100), @nDebitoAcumulado) + '}';
								Set @sTexto = @sTexto + ' Credito {' + Convert( varchar(100), @nCreditoAcumulado) + '}';
								--
								Set @nDebitoAcumulado = @nDebitoAcumulado + @nDebitoAcumuladoP;
								Set @nCreditoAcumulado = @nCreditoAcumulado + @nCreditoAcumuladoP;
								--
								Update EERR_Tbl_Saldos_Contables  Set
									Debito = @nDebitoAcumulado
									, Credito = @nCreditoAcumulado
								Where 1=1
								And IdCompania = @sCodigo
								And Libro = @sLibro
								And IdCuenta = @sCuenta
								And Periodo = @sPeriodoCiclo
								And Origen = 0;
							End;
						Set @iInicio = @iInicio + 1;
					End;
					Set @iAnio  = @iAnio + 1; 
				End;
				--
				Fetch Next from curAcumular Into @sLibro, @sCuenta 
			End;
			Close curAcumular;
			Deallocate curAcumular;
			-----------------------------------------------------------------------------------------------------------------------
			-- Proximo registro
		Fetch Next From curCompanias Into @sCodigo, @sBasedatos, @sEjercicio, @sAcumulado;
		End;
		Execute EERR_sp_Log4Sql_Info @sName, 'Termino del proceso carga EERR_Tbl_Saldos_Contables';
		Close curCompanias;
		Deallocate curCompanias;
		-------------------------------------------------------------------------------------------------------------------------

		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num Err {' + Convert(varchar, ERROR_NUMBER()) + '} Linea {'+ Convert(varchar,ERROR_LINE()) +' } Mensaje {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;

		IF OBJECT_ID ( 'curAcumular' ) IS NOT NULL 
		Begin
			Close curAcumular;
			Deallocate curAcumular;
		End;
		IF OBJECT_ID ( 'curAcumulaEjercicio' ) IS NOT NULL 
		Begin
			Close curAcumulaEjercicio;
			Deallocate curAcumulaEjercicio;
		End;
		IF OBJECT_ID ( 'cuRecorrePeriodos' ) IS NOT NULL 
		Begin
			Close cuRecorrePeriodos;
			Deallocate cuRecorrePeriodos;
		End;

		Close curCompanias;
		Deallocate curCompanias;

		Return (1);
	End Catch
End;
