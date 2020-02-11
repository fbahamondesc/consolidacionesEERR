--use CONSOLIDADO_EERR_DESARROLLO
use CONSOLIDADO_EERR_PRODUCCION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( '[EERR_Sp_Reporte_ESFSuper_Genera]', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Reporte_ESFSuper_Genera;
GO

CREATE PROCEDURE EERR_Sp_Reporte_ESFSuper_Genera
	 @iIdConsolidado as int
	,@sPeriodo as varchar(8)
	,@iIdConsolidadoComparar as int
	,@sPeriodoComparar as varchar(8)
	,@sLibros as Varchar(100)
AS

Declare @iRetVal as int;
Declare @sName AS Varchar(100);
Declare @sTexto as nVarchar(500);
--
--
Declare @sDescripcionConsolidado as varchar(100);
Declare @sDescripcionConsolidadoComparar as varchar(100);
Declare @sCodigoConsolidado as varchar(18);
Declare @sCodigoConsolidadoComparar as varchar(18);
--
Declare @sToken as Varchar(24);
Declare @iIdAnidado as int;
Declare @sCodigoAnidado as Varchar(18);
Declare @sDescripcionAnidado as Varchar(100);
Declare @iIdRegistroOrg as int;
Declare @sPer as Varchar(20);
Declare @sTituloReporte as varchar(200);
--
Declare @iCuenta as int;
Declare @iSoloAjuste as int;
Declare @iIdConsolidadoX as int;
Declare @sIdGrupoX as varchar(3);
Declare @sDescripcionGrupoX as varchar(500);
Declare @sIdConceptoX as varchar(10);
Declare @sDescripcionConceptoX as varchar(500);
Declare @nValorX as numeric(25,0);
Declare @iFlagImprimeX as int;
Declare @sFlagPatrimonioX as varchar(2);
Declare @sDescripcionFlagX as varchar(40);
Declare @sIdCuentaX as varchar(8);
Declare @sCicloPatrimonio as varchar(2);
Declare @sCicloGrupo as varchar(3);
Declare @sCicloConcepto as varchar(10);
Declare @sCicloFlagSumaESF as char(1);
Declare @nCicloValor1 as numeric(25,0);
Declare @nCicloValor2 as numeric(25,0);
Declare @sCortePatrimonio as varchar(2);
Declare @sCorteGrupo as varchar(3);
Declare @sCorteFlagSumaESF as char(1);
Declare @nCorteTotales1 as numeric(25,0)
Declare @nCorteTotales2 as numeric(25,0);
--
Declare @curAnidados as Cursor;
Declare @curRegistros as Cursor;
Declare @curCorte as Cursor;
-- Declaracion de variables temporalesde tipo Tabla
Declare @TablaTemporal Table ( 
								idConsolidado int
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
							 );
Declare @TablaReporte Table (
						  IdPatrimonio varchar(2)
						, IdGrupo varchar(3)
						, IdConcepto varchar(10)
						, Valor1 numeric(25,0)
						, Valor2 numeric(25,0) 
						, DescripcionPatrimonio varchar(80)
						, DescripcionGrupo varchar(500)
						, DescripcionConcepto varchar(500)
						, IdPeriodo1 varchar(6)
						, IdPeriodo2 varchar(6)
						, DescripcionConsolidado varchar(500)
						, FlagSumaESF char(1)
						);
Declare @TablaLibros Table ( Libro varchar(20) ); -- Tabla para transformar en registro los libros enviados por parametro
Declare @TablaPeriodos Table ( Periodo varchar(6) );
--
--
BEGIN
	SET NOCOUNT ON;
	--
	Set @sName = 'EERR_Sp_Reporte_ESFSuper_Genera'; 
	Select @sDescripcionConsolidado = Descripcion, @sCodigoConsolidado = Codigo From EERR_Tbl_Consolidados Where IdRegistro = @iIdConsolidado;
	Select @sDescripcionConsolidadoComparar = Descripcion, @sCodigoConsolidadoComparar = Codigo From EERR_Tbl_Consolidados Where idRegistro = @iIdConsolidadoComparar;
	--
	Set @sTexto = '__ Parametros Entrada';
	Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar, @iIdConsolidado) + '}' ;
	Set @sTexto = @sTexto + ' Periodo {' + @sPeriodo + '}' ;
	Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar, @iIdConsolidadoComparar) + '}' ;
	Set @sTexto = @sTexto + ' Periodo {' + @sPeriodoComparar + '}' ;
	Set @sTexto = @sTexto + ' Libro {' + @sLibros + '}' ;
	Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
	--
	Begin Try
		Set @sTexto = '__ Proceso de Generacion de Reporte ESFSuper';
		Execute EERR_sp_Log4Sql_Info @sName, @sTexto;
		--
		--
			-- Ejecutar la carga de ajustes automaticos para consolidado
			Execute EERR_Sp_Ajustes_Automaticos @iIdConsolidado, @sPeriodo, @sLibros;
			-- Ejecutar la carga de ajustes automaticos para consolidado a comparar
			Execute EERR_Sp_Ajustes_Automaticos @iIdConsolidadoComparar, @sPeriodoComparar, @sLibros;
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
		--
		-- Transforma los periodos en una tabla
		Set @sTexto = '____ Transformacion de Periodos en tabla para consolidados a comparar';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		Set @sPer = @sPeriodo +','+ @sPeriodoComparar;
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
		--
			Insert Into @TablaTemporal
				Select
					C.IdRegistro
					, C.Codigo +'-'+ C.Descripcion
					, '0' 
					, 'Ajustes'
					, CG.idGrupo
					, MG.Descripcion MGDescripcion
					, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
					, MCO.Descripcion MCODescripcion
					, CG.IdCuenta
					, CG.IdCuenta + '-' +MCU.Descripcion MCUDescripcion
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
			Set @sTexto = '______ Fin Insercion de Ajustes ';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
			Set @sTexto = '______ Insercion de Ajustes Comparativo';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Insert Into @TablaTemporal
				Select
					C.IdRegistro * (-1)
					, C.Codigo +'-'+ C.Descripcion
					, '0' 
					, 'Ajustes'
					, CG.idGrupo
					, MG.Descripcion MGDescripcion
					, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
					, MCO.Descripcion MCODescripcion
					, CG.IdCuenta
					, CG.IdCuenta + '-' +MCU.Descripcion MCUDescripcion
					, @sPeriodoComparar
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
				From EERR_Tbl_Consolidados C
					, EERR_Tbl_Ajustes AJ
					, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
					, EERR_Tbl_Maestro_Grupos MG
					, EERR_Tbl_Maestro_Conceptos MCO
					, EERR_Tbl_Maestro_Cuentas MCU
				Where 1=1
					--
					And C.IdRegistro = @iIdConsolidadoComparar
					AND AJ.IdConsolidado = C.IdRegistro
					AND AJ.PeriodoAfectado = @sPeriodoComparar
					AND AJ.PeriodoVista in ( Select Periodo from @TablaPeriodos)
					AND MCO.Tipo in (0,1)
					--
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta
					--
					And CG.IdCuenta = AJ.IdCuenta
			Set @sTexto = '______ Fin Insercion de Ajustes Comparativo';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		Set @sTexto = '____ Fin Extraccion de Ajustes Consolidado';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		--
		Set @sTexto = '______ Inserta registros de saldos';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
			Insert Into @TablaTemporal
					Select
						C.IdRegistro
						, C.Codigo + '-' + C.Descripcion
						, SC.IdCompania 
						, SC.IdCompania + '-' + CO.Nombre
						, CG.idGrupo
						, MG.Descripcion MGDescripcion
						, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
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
						--And (SC.Credito - SC.Debito) <> 0
						--
						And CG.IdConsolidado = C.IdRegistro
						And CG.IdGrupo = MG.Codigo
						And CG.IdConcepto = MCO.Codigo
						And CG.IdCuenta = MCU.IdCuenta
						And SC.IdCompania = CO.IdCompania
						And SC.IdCuenta = MCU.IdCuenta
			Set @sTexto = '______ Fin Insercion de Saldos ';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
			Set @sTexto = '______ Insercion de Saldos Comparativo';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;							
			Insert Into @TablaTemporal
					Select
						C.IdRegistro * (-1)
						, C.Codigo + '-' + C.Descripcion
						, SC.IdCompania 
						, SC.IdCompania + '-' + CO.Nombre
						, CG.idGrupo
						, MG.Descripcion MGDescripcion
						, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
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
					From EERR_Tbl_Consolidados C
						, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
						, EERR_Tbl_Maestro_Grupos MG
						, EERR_Tbl_Maestro_Conceptos MCO
						, EERR_Tbl_Maestro_Cuentas MCU
						, EERR_Tbl_Saldos_Contables SC
						, EERR_Tbl_Companias CO
					Where 1=1
						AND C.IdRegistro = @iIdConsolidadoComparar
						AND CO.IdCompania in ( SELECT codigo FROM EERR_Tbl_Consolidados where idPadre = @iIdConsolidadoComparar and TipoNodo = 2 )
						AND SC.Periodo = @sPeriodoComparar
						AND SC.Libro in ( Select Libro from @TablaLibros )
						AND MCO.Tipo in (0,1)
						--And (SC.Credito - SC.Debito) <> 0
						--
						And CG.IdConsolidado = C.IdRegistro
						And CG.IdGrupo = MG.Codigo
						And CG.IdConcepto = MCO.Codigo
						And CG.IdCuenta = MCU.IdCuenta
						And SC.IdCompania = CO.IdCompania
						And SC.IdCuenta = MCU.IdCuenta
			Set @sTexto = '____ Fin Inserta saldos de las empresas del consolidado ';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		--	Extraccion de datos acumulados para consolidados Anidados
		Set @sTexto = '____ Llamado extraccion de saldos de consolidados anidados';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
			-- Creacion de un token para las transacciones
			--Set @sToken = convert(varchar, getdate(), 121);
			Set @sToken = convert(varchar(24), ROUND(CAST(CAST(GETUTCDATE() AS FLOAT)*8.64e8 AS BIGINT),-1)*1000+599266080000000000);
			Set @sTexto = '_____ Token creado {' + @sToken +'}';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			-- Saldos y Ajustes Consolidado Inicial
			Set @sTexto = '_____ Codigo Consolidado a buscar como padre {' + CONVERT(varchar, @iIdConsolidado) +'}';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
			Set @curAnidados = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
				Select CodigoReferenciado, Codigo, Descripcion, idRegistro From EERR_Tbl_Consolidados Where idPadre = @iIdConsolidado And TipoNodo = 1;
			Open @curAnidados;
			Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdRegistroOrg
			While @@FETCH_STATUS = 0
				Begin
					-- Prevalidacion de anidado a enviar
					Set @iIdAnidado = case when @iIdAnidado = 0 then @iIdRegistroOrg else @iIdAnidado end 
					
					-- Llamado al recursivo
					Execute @iRetVal = EERR_Sp_Reporte_ESFSuper_Recursivo_ExtraeSaldosyAjustes @sToken, @iIdAnidado, @sPeriodo, @sLibros, '______';
					If @iRetVal = 1 
						Begin
							Set @sTexto = '____ Devolvio Error';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Return @iRetVal;
						End;
					-- Insertamos todas los Saldos que extrajo del consolidado
					Set @sTexto = '____ Inserta Saldos';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Insert Into @TablaTemporal
						Select  
							@iIdConsolidado, @sCodigoConsolidado + '-' + @sDescripcionConsolidado, @sCodigoAnidado, @sCodigoAnidado +'-' + @sDescripcionAnidado, 
							idGrupo, DescripcionGrupo, idConcepto, DescripcionConcepto, idCuenta, DescripcionCuenta, idPeriodo, Valor, FlagImprime, 
							FlagPatrimonio, DescripcionFlag
						From EERR_Tmp_Token_ESF Where Token = @sToken;
					-- Insertamos los Ajustes del consolidado
					Set @sTexto = '____ Inserta Ajustes';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Insert into @TablaTemporal
						Select
							@iIdConsolidado
							, (Select Codigo + '-' + Descripcion From EERR_Tbl_Consolidados Where idRegistro = @iIdConsolidado )
							, (Select Codigo From EERR_Tbl_Consolidados Where idRegistro = @iIdAnidado )
							, (Select Codigo + '-' + Descripcion From EERR_Tbl_Consolidados Where idRegistro = @iIdAnidado )
							, CG.idGrupo
							, MG.Descripcion MGDescripcion
							, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
							, MCO.Descripcion MCODescripcion
							, CG.IdCuenta
							, CG.IdCuenta + '-' +MCU.Descripcion MCUDescripcion
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
							--
							And CG.IdCuenta = AJ.IdCuenta
					Delete EERR_Tmp_Token_ESF Where Token = @sToken;
					--
					Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdRegistroOrg
				End;
			Close @curAnidados; 
			Deallocate @curAnidados;
			-- Saldos y Ajustes Consolidado Comparar
			Delete EERR_Tmp_Token_ESF Where Token = @sToken;
			Set @sTexto = '_____ Limpiamos data y extraemos comparativa';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
			Set @sTexto = '_____ Codigo Consolidado a buscar como padre comparativo {' + CONVERT(varchar,  @iIdConsolidadoComparar) +'}';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
			Set @curAnidados = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
				Select CodigoReferenciado, Codigo, Descripcion, idRegistro From EERR_Tbl_Consolidados
				 Where idPadre = @iIdConsolidadoComparar And TipoNodo = 1;
			Open @curAnidados;
			Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdRegistroOrg
			While @@FETCH_STATUS = 0
				Begin
					-- Prevalidacion de anidado a enviar
					Set @iIdAnidado = case when @iIdAnidado = 0 then @iIdRegistroOrg else @iIdAnidado end 
				
					-- Llamado al recursivo
					Execute @iRetVal = EERR_Sp_Reporte_ESFSuper_Recursivo_ExtraeSaldosyAjustes_Comparativo @sToken, @iIdAnidado, @sPeriodoComparar, @sPeriodo, @sLibros, '______';
					If @iRetVal = 1 
						Begin
							Set @sTexto = '____ Devolvio Error';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Return @iRetVal;
						End;
					-- Insertamos todas los Saldos que extraje del consolidado
					Insert Into @TablaTemporal
						Select  
							@iIdConsolidadoComparar * (-1), @sCodigoConsolidadoComparar + '-' + @sDescripcionConsolidadoComparar, 
							@sCodigoAnidado, @sCodigoAnidado +'-' + @sDescripcionAnidado, idGrupo, DescripcionGrupo, idConcepto
							, DescripcionConcepto, idCuenta, DescripcionCuenta, idPeriodo, Valor, FlagImprime, FlagPatrimonio, DescripcionFlag
						From EERR_Tmp_Token_ESF Where Token = @sToken;
					-- Insertamos los Ajustes del consolidado
					Insert into @TablaTemporal
								Select
									@iIdConsolidadoComparar * (-1)
									, (Select Codigo + '-' + Descripcion From EERR_Tbl_Consolidados Where idRegistro = @iIdConsolidadoComparar )
									, (Select Codigo From EERR_Tbl_Consolidados Where idRegistro = @iIdAnidado )
									, (Select Codigo + '-' + Descripcion From EERR_Tbl_Consolidados Where idRegistro = @iIdAnidado )
									, CG.idGrupo
									, MG.Descripcion MGDescripcion
									, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
									, MCO.Descripcion MCODescripcion
									, CG.IdCuenta
									, CG.IdCuenta + '-' +MCU.Descripcion MCUDescripcion
									, @sPeriodoComparar
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
									AND AJ.PeriodoAfectado = @sPeriodoComparar
									AND AJ.PeriodoVista in ( Select Periodo from @TablaPeriodos)
									AND MCO.Tipo in (0,1)
									--
									And CG.IdConsolidado = C.IdRegistro
									And CG.IdGrupo = MG.Codigo
									And CG.IdConcepto = MCO.Codigo
									And CG.IdCuenta = MCU.IdCuenta
									--
									And CG.IdCuenta = AJ.IdCuenta
					Delete EERR_Tmp_Token_ESF Where Token = @sToken;
					--
					Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdRegistroOrg
				End;
			Close @curAnidados; 
			Deallocate @curAnidados;
		--
		Set @sTexto = '____ Fin Inserta saldos de Consolidados anidados Compara';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		-- Agrega todos los conceptos
			-- Consolidado
			Insert Into @TablaTemporal
				Select 
					  @iIdConsolidado, '', 0, ''
					, CGCC.IdGrupo, MGR.Descripcion
					, Right( '00' + convert(varchar,MCO.Orden), 2) + MCO.Codigo, MCO.Descripcion
					, CGCC.IdCuenta, ''
					, @sPeriodo, 0
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
				From 
					  EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CGCC
					, EERR_Tbl_Maestro_Conceptos MCO
					, EERR_Tbl_Maestro_Cuentas MCU
					, EERR_Tbl_Maestro_Grupos MGR
				Where 1 = 1
				And CGCC.IdConsolidado in (	@iIdConsolidado )
				And MCO.Codigo = CGCC.IdConcepto
				And MCU.IdCuenta = CGCC.IdCuenta
				And MGR.Codigo = CGCC.IdGrupo
				And Right( '00' + convert(varchar,MCO.Orden), 2) + MCO.Codigo not in (
									Select Distinct IdConcepto
									From @TablaTemporal
									Where idConsolidado = @iIdConsolidado
										)
				AND MCO.Tipo in (0,1)
				Order By CGCC.IdConsolidado, CGCC.IdGrupo, CGCC.IdConcepto, CGCC.IdCuenta
			-- Fin Consolidado
			-- Comparativo
			Insert Into @TablaTemporal
				Select 
					  @iIdConsolidadoComparar * (-1), '', 0, ''
					, CGCC.IdGrupo, MGR.Descripcion
					, Right( '00' + convert(varchar,MCO.Orden), 2) + MCO.Codigo, MCO.Descripcion
					, CGCC.IdCuenta, ''
					, @sPeriodo, 0
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
				From 
					  EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CGCC
					, EERR_Tbl_Maestro_Conceptos MCO
					, EERR_Tbl_Maestro_Cuentas MCU
					, EERR_Tbl_Maestro_Grupos MGR
				Where 1 = 1
				And CGCC.IdConsolidado in (	@iIdConsolidadoComparar )
				And MCO.Codigo = CGCC.IdConcepto
				And MCU.IdCuenta = CGCC.IdCuenta
				And MGR.Codigo = CGCC.IdGrupo
				And Right( '00' + convert(varchar,MCO.Orden), 2) + MCO.Codigo not in (
									Select Distinct IdConcepto
									From @TablaTemporal
									Where idConsolidado = @iIdConsolidadoComparar * (-1)
										)
				AND MCO.Tipo in (0,1)
				Order By CGCC.IdConsolidado, CGCC.IdGrupo, CGCC.IdConcepto, CGCC.IdCuenta
			-- Fin Comparativo
		-- Fin Agrega conceptos
		--
		Set @sTexto = '____ Transformacion en dos columnas';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Set @curRegistros = Cursor LOCAL STATIC READ_ONLY FORWARD_ONLY  For
				Select 
					  IdConsolidado
					, IdGrupo
					, DescripcionGrupo
					, IdConcepto
					, DescripcionConcepto
					, Valor
					, FlagImprime
					, FlagPatrimonio
					, DescripcionFlag
					, idCuenta
					From @TablaTemporal
					Order by idConsolidado, idCompania, IdGrupo, IdConcepto
			Open @curRegistros;
			Fetch Next From @curRegistros Into 
					  @iIdConsolidadoX
					, @sIdGrupoX
					, @sDescripcionGrupoX
					, @sIdConceptoX
					, @sDescripcionConceptoX
					, @nValorX
					, @iFlagImprimeX
					, @sFlagPatrimonioX
					, @sDescripcionFlagX
					, @sIdCuentaX
			While @@FETCH_STATUS = 0
				Begin
					Set @iSoloAjuste = 
									( Select FlagSoloAjuste From EERR_Tbl_Maestro_Cuentas Where IdCuenta = @sIdCuentaX );
					If @iFlagImprimeX = 1 OR ( @iFlagImprimeX = 0 And @nValorX <> 0 And @iSoloAjuste = 0)
						Begin
							Select @iCuenta = COUNT(0) 
								From @TablaReporte
								Where 1 = 1
									And IdPatrimonio = @sFlagPatrimonioX
									And IdGrupo = @sIdGrupoX
									And IdConcepto = @sIdConceptoX
							If @iCuenta > 0
								Begin
									If @iIdConsolidadoX > 0
										Begin
											Update @TablaReporte Set
												Valor1 = Valor1 + @nValorX
											Where 1 = 1
												And IdPatrimonio = @sFlagPatrimonioX
												And IdGrupo = @sIdGrupoX
												And IdConcepto = @sIdConceptoX
										End;
									Else
										Begin
											Update @TablaReporte Set
												Valor2 = Valor2 + @nValorX
											Where 1 = 1
												And IdPatrimonio = @sFlagPatrimonioX
												And IdGrupo = @sIdGrupoX
												And IdConcepto = @sIdConceptoX
										End;
								End;
							Else
								Begin
									If @iIdConsolidadoX > 0
										Begin
											Insert Into @TablaReporte
											Values
											(
												  @sFlagPatrimonioX
												, @sIdGrupoX
												, @sIdConceptoX
												, @nValorX
												, 0
												, @sDescripcionFlagX
												, @sDescripcionGrupoX
												, @sDescripcionConceptoX
												, @sPeriodo
												, @sPeriodoComparar
												, '', ''
											)
										End;
									Else
										Begin
											Insert Into @TablaReporte
											Values
											(
												  @sFlagPatrimonioX
												, @sIdGrupoX
												, @sIdConceptoX
												, 0
												, @nValorX
												, @sDescripcionFlagX
												, @sDescripcionGrupoX
												, @sDescripcionConceptoX
												, @sPeriodo
												, @sPeriodoComparar
												, '', ''
											)
										End;
								End;
						End;
					Fetch Next From @curRegistros Into 
							  @iIdConsolidadoX
							, @sIdGrupoX
							, @sDescripcionGrupoX
							, @sIdConceptoX
							, @sDescripcionConceptoX
							, @nValorX
							, @iFlagImprimeX
							, @sFlagPatrimonioX
							, @sDescripcionFlagX
							, @sIdCuentaX
				End;		
		Set @sTexto = '____ Fin Transformacion en dos columnas';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;

		-- Obtencion de Nombre de compañia martiz para usar como nombre de reporte
		Select @sTituloReporte = Nombre
		From EERR_Tbl_Companias 
		where IdCompania = (
			Select Codigo
			From EERR_Tbl_Consolidados
			where 1= 1
			and IdPadre = @iIdConsolidado	
			and IndicadorMatriz = 1
		)

		-- Actualiza FlagSumaESF
		Update TR Set 
				TR.FlagSumaESF = MCO.FlagSumaESF
			From @TablaReporte TR
			Inner Join EERR_Tbl_Maestro_Conceptos MCO 
			on 
				Right( '00' + convert(varchar,MCO.Orden), 2) + MCO.Codigo = TR.idConcepto
		
		-- Generacion de lineas de subtotales parciales
		Set @sCortePatrimonio = '';
		Set @sCorteGrupo = '';
		Set @sCorteFlagSumaESF = '';		
		Set @nCorteTotales1 = 0;
		Set @nCorteTotales2 = 0;
		
		Set @curCorte = Cursor LOCAL STATIC READ_ONLY FORWARD_ONLY  For
			Select idPatrimonio, idGrupo, IdConcepto, FlagSumaESF, Valor1, Valor2
			From @TablaReporte
			Order By idPatrimonio, idGrupo, IdConcepto
		Open @curCorte;
		Fetch Next From @curCorte Into @sCicloPatrimonio, @sCicloGrupo, @sCicloConcepto, @sCicloFlagSumaESF, @nCicloValor1, @nCicloValor2
		If @sCortePatrimonio = '' 
		Begin
			Set @sCortePatrimonio = @sCicloPatrimonio;
			Set @sCorteGrupo = @sCicloGrupo;
			Set @sCorteFlagSumaESF = @sCicloFlagSumaESF;
			Set @nCorteTotales1 = 0;
			Set @nCorteTotales2 = 0;
		End;
		While @@FETCH_STATUS = 0
		Begin
