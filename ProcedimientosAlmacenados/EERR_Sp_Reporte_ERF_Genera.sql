--Use CONSOLIDADO_EERR_DESARROLLO
--Use CONSOLIDADO_EERR_PRODUCCION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( '[EERR_Sp_Reporte_ERF_Genera]', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Reporte_ERF_Genera;
GO

CREATE PROCEDURE EERR_Sp_Reporte_ERF_Genera
	  @iIdConsolidado as int
	, @sPeriodo as varchar(6)
	, @iIdConsolidadoComparar as int
	, @sPeriodoComparar as varchar(6)
	, @sLibros as Varchar(100)
AS

Declare @iRetVal as int;
Declare @sName AS Varchar(100);
Declare @sTexto as nVarchar(500);
--
Declare @sDescripcionConsolidado as varchar(100);
Declare @sDescripcionConsolidadoComparar as varchar(100);
Declare @sCodigoConsolidado as varchar(18);
Declare @sCodigoConsolidadoComparar as varchar(18);
Declare @sPer as Varchar(20);
--
Declare @sToken as Varchar(24);
Declare @iIdAnidado as int;
Declare @sCodigoAnidado as varchar(18);
Declare @sDescripcionAnidado as Varchar(100);
Declare @iIdAnidadoOrg as int;
--
--
Declare @iIdConsolidadoRellena as int;
Declare @sIdCompaniaRellena as varchar(18);
--
Declare @iConsolidadoSubtotal as int;
Declare @sidCompaniaSubtotal as varchar(18);
Declare @sCodigoGrupoSubtotal as varchar(4);
Declare @sCodigoConceptoSubtotal as varchar(10);
Declare @sIdPeriodoSubtotal as varchar(6);
Declare @sDescripcionCompaniaSubTotal as Varchar(100);
Declare @sDescripcionGrupoSubTotal as varchar(200);
Declare @sDescripcionConsolidadoSubTotal varchar(100);
Declare @iFlagSubTotal as int;
--
Declare @iConsolidadoSubtotalCorte as int;
Declare @sidCompaniaSubtotalCorte as varchar(18);
Declare @sCodigoGrupoSubtotalCorte as varchar(4);
Declare @sCodigoConceptoSubtotalCorte as varchar(10);
Declare @sIdPeriodoSubtotalCorte as varchar(6);
Declare @sDescripcionConsolidadoSubtotalCorte as varchar(100);
Declare @sDescripcionCompaniaSubTotalCorte as Varchar(100);
Declare @sDescripcionGrupoSubTotalCorte as varchar(200);
Declare @iFlagSubTotalCorte as int;
--
Declare @nValorSubtotal as Numeric(30);
Declare @nAcumSubtotal as Numeric(30);
--
--
--
--
--
--
--
--
--
--
--
--
-- Declaracion de cursores
Declare @AjustesCursor as Cursor;
Declare @SaldosCursor as Cursor;
Declare @curAnidados as Cursor;
Declare @curCompanias as Cursor;
Declare @curSumatoria as Cursor;
Declare @CurPeriodos as Cursor;
Declare @curRellena as Cursor;
--
Declare @TmpidConsolidado int;
Declare @TmpDescripcionConsolidado varchar(500)
Declare @TmpidCompania varchar(18)
Declare @TmpDescripcionCompania varchar(500)
Declare @TmpidGrupo varchar(4)
Declare @TmpDescripcionGrupo varchar(500)
Declare @TmpidConcepto varchar(10)
Declare @TmpDescripcionConcepto varchar(500)
Declare @TmpidCuenta varchar(8)
Declare @TmpDescripcionCuenta varchar(500)
Declare @TmpidPeriodo varchar(6)
Declare @TmpValor numeric(25)
Declare @TmpFlagImprime int
Declare @TmpTipo varchar(2)
--
-- Declaracion de variables temporales de tipo Tabla
Declare @TablaTemporal Table ( 
								idConsolidado int
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
							 );
--
--
--
--
--
--
--
--
--
--
--
--
Declare @TablaPeriodos Table ( Periodo varchar(6) );
--
--
BEGIN
	SET NOCOUNT ON;
	--
	Set @sName = 'EERR_Sp_Reporte_ERF_Genera';
	Select @sDescripcionConsolidado = Descripcion, @sCodigoConsolidado = Codigo From EERR_Tbl_Consolidados   Where IdRegistro = @iIdConsolidado;
	Select @sDescripcionConsolidadoComparar = Descripcion, @sCodigoConsolidadoComparar = Codigo From EERR_Tbl_Consolidados   Where idRegistro = @iIdConsolidadoComparar;
	--
	Set @sTexto = '__ Parametros Entrada';
	Set @sTexto = @sTexto + ' idConsolidado {' + Convert(varchar, @iIdConsolidado) + '}' ;
	Set @sTexto = @sTexto + ' Periodo {' + @sPeriodo + '}' ;
	Set @sTexto = @sTexto + ' idConsolidadoCompara {' + Convert(varchar, @iIdConsolidadoComparar) + '}' ;
	Set @sTexto = @sTexto + ' PeriodoCompara {' + @sPeriodoComparar + '}' ;
	Set @sTexto = @sTexto + ' Libros {' + @sLibros + '}' ;
	Execute EERR_sp_Log4Sql_Info @sName, @sTexto;

	Begin Try
		Set @sTexto = 'Inicio Proceso de Generacion de Reporte ERF';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		--
			-- Ejecutar la carga de ajustes automaticos para consolidado
			Execute EERR_Sp_Ajustes_Automaticos @iIdConsolidado, @sPeriodo, @sLibros;
			-- Ejecutar la carga de ajustes automaticos para consolidado a comparar
			Execute EERR_Sp_Ajustes_Automaticos @iIdConsolidadoComparar, @sPeriodoComparar, @sLibros;
			--
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
		Set @sTexto = '____ Inicio Extraccion de Ajustes';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
			Set @sTexto = '______ Insercion de Ajustes ';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Insert Into @TablaTemporal
				Select
					C.IdRegistro
					, C.Codigo +'-'+ C.Descripcion
					, '0' 
					, 'Ajustes de Consolidación'
					, MG.Tipo +  CG.IdGrupo
					, MG.Descripcion MGDescripcion
					, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
					, MCO.Descripcion MCODescripcion
					, CG.IdCuenta
					, rtrim(CG.IdCuenta) + '-' +MCU.Descripcion MCUDescripcion
					, @sPeriodo
					, Case When  CG.IdCuenta = 'ERF_NC' then (AJ.Debito - AJ.Credito)
						Else (AJ.Credito - AJ.Debito) 
						End Valor
					, MCU.FlagImprime
					, 'AJ'
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
					AND MCU.Tipo in ( '3I', '3E' )
					And CG.IdCuenta = AJ.IdCuenta
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta		
			Set @sTexto = '______ Fin Insercion de Ajustes ';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
			Set @sTexto = '______ Insercion de Ajustes Comparativo';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Insert Into @TablaTemporal
				Select
					C.IdRegistro * (-1)
					, C.Codigo +'-'+ C.Descripcion
					, Case when AJ.PeriodoAfectado = AJ.PeriodoVista
						Then '0' 
						Else '-1'
						End Compania
					, Case when AJ.PeriodoAfectado = AJ.PeriodoVista
						Then 'Ajustes de Consolidación'
						Else 'Reclasificaciones'
						End Compania					
					, MG.Tipo +  CG.IdGrupo
					, MG.Descripcion MGDescripcion
					, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
					, MCO.Descripcion MCODescripcion
					, CG.IdCuenta
					, rtrim(CG.IdCuenta) + '-' +MCU.Descripcion MCUDescripcion
					, @sPeriodoComparar
					, Case When  CG.IdCuenta = 'ERF_NC' then (AJ.Debito - AJ.Credito)
						Else (AJ.Credito - AJ.Debito) 
						End Valor
					, MCU.FlagImprime
					, 'AJ'
				From EERR_Tbl_Consolidados C
					, EERR_Tbl_Ajustes AJ
					, EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CG
					, EERR_Tbl_Maestro_Grupos MG
					, EERR_Tbl_Maestro_Conceptos MCO
					, EERR_Tbl_Maestro_Cuentas MCU
				Where 1=1
					And C.IdRegistro = @iIdConsolidadoComparar
					And AJ.IdConsolidado = C.IdRegistro
					And AJ.PeriodoAfectado = @sPeriodoComparar
					And AJ.PeriodoVista in ( Select Periodo from @TablaPeriodos)
					And MCU.Tipo in ( '3I', '3E' )
					And CG.IdCuenta = AJ.IdCuenta
					And CG.IdConsolidado = C.IdRegistro
					And CG.IdGrupo = MG.Codigo
					And CG.IdConcepto = MCO.Codigo
					And CG.IdCuenta = MCU.IdCuenta
			Set @sTexto = '______ Fin Insercion de Ajustes Comparativo';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
		Set @sTexto = '____ Fin Extraccion de Ajustes';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		--
		Set @sTexto = '____ Inserta registros saldos contables de las empresas del consolidado';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			-- Saldos de consolidado incial
			Set @sTexto = '____ Llama a EERR_Sp_Reporte_ERF_ExtraeSaldos';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			EXEC @iRetVal = EERR_Sp_Reporte_ERF_ExtraeSaldos @iIdConsolidado, @sPeriodo, @sLibros, '______', @CursorSaldos = @SaldosCursor OUTPUT;
			If @iRetVal = 1 
				Begin
					Set @sTexto = '____ Devolvio Error';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Return @iRetVal;
				End;
			--
			FETCH NEXT FROM @SaldosCursor into 
							@TmpidConsolidado, @TmpDescripcionConsolidado, @TmpidCompania, @TmpDescripcionCompania, @TmpidGrupo, @TmpDescripcionGrupo, 
							@TmpidConcepto, @TmpDescripcionConcepto, @TmpidCuenta, @TmpDescripcionCuenta, @TmpidPeriodo, @TmpValor, @TmpFlagImprime, @TmpTipo
			WHILE (@@FETCH_STATUS = 0)  
				BEGIN;  
					Insert Into @TablaTemporal
						Values 
							( @TmpidConsolidado , @TmpDescripcionConsolidado, @TmpidCompania, @TmpDescripcionCompania, @TmpidGrupo, @TmpDescripcionGrupo
							, @TmpidConcepto, @TmpDescripcionConcepto, @TmpidCuenta, @TmpDescripcionCuenta, @TmpidPeriodo, @TmpValor, @TmpFlagImprime, @TmpTipo)
					--
					FETCH NEXT FROM @SaldosCursor into 
								@TmpidConsolidado, @TmpDescripcionConsolidado, @TmpidCompania, @TmpDescripcionCompania, @TmpidGrupo, @TmpDescripcionGrupo
								, @TmpidConcepto, @TmpDescripcionConcepto, @TmpidCuenta, @TmpDescripcionCuenta, @TmpidPeriodo, @TmpValor, @TmpFlagImprime, @TmpTipo
				END;  
			CLOSE @SaldosCursor; 
			Deallocate @SaldosCursor;
			-- Saldos de consolidado Comparar
			Set @sTexto = '____ Llama a EERR_Sp_Reporte_ERF_ExtraeSaldos';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			EXEC @iRetVal = EERR_Sp_Reporte_ERF_ExtraeSaldos @iIdConsolidadoComparar, @sPeriodoComparar, @sLibros, '______', @CursorSaldos = @SaldosCursor OUTPUT;
			If @iRetVal = 1 
				Begin
					Set @sTexto = '____ Devolvio Error';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Return @iRetVal;
				End;
			--
			FETCH NEXT FROM @SaldosCursor into 
							@TmpidConsolidado, @TmpDescripcionConsolidado, @TmpidCompania, @TmpDescripcionCompania, @TmpidGrupo, @TmpDescripcionGrupo, 
							@TmpidConcepto, @TmpDescripcionConcepto, @TmpidCuenta, @TmpDescripcionCuenta, @TmpidPeriodo, @TmpValor, @TmpFlagImprime, @TmpTipo
			WHILE (@@FETCH_STATUS = 0)  
				BEGIN;  
					Insert Into @TablaTemporal
						Values 
							( @TmpidConsolidado * (-1), @TmpDescripcionConsolidado, @TmpidCompania, @TmpDescripcionCompania, @TmpidGrupo, @TmpDescripcionGrupo
							, @TmpidConcepto, @TmpDescripcionConcepto, @TmpidCuenta, @TmpDescripcionCuenta, @TmpidPeriodo, @TmpValor, @TmpFlagImprime, @TmpTipo)
					--
					FETCH NEXT FROM @SaldosCursor into 
								@TmpidConsolidado, @TmpDescripcionConsolidado, @TmpidCompania, @TmpDescripcionCompania, @TmpidGrupo, @TmpDescripcionGrupo
								, @TmpidConcepto, @TmpDescripcionConcepto, @TmpidCuenta, @TmpDescripcionCuenta, @TmpidPeriodo, @TmpValor, @TmpFlagImprime, @TmpTipo
				END;  
			CLOSE @SaldosCursor; 
			Deallocate @SaldosCursor;
		Set @sTexto = '____ Fin Inserta saldos de las empresas del consolidado';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		--
		Set @sTexto = '____ Extraccion de Saldos y Ajustes de consolidados anidados';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
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
				Select CodigoReferenciado, Codigo, Descripcion, idRegistro From EERR_Tbl_Consolidados  
				 Where idPadre = @iIdConsolidado And TipoNodo = 1;
			Open @curAnidados;
			Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdAnidadoOrg
			While @@FETCH_STATUS = 0
				Begin
					-- Prechequeo de id a enviar
					set @iIdAnidado = Case when @iIdAnidado = 0 then @iIdAnidadoOrg Else @iIdAnidado End;
					-- Llamado al recursivo
					Execute @iRetVal = EERR_Sp_Reporte_ERF_Recursivo_ExtraeSaldosyAjustes @sToken, @iIdAnidado, @sPeriodo, @sLibros, '______';
					If @iRetVal = 1 
						Begin
							Set @sTexto = '____ Devolvio Error';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Return @iRetVal;
						End;
					-- Insertamos todas los Saldos que extrajo del consolidado
					Set @sTexto = '_____ Insertamos los saldos que extrajo';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Insert Into @TablaTemporal
						Select  
							@iIdConsolidado, @sCodigoConsolidado + '-' + @sDescripcionConsolidado, @sCodigoAnidado, @sCodigoAnidado +'-' + @sDescripcionAnidado, 
							idGrupo, DescripcionGrupo, idConcepto, DescripcionConcepto, idCuenta, DescripcionCuenta, idPeriodo, Valor, FlagImprime, Tipo
						From EERR_Tmp_Token_ERF   Where Token = @sToken;
					-- Insertamos los Ajustes del consolidado
					Set @sTexto = '_____ Insertamos los Ajustes que extrajo';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Insert into @TablaTemporal
								Select
									  @iIdConsolidado
									, @sCodigoConsolidado + '-' + @sDescripcionConsolidado
									, @sCodigoAnidado
									, @sCodigoAnidado +'-' + @sDescripcionAnidado
									, MG.Tipo +  CG.IdGrupo
									, MG.Descripcion MGDescripcion
									, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
									, MCO.Descripcion MCODescripcion
									, CG.IdCuenta
									, rtrim(CG.IdCuenta) + '-' +MCU.Descripcion MCUDescripcion
									, @sPeriodo
									, Case When  CG.IdCuenta = 'ERF_NC' then (AJ.Debito - AJ.Credito)
										Else (AJ.Credito - AJ.Debito) 
										End Valor
									, MCU.FlagImprime
									, 'AA'
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
									And CG.IdCuenta = AJ.IdCuenta
									--
									And CG.IdConsolidado = C.IdRegistro
									And CG.IdGrupo = MG.Codigo
									And CG.IdConcepto = MCO.Codigo
									And CG.IdCuenta = MCU.IdCuenta
					Delete EERR_Tmp_Token_ERF Where Token = @sToken;
					--
					Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdAnidadoOrg
				End;
			Close @curAnidados; 
			Deallocate @curAnidados;
			-- Saldos y Ajustes Consolidado Comparar
			Delete EERR_Tmp_Token_ERF Where Token = @sToken;
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
			Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdAnidadoOrg
			While @@FETCH_STATUS = 0
				Begin
					-- Prechequeo de id a enviar
					set @iIdAnidado = Case when @iIdAnidado = 0 then @iIdAnidadoOrg Else @iIdAnidado End;
					-- Llamado al recursivo
					Execute @iRetVal = EERR_Sp_Reporte_ERF_Recursivo_ExtraeSaldosyAjustes_Comparativo @sToken, @iIdAnidado, @sPeriodoComparar, @sPeriodo, @sLibros, '______';
					If @iRetVal = 1 
						Begin
							Set @sTexto = '____ Devolvio Error';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Return @iRetVal;
						End;
					-- Insertamos todas los Saldos que extraje del consolidado
					Set @sTexto = '_____ Insertamos los saldos que extrajo';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Insert Into @TablaTemporal
						Select  
							@iIdConsolidadoComparar * (-1)
							, @sCodigoConsolidadoComparar + '-' + @sDescripcionConsolidadoComparar
							, @sCodigoAnidado
							, @sCodigoAnidado +'-' + @sDescripcionAnidado
							, idGrupo
							, DescripcionGrupo
							, idConcepto
							, DescripcionConcepto
							, idCuenta
							, DescripcionCuenta
							, idPeriodo
							, Valor
							, FlagImprime
							, Tipo
						From EERR_Tmp_Token_ERF
						Where Token = @sToken;
					-- Insertamos los Ajustes del consolidado
					Set @sTexto = '_____ Insertamos los ajustes que extrajo';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					Insert into @TablaTemporal
							Select
								  @iIdConsolidadoComparar * (-1)
								, @sCodigoConsolidadoComparar + '-' + @sDescripcionConsolidadoComparar
								, @sCodigoAnidado
								, @sCodigoAnidado +'-' + @sDescripcionAnidado
								, MG.Tipo +  CG.IdGrupo
								, MG.Descripcion MGDescripcion
								, Right( '00' + convert(varchar,MCO.Orden), 2) + CG.IdConcepto
								, MCO.Descripcion MCODescripcion
								, CG.IdCuenta
								, rtrim(CG.IdCuenta) + '-' +MCU.Descripcion MCUDescripcion
								, @sPeriodoComparar
								, Case When  CG.IdCuenta = 'ERF_NC' then (AJ.Debito - AJ.Credito)
									Else (AJ.Credito - AJ.Debito) 
									End Valor
								, MCU.FlagImprime
								, 'aa'
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
								AND MCU.Tipo in ( '3I', '3E' )
								And CG.IdCuenta = AJ.IdCuenta
								--
								And CG.IdConsolidado = C.IdRegistro
								And CG.IdGrupo = MG.Codigo
								And CG.IdConcepto = MCO.Codigo
								And CG.IdCuenta = MCU.IdCuenta
					Delete EERR_Tmp_Token_ERF Where Token = @sToken;
					--
					Fetch Next From @curAnidados Into @iIdAnidado, @sCodigoAnidado, @sDescripcionAnidado, @iIdAnidadoOrg
				End;
			Close @curAnidados; 
			Deallocate @curAnidados;
			--
		Set @sTexto = '____ Fin Extraccion Saldos y Ajustes de consolidados anidados';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		--
		-- extraccion de todas las cuentas contables de la @TablaTemporal para completar para todas las empresas y ajustes
		Set @sTexto = '____ Relleno de registros con grupo/concepto/cuenta que faltan';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			----
			----
			Set @curRellena = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR 
				Select IdConsolidado, IdCompania
					From @TablaTemporal
					Group BY IdConsolidado, IdCompania
					Order By IdConsolidado, IdCompania
			Open @curRellena;
			Fetch Next From @curRellena Into @iIdConsolidadoRellena, @sIdCompaniaRellena
			While @@FETCH_STATUS = 0
				Begin
					-- Consolidado
					Insert Into @TablaTemporal
						Select 						
							  @iIdConsolidadoRellena
							, (Select Distinct DescripcionConsolidado From @TablaTemporal   Where idConsolidado = @iIdConsolidadoRellena ) Cdes
							, @sIdCompaniaRellena
							, (Select Distinct DescripcionCompania From @TablaTemporal   Where idConsolidado = @iIdConsolidadoRellena And IdCompania = @sIdCompaniaRellena ) DCOmpania
							, MGR.Tipo +  MGR.Codigo
							, MGR.Descripcion MGDescripcion
							, Right( '00' + convert(varchar,MCO.Orden), 2) + MCO.Codigo
							, MCO.Descripcion MCODescripcion
							, CGCC.IdCuenta
							, MCU.Descripcion
							, (Select Distinct IdPeriodo From @TablaTemporal   Where idConsolidado = @iIdConsolidadoRellena ) IPeriodo
							, 0 Valor
							, MCU.FlagImprime
							, 'RE'						
						From
							  EERR_TbT_Consolidado_Grupo_Concepto_Cuenta CGCC 
							, EERR_Tbl_Maestro_Conceptos MCO 
							, EERR_Tbl_Maestro_Cuentas MCU 
							, EERR_Tbl_Maestro_Grupos MGR 
						Where 1 = 1
							And CGCC.IdConsolidado in ( Case When @iIdConsolidadoRellena < 0 Then @iIdConsolidadoRellena * (-1) Else @iIdConsolidadoRellena End )
							And MCO.Codigo = CGCC.IdConcepto
							And MCU.IdCuenta = CGCC.IdCuenta
							And MGR.Codigo = CGCC.IdGrupo
							And MCU.flagSoloAjuste = 0
							And MCU.Tipo in ( '3I', '3E' )
						Order By CGCC.IdConsolidado, CGCC.IdGrupo, CGCC.IdConcepto, CGCC.IdCuenta
					-- Fin Consolidado
					Fetch Next From @curRellena Into @iIdConsolidadoRellena, @sIdCompaniaRellena
				End;
			Close @curRellena; 
			Deallocate @curRellena;
			----
			----
		-- Fin Agrega conceptos
		Set @sTexto = '____ Fin Relleno de registros con grupo/concepto/cuenta que faltan';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		-- Generacion de subtotales con arrastre
		Set @sTexto = '____ Generacion de subtotales ';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			--
			Set @iConsolidadoSubtotalCorte = 0;
			Set @sidCompaniaSubtotalCorte = '';
			Set @sCodigoGrupoSubtotalCorte = '';
			Set @sCodigoConceptoSubtotalCorte = '';
			Set @sIdPeriodoSubtotalCorte = '';
			Set @sDescripcionConsolidadoSubtotalCorte = '';
			Set @sDescripcionCompaniaSubTotalCorte = '';
			Set @sDescripcionGrupoSubTotalCorte = '';
			Set @iFlagSubTotalCorte = 0;
			Set @nAcumSubtotal = 0;
			--
			Set @curSumatoria = Cursor LOCAL STATIC READ_ONLY FORWARD_ONLY  For
				Select 
					idConsolidado, idPeriodo, idCompania, idGrupo,  Valor
					, DescripcionConsolidado, DescripcionCompania, DescripcionGrupo, FlagImprime
				From @TablaTemporal  
				Where 1=1
					--And FlagImprime = 1
					And idCuenta not like '%ERF%'
				--Group by idConsolidado, idPeriodo, idCompania, idGrupo, DescripcionConsolidado, DescripcionCompania, DescripcionGrupo
				Order By idConsolidado, idPeriodo, idCompania, idGrupo
			Open @curSumatoria;
			Fetch Next From @curSumatoria Into 
											  @iConsolidadoSubtotal
											, @sIdPeriodoSubtotal
											, @sidCompaniaSubtotal
											, @sCodigoGrupoSubtotal
											, @nValorSubtotal
											, @sDescripcionConsolidadoSubTotal
											, @sDescripcionCompaniaSubTotal
											, @sDescripcionGrupoSubTotal
											, @iFlagSubTotal
			While @@FETCH_STATUS = 0
			Begin			
				Set @sTexto = '______ Dentro de ciclo de sumatoria ';
				Set @sTexto = @sTexto + '	IdConsolidado {' + convert(varchar,  @iConsolidadoSubtotal ) + '}';
				Set @sTexto = @sTexto + '	Periodo {' + @sIdPeriodoSubtotal + '}';
				Set @sTexto = @sTexto + '	iDCompania {' + @sidCompaniaSubtotal + '}';
				Set @sTexto = @sTexto + '	Grupo {' + @sCodigoGrupoSubtotal + '}';
				Set @sTexto = @sTexto + '	Periodo {' + @sIdPeriodoSubtotal + '}';
				Set @sTexto = @sTexto + '	Valor {' + convert(varchar, @nValorSubtotal) + '}';
				Set @sTexto = @sTexto + '	DCons {' + convert(varchar, @sDescripcionConsolidadoSubTotal) + '}';
				Set @sTexto = @sTexto + '	DCom {' + convert(varchar, @sDescripcionCompaniaSubTotal) + '}';
				Set @sTexto = @sTexto + '	DGru {' + convert(varchar, @sDescripcionGrupoSubTotal) + '}';				
				Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
				--
				If @sCodigoGrupoSubtotalCorte = ''
					Begin
						Set @iConsolidadoSubtotalCorte = @iConsolidadoSubtotal;
						Set @sidCompaniaSubtotalCorte = @sidCompaniaSubtotal;
						Set @sCodigoGrupoSubtotalCorte = @sCodigoGrupoSubtotal;
						Set @sCodigoConceptoSubtotalCorte = @sCodigoConceptoSubtotal;
						Set @sidCompaniaSubtotalCorte = @sidCompaniaSubtotal;
						Set @sIdPeriodoSubtotalCorte = @sIdPeriodoSubtotal;
						Set @sDescripcionConsolidadoSubtotalCorte = @sDescripcionConsolidadoSubTotal;
						Set @sDescripcionCompaniaSubTotalCorte = @sDescripcionCompaniaSubTotal;
						Set @sDescripcionGrupoSubTotalCorte = @sDescripcionGrupoSubTotal;
						Set @iFlagSubTotalCorte = @iFlagSubTotal;
						Set @nAcumSubtotal = 0;
					End;
				--
				If @sCodigoGrupoSubtotal != @sCodigoGrupoSubtotalCorte
				Begin
					Set @sTexto = '____________ Cambia Grupo ';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					--
					Set @sTexto = '______________ Inserta el Subtotal manual para anterior';
					Set @sTexto += ' Consolidado {'    + convert( varchar(10), @iConsolidadoSubtotalCorte) + '}';
					Set @sTexto += ' Descripcion Consolidado {' + @sDescripcionConsolidadoSubtotalCorte+ '}';
					Set @sTexto += ' Compania {'       + @sidCompaniaSubtotalCorte + '}';
					Set @sTexto += ' Descripcion Compania {'    + isnull(@sDescripcionCompaniaSubTotalCorte, '') + '}';
					Set @sTexto += ' Grupo {'          + @sCodigoGrupoSubtotalCorte + '}';
					Set @sTexto += ' Desgrupo {'       + @sDescripcionGrupoSubTotalCorte + '}';
					Set @sTexto += ' Concepto {'       + '9999999999}';
					Set @sTexto += ' DesConcepto {'    + 'Total ' + @sDescripcionGrupoSubTotalCorte +'}';
					Set @sTexto += ' Cuenta {'         + '99999999}';
					Set @sTexto += ' DesCuenta {'      + '.}';
					Set @sTexto += ' Periodo {'        + @sIdPeriodoSubtotalCorte + '}';
					Set @sTexto += ' Valor {'          + Convert(varchar(30), @nAcumSubtotal) + '}';
					Set @sTexto += ' flag {'           + Convert(varchar,@iFlagSubTotalCorte) +'}';
					Set @sTexto += ' Tipo {'           + 'ST}';
					Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
					----
						Insert Into @TablaTemporal (
								idConsolidado, DescripcionConsolidado, idCompania, DescripcionCompania, idGrupo, DescripcionGrupo, 
								idConcepto, DescripcionConcepto, idCuenta, DescripcionCuenta, idPeriodo, Valor, FlagImprime, Tipo
								)
						 Values (
								@iConsolidadoSubtotalCorte
								, Case when @iConsolidadoSubtotalCorte < 0 Then @sCodigoConsolidadoComparar + '-'+ @sDescripcionConsolidadoComparar
									Else @sCodigoConsolidado + '-'+ @sDescripcionConsolidado End									 
								, @sidCompaniaSubtotalCorte
								, @sDescripcionCompaniaSubTotalCorte
								, @sCodigoGrupoSubtotalCorte
								, @sDescripcionGrupoSubTotalCorte
								, '99999999'
								, 'Total ' + @sDescripcionGrupoSubTotalCorte
								, '99999999'
								, ' '
								, @sIdPeriodoSubtotalCorte
								, @nAcumSubtotal
								, @iFlagSubTotalCorte
								, 'ST'
								)
					----
					Set @sCodigoGrupoSubtotalCorte = @sCodigoGrupoSubtotal;
					Set @sDescripcionGrupoSubTotalCorte = @sDescripcionGrupoSubTotal;
					Set @iFlagSubTotalCorte = @iFlagSubTotal;
					--
					If @sidCompaniaSubtotal != @sidCompaniaSubtotalCorte					
					Begin
						Set @sTexto = '__________ Cambia Compania ';
						Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
						Set @sidCompaniaSubtotalCorte = @sidCompaniaSubtotal 
						Set @sDescripcionCompaniaSubTotalCorte = @sDescripcionCompaniaSubTotal;
						Set @nAcumSubtotal = 0;
						--
						If @sIdPeriodoSubtotal != @sIdPeriodoSubtotalCorte
						Begin
							Set @sTexto = '________ Cambia Periodo';
							Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
							Set @sIdPeriodoSubtotalCorte = @sIdPeriodoSubtotal
							Set @nAcumSubtotal = 0;
							--
							If @iConsolidadoSubtotal != @iConsolidadoSubtotalCorte
							Begin
								Set @sTexto = '______ Cambia Consolidado';
								Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
								Set @iConsolidadoSubtotalCorte = @iConsolidadoSubtotal
								Set @sDescripcionConsolidadoSubtotalCorte = @sDescripcionConsolidadoSubTotal;
								Set @nAcumSubtotal = 0;
							End;
						End;
					End;
				End;
				--
				Set @nAcumSubtotal = @nAcumSubtotal + @nValorSubtotal;
				--
				Set @sTexto = '________ Valor Acumulado ';
				Set @sTexto = @sTexto + ' {' + convert(varchar,  @nAcumSubtotal ) + '}';
				Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
				--
				Fetch Next From @curSumatoria Into 
												  @iConsolidadoSubtotal
												, @sIdPeriodoSubtotal
												, @sidCompaniaSubtotal
												, @sCodigoGrupoSubtotal
												, @nValorSubtotal
												, @sDescripcionConsolidadoSubTotal
												, @sDescripcionCompaniaSubTotal
												, @sDescripcionGrupoSubTotal
												, @iFlagSubTotal
			End;
			--
			Set @sTexto = '______________ Inserta el Subtotal manual arrastre';
			Set @sTexto += '	Consolidado {'    + convert( varchar(10), @iConsolidadoSubtotalCorte) + '}';
			Set @sTexto += '	Descripcion Consolidado {' + @sDescripcionConsolidadoSubtotalCorte+ '}';
			Set @sTexto += '	Compania {'       + @sidCompaniaSubtotalCorte + '}';
			Set @sTexto += '	Descripcion Compania {'    + isnull(@sDescripcionCompaniaSubTotalCorte, '') + '}';
			Set @sTexto += '	Grupo {'          + @sCodigoGrupoSubtotalCorte + '}';
			Set @sTexto += '	Desgrupo {'       + @sDescripcionGrupoSubTotalCorte + '}';
			Set @sTexto += '	Concepto {'       + '9999999999}';
			Set @sTexto += '	DesConcepto {'    + 'Total ' + @sDescripcionGrupoSubTotalCorte +'}';
			Set @sTexto += '	Cuenta {'         + '99999999}';
			Set @sTexto += '	DesCuenta {'      + '.}';
			Set @sTexto += '	Periodo {'        + @sIdPeriodoSubtotalCorte + '}';
			Set @sTexto += '	Valor {'          + Convert(varchar(30), @nAcumSubtotal) + '}';
			Set @sTexto += '	flag {'           + Convert(varchar,@iFlagSubTotalCorte) + '}';
			Set @sTexto += '	Tipo {'           + 'ST}';
			Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			-- Inserta ultimo registro de arrastre al terminar de contar los registros
				Insert Into @TablaTemporal (
						idConsolidado, DescripcionConsolidado, idCompania, DescripcionCompania, idGrupo, DescripcionGrupo, 
						idConcepto, DescripcionConcepto, idCuenta, DescripcionCuenta, idPeriodo, Valor, FlagImprime, tipo
						)
					Values (
						@iConsolidadoSubtotalCorte
						, Case when @iConsolidadoSubtotalCorte < 0 Then @sCodigoConsolidadoComparar + '-'+ @sDescripcionConsolidadoComparar
							Else @sCodigoConsolidado + '-'+ @sDescripcionConsolidado End									 
						, @sidCompaniaSubtotalCorte
						, @sDescripcionCompaniaSubTotalCorte
						, @sCodigoGrupoSubtotalCorte
						, @sDescripcionGrupoSubTotalCorte
						, '99999999'
						, 'Total ' + @sDescripcionGrupoSubTotalCorte
						, '99999999'
						, ' '
						, @sIdPeriodoSubtotalCorte
						, @nAcumSubtotal
						, @iFlagSubTotalCorte
						, 'ST'
						)
			--
			Close @curSumatoria;
			Deallocate @curSumatoria;
			--
		Set @sTexto = '____ Fin Generacion de subtotales ';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		--select * from @TablaTemporal Order By idConsolidado, idPeriodo, idCompania, idGrupo, idConcepto
		--
		-- Creacion de registros para la tabla del subreporte 
		Set @sTexto = '____ Generacion de Lineas SubReporte ';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
			Insert into @TablaTemporal
					Select 
						A.idConsolidado
						, Case When A.idConsolidado > 0 Then @sCodigoConsolidado + '-' + @sDescripcionConsolidado
								Else @sCodigoConsolidadoComparar + '-' + @sDescripcionConsolidadoComparar End 
						,A.idCompania 
						, Case When Len(A.idCompania) = 1 Then 'Ajustes de Consolidación'
								When A.idConsolidado > 0 Then 
									( Select C.DescripcionCompania From  @TablaTemporal C Where 1 = 1
										And  C.idConsolidado  = A.idConsolidado And C.idCompania = A.idCompania
										Group By C.DescripcionCompania ) 
								Else
									( Select C.DescripcionCompania From  @TablaTemporal C Where 1 = 1
										And  C.idConsolidado  = A.idConsolidado And C.idCompania = A.idCompania
										Group By C.DescripcionCompania ) 
							End
						, '1' idGrupo
						, 'Ganancia (pérdida), atribuible a' DescripcionGrupo
						, '1' IdConcepto
						, 'Ganancia (pérdida), atribuible a los propietarios de la controladora' DescripcionConcepto
						, '1' idCuenta
						, 'Cuenta 11' DescripcionCuenta
						, case when A.idConsolidado > 0 Then @sPeriodo
							Else @sPeriodoComparar
							End
						, Sum(A.Valor) Valor
						, 1 FlagImprime
						, 'SR' Tipo
					From @TablaTemporal A
					Where 1 = 1
						And Tipo <> 'ST'
					Group By idConsolidado, idCompania
			Insert into @TablaTemporal
					Select 
						A.idConsolidado
						, Case When A.idConsolidado > 0 Then @sCodigoConsolidado + '-' + @sDescripcionConsolidado
								Else @sCodigoConsolidadoComparar + '-' + @sDescripcionConsolidadoComparar End 
							,A.idCompania 
						, Case When Len(A.idCompania) = 1 Then 'Ajustes de Consolidación'
								When A.idConsolidado > 0 Then 
									( Select C.DescripcionCompania From  @TablaTemporal C Where 1 = 1
										And  C.idConsolidado  = A.idConsolidado And C.idCompania = A.idCompania
										Group By C.DescripcionCompania ) 
								Else
									( Select C.DescripcionCompania From  @TablaTemporal C Where 1 = 1
										And  C.idConsolidado  = A.idConsolidado And C.idCompania = A.idCompania
										Group By C.DescripcionCompania ) 
							End
						, '1' idGrupo
						, 'Ganancia (pérdida), atribuible a' DescripcionGrupo
						, '2' IdConcepto
						, 'Ganancia (pérdida), atribuible a participaciones no controladoras' DescripcionConcepto
						, '1' idCuenta
						, 'Cuenta 22' DescripcionCuenta
						, case when A.idConsolidado > 0 Then @sPeriodo
							Else @sPeriodoComparar
							End
						, (Sum(A.Valor)*-1) Valor
						, 1 FlagImprime
						, 'SR' Tipo
						From @TablaTemporal A
						Where 1 = 1
							--And FlagImprime = 0
							And idCuenta = 'ERF_NC'
							And Tipo <> 'ST'
						Group By idConsolidado, idCompania
		--
		Set @sTexto = '____ Fin Generacion de Lineas SubReporte ';
		Execute EERR_sp_Log4Sql_Debug @sName, @sTexto;
		--
		--
		--
		--
		--Delete From @TablaTemporal where idConsolidado = 0;
		-- Devolvemos la tabla completa para el reporte ordenada
			Select 
				idConsolidado
				, DescripcionConsolidado
				, idCompania
				, DescripcionCompania
				, idGrupo
				, DescripcionGrupo
				, idConcepto
				, DescripcionConcepto
				, idCuenta
				, DescripcionCuenta
				, idPeriodo
				, Valor
				, FlagImprime
				, Tipo
			From @TablaTemporal  
			Order By idConsolidado, idCompania, idGrupo, idConcepto, idCuenta
		--
		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_LINE()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;
		print @sErr;
		Return (1);
	End Catch
End;
