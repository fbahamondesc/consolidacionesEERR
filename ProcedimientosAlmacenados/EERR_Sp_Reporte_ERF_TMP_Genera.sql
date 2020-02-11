--Use CONSOLIDADO_EERR_DESARROLLO
Use CONSOLIDADO_EERR_PRODUCCION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( '[EERR_Sp_Reporte_ERF_TMP_Genera]', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Reporte_ERF_TMP_Genera;
GO

CREATE PROCEDURE EERR_Sp_Reporte_ERF_TMP_Genera
	  @iIdConsolidado as int
	, @sPeriodo as varchar(6)
	, @sLibros as Varchar(100)
	, @sUsuario as varchar(200)
AS

Declare @iRetVal as int;
Declare @sName AS Varchar(100);
Declare @sTexto as nVarchar(500);
Declare @sDescripcionConsolidado as varchar(100);
Declare @dTimeStamp as datetime;
--
Declare @sPer as Varchar(20);
Declare @sToken as Varchar(24);
Declare @iIdAnidado as int;
Declare @sCodigoAnidado as varchar(18);
Declare @sDescripcionAnidado as Varchar(100);
Declare @iIdAnidadoOrg as int;
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
Declare @iCuenta as int
Declare @iNivelR as int;
Declare @iConsolidadoR as int;
Declare @iConsolidadoPadreR as int;
Declare @iConsolidadoPadreRR as int;
--
-- Daclaracion de cursores
Declare @curAnidados as Cursor;
Declare @curSumatoria as Cursor;
Declare @curNiveles as Cursor;
--
-- Declaracion de variables temporales de tipo Tabla
Declare @TablaTemporal Table ( 
								idConsolidado int
								, Codigo varchar(18)
								, DescripcionConsolidado varchar(500)
								, idCompania varchar(18)
								, DescripcionCompania varchar(500)
								, idGrupo varchar(4)					-- Este codigo incluye el tipo para uso de orden
								, DescripcionGrupo varchar(500)
								, idConcepto varchar(10)				-- Este codigo incluye el el campo de orden
								, DescripcionConcepto varchar(500)
								, idCuenta varchar(8)
								, DescripcionCuenta varchar(500)
								, idPeriodo varchar(6)
								, Valor numeric(25)
								, FlagImprime int
								, Tipo varchar(2)
								, IdCorrelativoAjuste int
								, LineaAjuste varchar(350)
								, CabeceraAjuste varchar(350)
							 );
Declare @TablaPeriodos Table ( Periodo varchar(6) );
Declare @TablaLibros Table ( Libro varchar(20) );
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
							, Tipo varchar(2)
						 );
