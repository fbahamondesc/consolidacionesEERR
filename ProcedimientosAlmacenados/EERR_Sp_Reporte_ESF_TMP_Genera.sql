--use CONSOLIDADO_EERR_DESARROLLO
use CONSOLIDADO_EERR_PRODUCCION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( '[EERR_Sp_Reporte_ESF_TMP_Genera]', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Reporte_ESF_TMP_Genera;
GO

CREATE PROCEDURE EERR_Sp_Reporte_ESF_TMP_Genera
	  @iIdConsolidado as int
	, @sPeriodo as varchar(8)
	, @sLibros as Varchar(100)
	, @sUsuario as varchar(200)
AS

Declare @iRetVal as int;
Declare @sName AS Varchar(100);
Declare @sTexto as nVarchar(500);
Declare @sDeep as varchar(10);
Declare @sDescripcionConsolidado as varchar(100);
Declare @sCodigoConsolidado as varchar(18);
Declare @dTimestamp as datetime
--
Declare @sToken as Varchar(24);
Declare @iIdAnidado as int;
Declare @sCodigoAnidado as Varchar(18);
Declare @sDescripcionAnidado as Varchar(100);
Declare @iIdRegistroOrg as int;
Declare @sPer as Varchar(20);
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
-- Declaracion de variables temporalesde tipo Tabla
Declare @TablaTemporal Table ( 
								idConsolidado int
								, CodigoConsolidado varchar(18)
								, DescripcionConsolidado varchar(500)
								, idCompania varchar(18)
								, DescripcionCompania varchar(500)
								, idGrupo varchar(3)
								, DescripcionGrupo varchar(500)
								, idConcepto varchar(10)
								, DescripcionConcepto varchar(500)
								, idCuenta varchar(8)
								, DescripcionCuenta varchar(500)
								, idPeriodo varchar(6)
								, Valor numeric(25,0)
								, FlagImprime int
								, FlagPatrimonio varchar(2)
								, DescripcionFlag varchar(40)
								, Tipo varchar(2)
								, IdCorrelativoAjuste int
								, LineaAjuste varchar(350)
								, CabeceraAjuste varchar(350)
							 );
Declare @TablaPeriodos Table ( Periodo varchar(6) );
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
							, FlagPatrimonio  varchar(2)
							, DescripcionFlag varchar(10)
							, Tipo varchar(2)
						 );
