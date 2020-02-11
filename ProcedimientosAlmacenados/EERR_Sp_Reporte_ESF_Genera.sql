use CONSOLIDADO_EERR_DESARROLLO
--use CONSOLIDADO_EERR_PRODUCCION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( '[EERR_Sp_Reporte_ESF_Genera]', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Reporte_ESF_Genera;
GO

CREATE PROCEDURE EERR_Sp_Reporte_ESF_Genera
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
--
Declare @curAnidados as Cursor;
-- Declaracion de variables temporalesde tipo Tabla
--
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
Declare @TablaLibros Table ( Libro varchar(20) ); -- Tabla para transformar en registro los libros enviados por parameto
Declare @TablaPeriodos Table ( Periodo varchar(6) );
--
--
BEGIN
	SET NOCOUNT ON;
	--
	Set @sName = 'EERR_Sp_Reporte_ESF_Genera'; 
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
		Set @sTexto = 'Proceso de Generacion de Reporte ESF';
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
					, 'Ajustes de Consolidación'
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
					, Case when AJ.PeriodoAfectado = AJ.PeriodoVista
						Then '0' 
						Else '-1'
						End Compania
					, Case when AJ.PeriodoAfectado = AJ.PeriodoVista
						Then 'Ajustes de Consolidación'
						Else 'Reclasificaciones'
						End Compania					
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
					And AJ.PeriodoAfectado = @sPeriodoComparar
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
						AND CO.IdCompania in ( SELECT codigo FROM EERR_Tbl_Consolidados where idPadre = @iIdConsolidadoComparar and TipoNodo = 2  )
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
					Execute @iRetVal = EERR_Sp_Reporte_ESF_Recursivo_ExtraeSaldosyAjustes @sToken, @iIdAnidado, @sPeriodo, @sLibros, '______';
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
					-- Prechequeo de id a enviar
					set @iIdAnidado = Case when @iIdAnidado = 0 then @iIdRegistroOrg Else @iIdAnidado End;
				
					-- Llamado al recursivo
					Execute @iRetVal = EERR_Sp_Reporte_ESF_Recursivo_ExtraeSaldosyAjustes_Comparativo @sToken, @iIdAnidado, @sPeriodoComparar, @sPeriodo, @sLibros, '______';
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
									And AJ.PeriodoAfectado = @sPeriodoComparar
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
		-- Devolvemos la tabla completa para el reporte
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
			, FlagPatrimonio
			, DescripcionFlag
		From @TablaTemporal
		Order By idConsolidado, idCompania, idGrupo, idConcepto, idCuenta
		--
		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_LINE()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;

		Return (1);
	End Catch
End;