--print 'Patrimonio:'+ @sCicloPatrimonio
--		+' Grupo:'+ @sCicloGrupo
--		+' Concepto:'+ @sCicloConcepto
--		+' Flag:'+ @sCicloFlagSumaESF
--		+' Valor1:'+ convert(varchar, @nCicloValor1)
--		+' Valor2:'+ convert(varchar, @nCicloValor2);
			--If @sCorteFlagSumaESF != @sCicloFlagSumaESF
			--Begin
				If @sCicloFlagSumaESF = '1'
					Begin
						Insert Into @TablaReporte 
								( IdPatrimonio, IdGrupo, FlagSumaESF, IdConcepto, Valor1, Valor2, DescripcionConcepto )
								Values 
								( @sCicloPatrimonio, @sCicloGrupo, 0, '99999999', @nCorteTotales1, @nCorteTotales2, @sCicloPatrimonio + 'Totales' )
						Set @sCortePatrimonio = @sCicloPatrimonio;
						Set @sCorteGrupo = @sCicloGrupo;
						Set @nCorteTotales1 = 0;
						Set @nCorteTotales2 = 0;
					End;
				Else
					Begin
						--Set @sCorteFlagSumaESF = @sCicloFlagSumaESF;
						If @sCorteGrupo != @sCicloGrupo
						Begin
							Set @sCorteGrupo = @sCicloGrupo;
							Set @nCorteTotales1 = 0;
							Set @nCorteTotales2 = 0;

							If @sCortePatrimonio != @sCicloPatrimonio
							Begin
								Set @sCortePatrimonio = @sCicloPatrimonio;
								Set @nCorteTotales1 = 0;
								Set @nCorteTotales2 = 0;
							End;
						End;

						Set @nCorteTotales1 = @nCorteTotales1 + @nCicloValor1;
						Set @nCorteTotales2 = @nCorteTotales2 + @nCicloValor2;

					End;

			--End;
			Fetch Next From @curCorte Into @sCicloPatrimonio, @sCicloGrupo, @sCicloConcepto, @sCicloFlagSumaESF, @nCicloValor1, @nCicloValor2
		End;
		Close @curCorte;
		Deallocate @curCorte;