--
--
BEGIN
	SET NOCOUNT ON;
	--
	Set @sName = 'EERR_Sp_Reporte_ERF_TMP_Genera';
	Select @sDescripcionConsolidado = Codigo +'-'+ Descripcion From EERR_Tbl_Consolidados Where IdRegistro = @iIdConsolidado;
	Set @dTimeStamp = GETDATE();
	--
	Set @sTexto = 'Parametros Entrada';
	Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar, @iIdConsolidado) + '}' ;
	Set @sTexto = @sTexto + ' Periodo {' + @sPeriodo + '}' ;
	Set @sTexto = @sTexto + ' Libros {' + @sLibros + '}' ;
	Set @sTexto = @sTexto + ' Usuario {' + @sUsuario + '}' ;
	Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
	Print @sTexto ;
	--
	Begin Try
		Set @sTexto = 'Inicio Proceso de Generacion de Reporte ERF ODBC';
		Execute EERR_sp_Log4Sql_info @sName, @sTexto;
		Print @sTexto ;
		--
		--
			-- Ejecutar la carga de ajustes automaticos para consolidado
			Execute EERR_Sp_Ajustes_Automaticos @iIdConsolidado, @sPeriodo, @sLibros;
			--
		--
		-- Transforma los periodos en una tabla
		Set @sTexto = '____ Transformacion de Periodos en tabla para consolidados a comparar';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto ;
		--
		--
		Set @sPer = @sPeriodo;
		WITH Separa(pn, start, stop) AS (
			SELECT 1, 1, CASE WHEN CHARINDEX(',', @sPer)>0 THEN CHARINDEX(',', @sPer) ELSE LEN(@sPer)+1 END
			UNION ALL
			SELECT pn + 1, stop + 1, CASE WHEN CHARINDEX(',', @sPer, stop + 1)> 0 THEN CHARINDEX(',', @sPer, stop + 1) ELSE LEN(@sPer)+1 END
			FROM Separa
			WHERE stop > 0 AND stop<LEN(@sPer)-1
		)
		Insert Into @TablaPeriodos
			SELECT SUBSTRING(@sPer, start, stop - start) Periodo
			FROM Separa;
		--
		-- Transforma los libros en una tabla
		WITH Separa2(pn, start, stop) AS (
			SELECT 1, 1, CASE WHEN CHARINDEX(',', @sLibros)>0 THEN CHARINDEX(',', @sLibros) ELSE LEN(@sLibros)+1 END
			UNION ALL
			SELECT pn + 1, stop + 1, CASE WHEN CHARINDEX(',', @sLibros, stop + 1)> 0 THEN CHARINDEX(',', @sLibros, stop + 1) ELSE LEN(@sLibros)+1 END
			FROM Separa2
			WHERE stop > 0 AND stop<LEN(@sLibros)-1
		)
		Insert Into @TablaLibros
			SELECT SUBSTRING(@sLibros, start, stop - start) Libro
			FROM Separa2;
		--
		--
		Set @sTexto = '____ Inicio Extraccion de Ajustes';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto ;
		--
			Insert Into @TablaTemporal
				Select
					C.IdRegistro
					, C.Codigo
					, C.Codigo +'-'+ C.Descripcion
					, '0' 
					, 'Ajustes de Consolidación'
					, CG.IdGrupo
					, MG.Descripcion MGDescripcion
					, CG.IdConcepto
					, MCO.Descripcion MCODescripcion
					, CG.IdCuenta
					, MCU.Descripcion MCUDescripcion
					, @sPeriodo
					, Case When  CG.IdCuenta = 'ERF_NC' Then (AJ.Debito - AJ.Credito)
						Else (AJ.Credito - AJ.Debito) 
						End Valor
					, MCU.FlagImprime
					, Case When AJ.CorrelativoAsiento < 0 Then 'AA' Else 'AM' End Tipo
					, AJ.CorrelativoAsiento
					, AJ.Descripcion
					, ( Select distinct AJC.Descripcion from EERR_Tbl_Ajustes_Cabecera AJC
						Where 1 = 1
						AND AJC.IdConsolidado = C.IdRegistro
						And AJC.PeriodoVista = @sPeriodo
						And AJC.CorrelativoAsiento in ( AJ.CorrelativoAsiento ) 
						) Descripcion
				From EERR_Tbl_Consolidados C
					, EERR_Tbl_Ajustes AJ
					, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
					, EERR_Tbl_Maestro_Grupos MG
					, EERR_Tbl_Maestro_Conceptos MCO
					, EERR_Tbl_Maestro_Cuentas MCU
				Where 1=1
					--
					AND C.IdRegistro = @iIdConsolidado					
					AND AJ.PeriodoAfectado = @sPeriodo
					AND MCU.Tipo in ( '3I', '3E' )
					And CG.IdCuenta = AJ.IdCuenta
					--
					AND AJ.IdConsolidado = C.IdRegistro
					AND AJ.PeriodoVista = AJ.PeriodoAfectado
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta
		--
		Set @sTexto = '____ Fin Extraccion de Ajustes';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;
		--
		--
		Set @sTexto = '____ Inserta registros saldos contables de las empresas del consolidado';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto ;
		--
			Insert Into @TablaTemporal
				Select
					C.IdRegistro
					, C.Codigo
					, C.Codigo + '-' + C.Descripcion
					, SC.IdCompania 
					, SC.IdCompania + '-' + CO.Nombre
					, CG.idGrupo
					, MG.Descripcion MGDescripcion
					, CG.IdConcepto
					, MCO.Descripcion MCODescripcion
					, CG.IdCuenta
					, MCU.Descripcion MCUDescripcion
					, SC.Periodo
					, Case When  CG.IdCuenta = 'ERF_NC' then (SC.Debito - SC.Credito)
						Else (SC.Credito - SC.Debito) 
						End Valor
					, MCU.FlagImprime
					, 'SA'
					, 0
					, ''
					, ''
				From EERR_Tbl_Consolidados C
					, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
					, EERR_Tbl_Maestro_Grupos MG
					, EERR_Tbl_Maestro_Conceptos MCO
					, EERR_Tbl_Maestro_Cuentas MCU
					, EERR_Tbl_Saldos_Contables SC
					, EERR_Tbl_Companias CO
				Where 1=1
					AND C.IdRegistro = @iIdConsolidado
					AND CO.IdCompania in ( 
						SELECT codigo FROM EERR_Tbl_Consolidados where idPadre = @iIdConsolidado and TipoNodo = 2
										)
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
		Set @sTexto = '____ Fin Inserta saldos de las empresas del consolidado';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;
		--
		--	Extraccion de datos acumulados para consolidados Anidados
		Set @sTexto = '____ Extraccion de Saldos y Ajustes de consolidados anidados';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto ;
			-- Creacion de un token para las transacciones
			Set @sToken = convert(varchar(24), ROUND(CAST(CAST(GETUTCDATE() AS FLOAT)*8.64e8 AS BIGINT),-1)*1000+599266080000000000);
			Set @sTexto = '_____ Token creado {' + @sToken +'}';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Print @sTexto ;
			-- Saldos y Ajustes Consolidado Inicial
			Set @sTexto = '_____ Codigo Consolidado a buscar como padre {' + CONVERT(varchar, @iIdConsolidado) +'}';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Print @sTexto ;
			--
			Set @curAnidados = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
				Select CodigoReferenciado, Codigo, Descripcion, idRegistro From EERR_Tbl_Consolidados
				 Where idPadre = @iIdConsolidado And TipoNodo = 1 order by TipoNodo;
			Open @curAnidados;
			Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdAnidadoOrg
			While @@FETCH_STATUS = 0
				Begin
					-- Prechequeo de id a enviar
					set @iIdAnidado = Case when @iIdAnidado = 0 then @iIdAnidadoOrg Else @iIdAnidado End;
					-- Llamado al recursivo
						-- insertamos auxiliar de navegacion
						Insert into EERR_TMP_TOKEN_ERF_TMP_NIVEL Values( @sToken, 1, @iIdAnidado, @iIdConsolidado);
					--
					Execute @iRetVal = EERR_Sp_Reporte_ERF_TMP_Recursivo_ExtraeSaldosyAjustes @sToken, @iIdAnidado, @sPeriodo, @sLibros, '______', 1;
					If @iRetVal = 1 
						Begin
							Set @sTexto = '____ Devolvio Error';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Print @sTexto ;
							Return @iRetVal;
						End;
					-- Insertamos los Ajustes del consolidado
					Set @sTexto = '_____ Insertamos los Ajustes de nivel:1';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Print @sTexto ;
					Insert into @TablaPaso
								Select
									  @sToken
									, @iIdConsolidado
									, ''
									, @iIdAnidado
									, ''
									, CG.IdGrupo
									, ''
									, CG.IdConcepto
									, ''
									, CG.IdCuenta
									, ''
									, @sPeriodo
									, Case 
										When  CG.IdCuenta = 'ERF_NC' Then (AJ.Debito - AJ.Credito)
										Else (AJ.Credito - AJ.Debito) 
										End Valor
									, MCU.FlagImprime
									, 'AN'
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
									--
									And CG.IdConsolidado = C.IdRegistro
									And CG.IdGrupo = MG.Codigo
									And CG.IdConcepto = MCO.Codigo
									And CG.IdCuenta = MCU.IdCuenta
									And CG.IdCuenta = AJ.IdCuenta
									
					--Delete from EERR_TMP_TOKEN_ERF_TMP Where Token = @sToken;
					--
					Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdAnidadoOrg
				End;
			Close @curAnidados; 
			Deallocate @curAnidados;
			--
			-- Traspaso de datos acumulados por cuenta contable
			--
			-- Ciclo para sumas los regitros por cuenta
			Set @sTexto = '__ Ciclo para sumas los regitros por cuenta';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Print @sTexto ;
			Set @curSumatoria = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
				Select Token, IdConsolidado, DescripcionConsolidado, IdCompania, DescripcionCompania
					, IdGrupo, DescripcionGrupo, IdConcepto, DescripcionConcepto, IdCuenta
					, DescripcionCuenta, IdPeriodo, Valor, FlagImprime, Tipo
				From @TablaPaso
			Open @curSumatoria;
			Fetch Next From @curSumatoria Into 
					  @sTokenX, @iIdConsolidadoX, @sDescripcionConsolidadoX, @sIdCompaniaX
					, @sDescripcionCompaniaX, @sIdGrupoX, @sDescripcionGrupoX, @sIdConceptoX
					, @sDescripcionConceptoX, @sIdCuentaX, @sDescripcionCuentaX, @sIdPeriodoX
					, @nValorX, @iFlagImprimeX, @sTipoX
			While @@FETCH_STATUS = 0
				Begin
					Set @iCuenta = (
									Select Count(0)
									From EERR_TMP_TOKEN_ERF_TMP
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
							Insert into EERR_TMP_TOKEN_ERF_TMP Values
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
								, @sTipoX	, 0, '', '', ''
							)
						End;
					Else
						Begin
							Update EERR_TMP_TOKEN_ERF_TMP Set
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
							, @nValorX, @iFlagImprimeX, @sTipoX
				End;
			Close @curSumatoria; 
			Deallocate @curSumatoria;
			--
			-- Ciclo acumula registros de niveles inferiores
			Set @curNiveles = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
				Select IdNivel, IdConsolidado, IdConsolidadoPadre
				From EERR_TMP_TOKEN_ERF_TMP_NIVEL
				Where 1 = 1
					And Token = @sToken
				Order By IdNivel desc
			Open @curNiveles;
			Fetch Next From @curNiveles Into @iNivelR, @iConsolidadoR, @iConsolidadoPadreR
			While @@FETCH_STATUS = 0
				Begin
					If @iNivelR > 1
						Begin
							-- Ciclo para sumas los regitros por cuenta de niveles inferiores
							Set @sTexto = '__ Ciclo para sumas los regitros por cuenta';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Print @sTexto ;
							Set @iConsolidadoPadreRR = (
														Select IdConsolidadoPadre From EERR_TMP_TOKEN_ERF_TMP_NIVEL 
														Where 1 = 1
															And Token = @sToken
															And IdConsolidado = @iConsolidadoPadreR
														);							
							Set @curSumatoria = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
								Select Token, @iConsolidadoPadreRR, '', IdConsolidado, ''
									, IdGrupo, '', IdConcepto, '', IdCuenta
									, '', IdPeriodo, Valor, FlagImprime, Tipo
								From EERR_TMP_TOKEN_ERF_TMP
								Where 1 = 1
									And Token = @sToken
									And IdCompania = convert(varchar(18), @iConsolidadoR)
							Open @curSumatoria;
							Fetch Next From @curSumatoria Into 
										  @sTokenX, @iIdConsolidadoX, @sDescripcionConsolidadoX, @sIdCompaniaX
										, @sDescripcionCompaniaX, @sIdGrupoX, @sDescripcionGrupoX, @sIdConceptoX
										, @sDescripcionConceptoX, @sIdCuentaX, @sDescripcionCuentaX, @sIdPeriodoX
										, @nValorX, @iFlagImprimeX, @sTipoX
							While @@FETCH_STATUS = 0
								Begin
									Set @iCuenta = (
													Select Count(0)
													From EERR_TMP_TOKEN_ERF_TMP
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
											Insert into EERR_TMP_TOKEN_ERF_TMP Values
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
												, @sTipoX	, 0, '', '', ''
											)
										End;
									Else
										Begin
											Update EERR_TMP_TOKEN_ERF_TMP Set
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
											, @nValorX, @iFlagImprimeX, @sTipoX
								End;
							Close @curSumatoria; 
							Deallocate @curSumatoria;
							-- Elimino Regitros de nivel inferior
							Delete From EERR_TMP_TOKEN_ERF_TMP
									Where 1 = 1
										And Token = @sTokenX
										And IdCompania = convert( varchar(18), @iConsolidadoR )
						End;
					Fetch Next From @curNiveles Into @iNivelR, @iConsolidadoR, @iConsolidadoPadreR
				End;
			Close @curNiveles; 
			Deallocate @curNiveles;
			
			-- Insertamos todas los Saldos que extrajo del consolidado
			Set @sTexto = '_____ Insertamos los ajustes y saldos que extrajo';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Print @sTexto ;
			Insert Into @TablaTemporal
				Select  
					  TmpT.IdConsolidado
					, (Select Codigo From EERR_Tbl_Consolidados Where IdRegistro = TmpT.IdConsolidado) CodigoConsolidado
					, (Select Codigo +'-'+Descripcion From EERR_Tbl_Consolidados Where IdRegistro = TmpT.IdConsolidado) DescripcionConsolidado
					, TmpT.IdCompania
					, (Select Codigo +'-'+Descripcion From EERR_Tbl_Consolidados Where convert(varchar(18),IdRegistro) = TmpT.IdCompania) DescripcionCompania
					, TmpT.IdGrupo
					, (Select Descripcion From EERR_Tbl_Maestro_Grupos Where Codigo = TmpT.IdGrupo) DescripcionGrupo
					, TmpT.IdConcepto
					, (Select Descripcion From EERR_Tbl_Maestro_Conceptos Where Codigo = TmpT.IdConcepto) DescripcionConcepto
					, TmpT.IdCuenta
					, (Select Descripcion From EERR_Tbl_Maestro_Cuentas Where IdCuenta = TmpT.IdCuenta ) DescripcionCuenta
					, TmpT.IdPeriodo
					, TmpT.Valor
					, TmpT.FlagImprime
					, 'TT'
					, 0, '', ''
				From EERR_TMP_TOKEN_ERF_TMP TmpT Where Token = @sToken;

			--Delete from EERR_TMP_TOKEN_ERF_TMP Where Token = @sToken;
			--Delete from EERR_TMP_TOKEN_ERF_TMP_NIVEL Where Token = @sToken;
			--Commit;
			--
		Set @sTexto = '____ Fin Extraccion Saldos y Ajustes de consolidados anidados';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;
		--

		Set @sTexto = '____ Limpia tabla unico por consolidado y periodo';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;

		--Delete From @TablaTemporal where idConsolidado = 0;
		delete from dbo.EERR_ODBC_ERF_UNICO
		 where CodigoInternoConsolidadoEjecutado = @iIdConsolidado
		 and PeriodoAfectado = @sPeriodo ;
		 
		Set @sTexto = '____ Fin Limpia tabla unico por consolidado y periodo';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;
		
		Set @sTexto = '____ Inserta en tabla odbc Unico';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;

		Insert into dbo.EERR_ODBC_ERF_UNICO
			Select 
				  TT.Codigo					as CodigoConsolidado
				, TT.DescripcionConsolidado	as DescripcionConsolidado
				, TT.IdCompania				as CodigoCompania
				, TT.DescripcionCompania	as DescripcionCompania
				, TT.IdGrupo				as CodigoGrupo
				, TT.DescripcionGrupo		as DescripcionGrupo
				, TT.IdConcepto				as CodigoConcepto
				, (select Orden from EERR_Tbl_Maestro_Conceptos where Codigo = TT.IdConcepto)
					as OrdenCodigo
				, TT.DescripcionConcepto	as DescripcionConcepto
				, TT.IdCuenta				as CodigoCuenta
				, TT.DescripcionCuenta		as DescripcionCuenta
				, TT.IdPeriodo				as PeriodoVista
				, isnull( (select distinct PeriodoAfectado from EERR_Tbl_Ajustes 
						where 1 = 1
						and IdConsolidado = TT.IdConsolidado 
						and CorrelativoAsiento = TT.IdCorrelativoAjuste
						and IdCuenta = TT.IdCuenta
						and TT.IdCompania = '0'
						and PeriodoVista = TT.IdPeriodo
						and PeriodoAfectado = TT.IdPeriodo
						)
					, TT.IdPeriodo)
					as PeriodoAfectado
				, TT.Valor					as Valor
				, TT.FlagImprime			as FlagImprime
				, TT.Tipo					as TipoRegistro
				, TT.IdCorrelativoAjuste	as CorrelativoAjuste
				, TT.LineaAjuste			as DescripcionLineaAjuste
				, TT.CabeceraAjuste			as DescripcionCabeceraAjuste
				, @iIdConsolidado			as CodigoInternoConsolidadoEjecutado
			--Into dbo.EERR_ODBC_ERF
			From @TablaTemporal TT
			Order By idConsolidado, idCompania, idGrupo, idConcepto, idCuenta
		
		Set @sTexto = '____ Fin Inserta en tabla odbc Unico';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;
		
		Set @sTexto = '____ Inserta en tabla Odbc instancias por usuario';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;

		-- Devolvemos la tabla completa para el reporte ordenada
		Insert into dbo.EERR_ODBC_ERF
			Select 
				  TT.Codigo					as CodigoConsolidado
				, TT.DescripcionConsolidado	as DescripcionConsolidado
				, TT.IdCompania				as CodigoCompania
				, TT.DescripcionCompania	as DescripcionCompania
				, TT.IdGrupo				as CodigoGrupo
				, TT.DescripcionGrupo		as DescripcionGrupo
				, TT.IdConcepto				as CodigoConcepto
				, (select Orden from EERR_Tbl_Maestro_Conceptos where Codigo = TT.IdConcepto)
					as OrdenCodigo
				, TT.DescripcionConcepto	as DescripcionConcepto
				, TT.IdCuenta				as CodigoCuenta
				, TT.DescripcionCuenta		as DescripcionCuenta
				, TT.IdPeriodo				as PeriodoVista
				, isnull( (select distinct PeriodoAfectado from EERR_Tbl_Ajustes 
						where 1 = 1
						and IdConsolidado = TT.IdConsolidado 
						and CorrelativoAsiento = TT.IdCorrelativoAjuste
						and IdCuenta = TT.IdCuenta
						and TT.IdCompania = '0'
						and PeriodoVista = TT.IdPeriodo
						and PeriodoAfectado = TT.IdPeriodo
						)
					, TT.IdPeriodo)
					as PeriodoAfectado
				, TT.Valor					as Valor
				, TT.FlagImprime			as FlagImprime
				, TT.Tipo					as TipoRegistro
				, TT.IdCorrelativoAjuste	as CorrelativoAjuste
				, TT.LineaAjuste			as DescripcionLineaAjuste
				, TT.CabeceraAjuste			as DescripcionCabeceraAjuste
				, @sUsuario					as NombreUsuarioEjecutador
				, @sLibros					as LibrosEjecutado
				, @iIdConsolidado			as CodigoInternoConsolidadoEjecutado
				, @dTimeStamp				as TimeStampRegistro
			--Into dbo.EERR_ODBC_ERF
			From @TablaTemporal TT
			Order By idConsolidado, idCompania, idGrupo, idConcepto, idCuenta

		Set @sTexto = '____ Fin Inserta en tabla Odbc instancias por usuario';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;

		Set @sTexto = '____ Inserta ajustes en tabla Odbc unico';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;

		-- Insert Agrega registro para el perido afectado independiente del periodo de visualizacion 
		Insert into dbo.EERR_ODBC_ERF_UNICO
				Select
					  C.Codigo								as CodigoConsolidado
					, C.Codigo+'-'+C.Descripcion			as DescripcionConsolidado
					, '0'									as CodigoCompania
					, 'Ajustes de Consolidación'			as DescripcionCompania
					, CG.IdGrupo							as CodigoGrupo
					, MG.Descripcion						as DescripcionGrupo
					, CG.IdConcepto							as CodigoConcepto
					, MCO.Orden								as OrdenCodigo
					, MCO.Descripcion						as DescripcionConcepto
					, CG.IdCuenta							as CodigoCuenta
					, MCU.Descripcion						as DescripcionCuenta
					, AJ.PeriodoVista						as PeriodoVista
					, @sPeriodo								as PeriodoAfectado
					, Case When  CG.IdCuenta = 'ERF_NC' 
						Then (AJ.Debito - AJ.Credito)
						Else (AJ.Credito - AJ.Debito) 
						End									as Valor
					, MCU.FlagImprime						as FlagImprime
					, Case When AJ.CorrelativoAsiento < 0 
						Then 'AA' 
						Else 'AM' End 						as TipoRegistro
					, AJ.CorrelativoAsiento					as CorrelativoAjuste
					, AJ.Descripcion						as DescripcionLineaAjuste
					, ( Select AJC.Descripcion from EERR_Tbl_Ajustes_Cabecera AJC
						Where 1 = 1
						AND AJC.IdConsolidado = C.IdRegistro
						And AJC.PeriodoAfectado = @sPeriodo
						And AJC.CorrelativoAsiento in ( AJ.CorrelativoAsiento ) )
															as DescripcionCabeceraAjuste
					, @iIdConsolidado			as CodigoInternoConsolidadoEjecutado
				From EERR_Tbl_Consolidados C
					, EERR_Tbl_Ajustes AJ
					, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
					, EERR_Tbl_Maestro_Grupos MG
					, EERR_Tbl_Maestro_Conceptos MCO
					, EERR_Tbl_Maestro_Cuentas MCU
				Where 1=1
					--
					AND C.IdRegistro = @iIdConsolidado					
					AND AJ.PeriodoAfectado = @sPeriodo
					AND AJ.periodoVista <> @sPeriodo
					AND MCU.Tipo in ( '3I', '3E' )
					And CG.IdCuenta = AJ.IdCuenta
					AND AJ.IdConsolidado = C.IdRegistro
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta
		
		Set @sTexto = '____ Fin Inserta ajustes en tabla Odbc unico';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;
		
		Set @sTexto = '____ Inserta ajustes en tabla Odbc instancia por usuario';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto;

		Insert into dbo.EERR_ODBC_ERF
				Select
					  C.Codigo								as CodigoConsolidado
					, C.Codigo+'-'+C.Descripcion			as DescripcionConsolidado
					, '0'									as CodigoCompania
					, 'Ajustes de Consolidación'			as DescripcionCompania
					, CG.IdGrupo							as CodigoGrupo
					, MG.Descripcion						as DescripcionGrupo
					, CG.IdConcepto							as CodigoConcepto
					, MCO.Orden								as OrdenCodigo
					, MCO.Descripcion						as DescripcionConcepto
					, CG.IdCuenta							as CodigoCuenta
					, MCU.Descripcion						as DescripcionCuenta
					, AJ.PeriodoVista						as PeriodoVista
					, @sPeriodo								as PeriodoAfectado
					, Case When  CG.IdCuenta = 'ERF_NC' 
						Then (AJ.Debito - AJ.Credito)
						Else (AJ.Credito - AJ.Debito) 
						End									as Valor
					, MCU.FlagImprime						as FlagImprime
					, Case When AJ.CorrelativoAsiento < 0 
						Then 'AA' 
						Else 'AM' End 						as TipoRegistro
					, AJ.CorrelativoAsiento					as CorrelativoAjuste
					, AJ.Descripcion						as DescripcionLineaAjuste
					, ( Select AJC.Descripcion from EERR_Tbl_Ajustes_Cabecera AJC
						Where 1 = 1
						AND AJC.IdConsolidado = C.IdRegistro
						And AJC.PeriodoAfectado = @sPeriodo
						And AJC.CorrelativoAsiento in ( AJ.CorrelativoAsiento ) )
															as DescripcionCabeceraAjuste
					, @sUsuario					as NombreUsuarioEjecutador
					, @sLibros					as LibrosEjecutado
					, @iIdConsolidado			as CodigoInternoConsolidadoEjecutado
					, @dTimeStamp				as TimeStampRegistro
				From EERR_Tbl_Consolidados C
					, EERR_Tbl_Ajustes AJ
					, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
					, EERR_Tbl_Maestro_Grupos MG
					, EERR_Tbl_Maestro_Conceptos MCO
					, EERR_Tbl_Maestro_Cuentas MCU
				Where 1=1
					--
					AND C.IdRegistro = @iIdConsolidado					
					AND AJ.PeriodoAfectado = @sPeriodo
					AND AJ.periodoVista <> @sPeriodo
					AND MCU.Tipo in ( '3I', '3E' )
					And CG.IdCuenta = AJ.IdCuenta
					AND AJ.IdConsolidado = C.IdRegistro
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta
					
					
			Set @sTexto = '____ Fin Inserta ajustes en tabla Odbc instancia por usuario';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Print @sTexto;
					
		Set @sTexto = 'Fin Proceso de Generacion de Reporte ERF ODBC';
		Execute EERR_sp_Log4Sql_info @sName, @sTexto;
		--
		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_LINE()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;

		Print @sErr

		Return (1);
	End Catch
End;