--
--
BEGIN
	SET NOCOUNT ON;
	--
	Set @sName = 'EERR_Sp_Reporte_ESF_TMP_Genera'; 
	Select @sDescripcionConsolidado = Descripcion, @sCodigoConsolidado = Codigo From EERR_Tbl_Consolidados Where IdRegistro = @iIdConsolidado;
	Set @dTimestamp = GETDATE();
	--
	Set @sDeep  = '__ ';
	Set @sTexto = 'Parametros Entrada';
	Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar, @iIdConsolidado) + '}' ;
	Set @sTexto = @sTexto + ' Periodo {' + @sPeriodo + '}' ;
	Set @sTexto = @sTexto + ' Libro {' + @sLibros + '}' ;
	Set @sTexto = @sTexto + ' Usuario {' + @sUsuario + '}' ;
	Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
	Print @sTexto ;

	--
	Begin Try
		Set @sTexto = 'Inicio Proceso de Generacion de Reporte ESF ODBC';
		Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
		Print @sTexto ;
		--
		--
			-- Ejecutar la carga de ajustes automaticos para consolidado
			Execute EERR_Sp_Ajustes_Automaticos @iIdConsolidado, @sPeriodo, @sLibros;
			--
		--
		--
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
		-- Transforma los periodos en una tabla
		Set @sTexto = '____ Transformacion de Periodos en tabla para consolidados a comparar';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto ;

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
			FROM Separa
		--

		--		
		Set @sTexto = '____ Inicio Extraccion de Ajustes Consolidado';
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
					, CG.idGrupo
					, MG.Descripcion MGDescripcion
					, CG.IdConcepto
					, MCO.Descripcion MCODescripcion
					, CG.IdCuenta
					, CG.IdCuenta + '-' + MCU.Descripcion MCUDescripcion
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
					, Case When AJ.CorrelativoAsiento < 0 Then 'AA' Else 'AM' End Tipo
					, AJ.CorrelativoAsiento
					, AJ.Descripcion
					, ( Select distinct AJC.Descripcion from EERR_Tbl_Ajustes_Cabecera AJC
						Where 1 = 1
						AND AJC.IdConsolidado = C.IdRegistro
						And AJC.PeriodoVista = @sPeriodo
						And AJC.PeriodoAfectado = @sPeriodo
						And AJC.CorrelativoAsiento in ( AJ.CorrelativoAsiento ) ) Descripcion
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
					AND AJ.PeriodoAfectado = @sPeriodo
					AND AJ.PeriodoVista = @sPeriodo
					AND MCO.Tipo in (0,1)
					--
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta
					--
					And CG.IdCuenta = AJ.IdCuenta
		--
		Set @sTexto = '____ Fin Extraccion de Ajustes Consolidado';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto ;
		--
		--
		Set @sTexto = '______ Inserta registros de saldos';
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
					, CG.IdCuenta + '-' + MCU.Descripcion MCUDescripcion
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
					AND CO.IdCompania in ( SELECT codigo FROM EERR_Tbl_Consolidados where idPadre = @iIdConsolidado and TipoNodo = 2 )
					AND SC.Periodo = @sPeriodo
					AND SC.Libro in ( Select Libro from @TablaLibros )
					AND MCO.Tipo in (0,1)
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta
					And SC.IdCompania = CO.IdCompania
					And SC.IdCuenta = MCU.IdCuenta
		--
		Set @sTexto = '____ Fin Inserta saldos de las empresas del consolidado ';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto ;

		--
		--	Extraccion de datos acumulados para consolidados Anidados
		Set @sTexto = '____ Llamado extraccion de saldos de consolidados anidados';
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
			Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdRegistroOrg
			While @@FETCH_STATUS = 0
				Begin
					-- Prevalidacion de anidado a enviar
					Set @iIdAnidado = case when @iIdAnidado = 0 then @iIdRegistroOrg else @iIdAnidado end 
					-- Llamado al recursivo
						-- insertamos auxiliar de navegacion
						Insert into EERR_TMP_TOKEN_ESF_TMP_NIVEL Values( @sToken, 1, @iIdAnidado, @iIdConsolidado);
					--
					Execute @iRetVal = EERR_Sp_Reporte_ESF_TMP_Recursivo_ExtraeSaldosyAjustes @sToken, @iIdAnidado, @sPeriodo, @sLibros, '______', 1;
					If @iRetVal = 1 
						Begin
							Set @sTexto = '____ Devolvio Error';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Return @iRetVal;
						End;
					---- Insertamos todas los Saldos que extrajo del consolidado
					--Set @sTexto = '____ Inserta Saldos';
					--Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					--Insert Into @TablaTemporal
					--	Select  
					--		@iIdConsolidado, @sCodigoConsolidado + '-' + @sDescripcionConsolidado, @sCodigoAnidado, @sCodigoAnidado +'-' + @sDescripcionAnidado, 
					--		idGrupo, DescripcionGrupo, idConcepto, DescripcionConcepto, idCuenta, DescripcionCuenta, idPeriodo, Valor, FlagImprime, 
					--		FlagPatrimonio, DescripcionFlag
					--	From EERR_Tmp_Token_ESF Where Token = @sToken;
					-- Insertamos los Ajustes del consolidado
					Set @sTexto = '____ Inserta Ajustes';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Insert into @TablaPaso
						Select
							@sToken
							, @iIdConsolidado
							, ''
							, @iIdAnidado
							, ''
							, CG.idGrupo
							, ''
							, CG.IdConcepto
							, ''
							, CG.IdCuenta
							, ''
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
							AND MCO.Tipo in (0,1)
							--
							And CG.IdConsolidado = C.IdRegistro
							And CG.IdGrupo = MG.Codigo
							And CG.IdConcepto = MCO.Codigo
							And CG.IdCuenta = MCU.IdCuenta
							And CG.IdCuenta = AJ.IdCuenta
							
					--Delete EERR_Tmp_Token_ESF Where Token = @sToken;
					--
					Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdRegistroOrg
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
								, @sTipoX, 0, '', '', ''
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
			--
			-- Ciclo acumula registros de niveles inferiores
			Set @curNiveles = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
				Select IdNivel, IdConsolidado, IdConsolidadoPadre
				From EERR_TMP_TOKEN_ESF_TMP_NIVEL
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
							Set @iConsolidadoPadreRR = (
														Select IdConsolidadoPadre From EERR_TMP_TOKEN_ESF_TMP_NIVEL 
														Where 1 = 1
															And Token = @sToken
															And IdConsolidado = @iConsolidadoPadreR
														);							
							Set @curSumatoria = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
								Select Token, @iConsolidadoPadreRR, '', IdConsolidado, ''
									, IdGrupo, '', IdConcepto, '', IdCuenta
									, '', IdPeriodo, Valor, FlagImprime, FlagPatrimonio, DescripcionFlag, Tipo
								From EERR_TMP_TOKEN_ESF_TMP
								Where 1 = 1
									And Token = @sToken
									And IdCompania = convert(varchar(18),@iConsolidadoR)
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
												, @sTipoX, 0, '', '', ''
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
							-- Elimino Regitros de nivel inferior
							Delete From EERR_TMP_TOKEN_ESF_TMP
									Where 1 = 1
										And Token = @sTokenX
										And IdCompania = convert(varchar(18),@iConsolidadoR)
						End;
					Fetch Next From @curNiveles Into @iNivelR, @iConsolidadoR, @iConsolidadoPadreR
				End;
			Close @curNiveles; 
			Deallocate @curNiveles;

		Set @sTexto = '____ Fin Llamado extraccion de saldos de consolidados anidados';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		Print @sTexto ;
			
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
					, TmpT.FlagPatrimonio
					, TmpT.DescripcionFlag
					, 'TT'
					, 0, '', ''
				From EERR_TMP_TOKEN_ESF_TMP TmpT Where Token = @sToken;

			Delete from EERR_TMP_TOKEN_ESF_TMP Where Token = @sToken;
			Delete from EERR_TMP_TOKEN_ESF_TMP_NIVEL Where Token = @sToken;
			--Commit;
			--
		Set @sTexto = '____ Fin Extraccion Saldos y Ajustes de consolidados anidados';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;
		--
		Set @sTexto = '____ Inicio limpiado tablas ODBC';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;

		--Delete From @TablaTemporal where idConsolidado = 0;		-- Devolvemos la tabla completa para el reporte
		delete from EERR_ODBC_ESF_UNICO
		 where CodigoInternoConsolidadoEjecutado = @iIdConsolidado
		 and PeriodoAfectado = @sPeriodo;
		
		Set @sTexto = '____ Fin limpiado tablas ODBC';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;

		Set @sTexto = '____ Inicio carga registros unicos';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;

		Insert Into dbo.EERR_ODBC_ESF_UNICO
			Select 
				  TT.CodigoConsolidado		as CodigoConsolidado
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
					, TT.IdPeriodo)			as PeriodoAfectado
				, TT.Valor					as Valor
				, TT.FlagImprime			as FlagImprime
				, TT.FlagPatrimonio			as CodigoTipoPatrimonio
				, TT.DescripcionFlag		as DescripcionTipoPatrimonio
				, TT.Tipo					as TipoRegistro
				, TT.IdCorrelativoAjuste	as CorrelativoAjuste
				, TT.LineaAjuste			as DescripcionLineaAjuste
				, TT.CabeceraAjuste			as DescripcionCabeceraAjuste
				, @iIdConsolidado			as CodigoInternoConsolidadoEjecutado
			From @TablaTemporal TT
			Order By idConsolidado, idCompania, idGrupo, idConcepto, idCuenta
		
		Set @sTexto = '____ Fin carga registros unicos';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;

		Set @sTexto = '____ Inicio carga registros por usuario';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;
		
		Insert Into dbo.EERR_ODBC_ESF
			Select 
				  TT.CodigoConsolidado		as CodigoConsolidado
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
					, TT.IdPeriodo)			as PeriodoAfectado
				, TT.Valor					as Valor
				, TT.FlagImprime			as FlagImprime
				, TT.FlagPatrimonio			as CodigoTipoPatrimonio
				, TT.DescripcionFlag		as DescripcionTipoPatrimonio
				, TT.Tipo					as TipoRegistro
				, TT.IdCorrelativoAjuste	as CorrelativoAjuste
				, TT.LineaAjuste			as DescripcionLineaAjuste
				, TT.CabeceraAjuste			as DescripcionCabeceraAjuste
				, @sUsuario					as NombreUsuarioEjecutador
				, @sLibros					as LibrosEjecutado
				, @iIdConsolidado			as CodigoInternoConsolidadoEjecutado
				, @dTimestamp				as TimeStampRegistro
			--Into dbo.EERR_ODBC_ESF
			From @TablaTemporal TT
			Order By idConsolidado, idCompania, idGrupo, idConcepto, idCuenta
			
		Set @sTexto = '____ Fin carga registros por usuario';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;

		Set @sTexto = '____ Inicio carga registros ajustes unicos';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;
			
		-- Insert agrega registros para el periodo independiente del periodo de visualizacion
			Insert Into dbo.EERR_ODBC_ESF_UNICO
				Select
					  C.Codigo								as CodigoConsolidado
					, C.Codigo +'-'+ C.Descripcion			as DescripcionConsolidado
					, '0'									as CodigoCompania
					, 'Ajustes de Consolidación'			as DescripcionCompania
					, CG.idGrupo							as CodigoGrupo
					, MG.Descripcion						as DescripcionGrupo
					, CG.IdConcepto							as CodigoConcepto
					, MCO.Orden								as OrdenCodigo
					, MCO.Descripcion						as DescripcionConcepto
					, CG.IdCuenta							as CodigoCuenta
					, CG.IdCuenta + '-' + MCU.Descripcion	as DescripcionCuenta
					, AJ.PeriodoVista						as PeriodoVista
					, @sPeriodo								as PeriodoAfectado
					, Case 
						When MCU.Tipo = '2L' and  MCO.Tipo = 1 Then (AJ.Credito - AJ.Debito) 
						When MCU.Tipo = '1A' And MCO.Tipo = 0 Then (AJ.Debito - AJ.Credito ) 
						Else (AJ.Credito - AJ.Debito)
					End										as Valor
					, MCU.FlagImprime						as FlagImprime
					, Case when MCO.Tipo = 0 Then 'AC'
						Else
							Case When MCU.FlagPatrimonio = 1 Then 'PR'
								Else 'PA'
							End
						End									as CodigoTipoPatrimonio
					, Case when MCO.Tipo = 0 Then 'Activos'
						Else
							Case When MCU.FlagPatrimonio = 1 Then 'Patrimonio'
								Else 'Pasivos'
							End
						End									as DescripcionTipoPatrimonio
					, Case When AJ.CorrelativoAsiento < 0 
						Then 'AA' 
						Else 'AM' End						as TipoRegistro
					, AJ.CorrelativoAsiento					as CorrelativoAjuste
					, AJ.Descripcion						as DescripcionLineaAjuste
					, ( Select AJC.Descripcion from EERR_Tbl_Ajustes_Cabecera AJC
						Where 1 = 1
						AND AJC.IdConsolidado = C.IdRegistro
						And AJC.PeriodoVista = @sPeriodo
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
					And C.IdRegistro = @iIdConsolidado
					AND AJ.IdConsolidado = C.IdRegistro
					AND AJ.PeriodoAfectado = @sPeriodo
					AND AJ.periodoVista <> @sPeriodo
					AND MCO.Tipo in (0,1)
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta
					And CG.IdCuenta = AJ.IdCuenta		

		Set @sTexto = '____ Fin carga registros ajustes unicos';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;

		Set @sTexto = '____ Inicio carga registros ajustes por usuario';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;


			Insert Into dbo.EERR_ODBC_ESF
				Select
					  C.Codigo								as CodigoConsolidado
					, C.Codigo +'-'+ C.Descripcion			as DescripcionConsolidado
					, '0'									as CodigoCompania
					, 'Ajustes de Consolidación'			as DescripcionCompania
					, CG.idGrupo							as CodigoGrupo
					, MG.Descripcion						as DescripcionGrupo
					, CG.IdConcepto							as CodigoConcepto
					, MCO.Orden								as OrdenCodigo
					, MCO.Descripcion						as DescripcionConcepto
					, CG.IdCuenta							as CodigoCuenta
					, CG.IdCuenta + '-' + MCU.Descripcion	as DescripcionCuenta
					, AJ.PeriodoVista						as PeriodoVista
					, @sPeriodo								as PeriodoAfectado
					, Case 
						When MCU.Tipo = '2L' and  MCO.Tipo = 1 Then (AJ.Credito - AJ.Debito) 
						When MCU.Tipo = '1A' And MCO.Tipo = 0 Then (AJ.Debito - AJ.Credito ) 
						Else (AJ.Credito - AJ.Debito)
					End										as Valor
					, MCU.FlagImprime						as FlagImprime
					, Case when MCO.Tipo = 0 Then 'AC'
						Else
							Case When MCU.FlagPatrimonio = 1 Then 'PR'
								Else 'PA'
							End
						End									as CodigoTipoPatrimonio
					, Case when MCO.Tipo = 0 Then 'Activos'
						Else
							Case When MCU.FlagPatrimonio = 1 Then 'Patrimonio'
								Else 'Pasivos'
							End
						End									as DescripcionTipoPatrimonio
					, Case When AJ.CorrelativoAsiento < 0 
						Then 'AA' 
						Else 'AM' End						as TipoRegistro
					, AJ.CorrelativoAsiento					as CorrelativoAjuste
					, AJ.Descripcion						as DescripcionLineaAjuste
					, ( Select AJC.Descripcion from EERR_Tbl_Ajustes_Cabecera AJC
						Where 1 = 1
						AND AJC.IdConsolidado = C.IdRegistro
						And AJC.PeriodoVista = @sPeriodo
						And AJC.PeriodoAfectado = @sPeriodo
						And AJC.CorrelativoAsiento in ( AJ.CorrelativoAsiento ) )
															as DescripcionCabeceraAjuste
					, @sUsuario					as NombreUsuarioEjecutador
					, @sLibros					as LibrosEjecutado
					, @iIdConsolidado			as CodigoInternoConsolidadoEjecutado
					, @dTimestamp				as TimeStampRegistro
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
					AND AJ.PeriodoAfectado = @sPeriodo
					AND AJ.periodoVista <> @sPeriodo
					AND MCO.Tipo in (0,1)
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta
					And CG.IdCuenta = AJ.IdCuenta		

		Set @sTexto = '____ Fin carga registros ajustes unicos';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		print @sTexto;

		Set @sTexto = 'Fin Proceso de Generacion de Reporte ESF ODBC';
		Execute EERR_sp_Log4Sql_info @sName, @sTexto;

		--
		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = ' Num : {' + Convert(varchar, ERROR_LINE()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;
--print @sName+@sErr
		Return (1);
	End Catch
End;