Declare @dSumaFlag1 as numeric(25,0);
Declare @dSumaFlag2 as numeric(25,0);

Select @dSumaFlag1 = SUM(Valor1)
		, @dSumaFlag2 = SUM(Valor2)
	From @TablaReporte TR
	Where 1=1
	And TR.idPatrimonio = 'AC'
	And TR.idGrupo = '3'
	And TR.FlagSumaESF = '1'
group by TR.idPatrimonio, TR.idGrupo, TR.FlagSumaESF

Insert Into @TablaReporte
	Select 
			  'AC'
			, '3'
			, '99999999'
			, @dSumaFlag1
			,  @dSumaFlag2
			, 'Activos'
			, 'Activos corrientes'
			, '-'
			, @sPeriodo
			, @sPeriodoComparar
			, ''
			, '1'
 
		-- Desplegamos el resultado para el reporte
		Select 
			  TR.idPatrimonio
			, TR.idGrupo
			, TR.idConcepto
			, TR.Valor1
			, TR.Valor2
			, TR.DescripcionPatrimonio
			, TR.DescripcionGrupo
			, TR.DescripcionConcepto
			, TR.idPeriodo1
			, TR.idPeriodo2
			, @sTituloReporte as DescripcionConsolidado
			, TR.FlagSumaESF 
		From @TablaReporte TR
		Order by idPatrimonio, idGrupo, FlagSumaESF, idConcepto
		--
		--
		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_LINE()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;
print @sErr
		Return (1);
	End Catch
End;
