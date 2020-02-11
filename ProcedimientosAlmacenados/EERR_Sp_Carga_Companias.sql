--Use CONSOLIDADO_EERR_DESARROLLO
Use CONSOLIDADO_EERR_PRODUCCION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------------------------------------------------------------------------------------
-- Proceso de carga de compañias
-- 29/06/2019 - se agrega query para traspasar solo las compañias que ya existen
-- 29/06/2019 - se comenta la instuccion para eliminar la tabla de compañias
---------------------------------------------------------------------------------------------------

IF OBJECT_ID ( 'EERR_Sp_Carga_Companias', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Carga_Companias;
GO

CREATE PROCEDURE dbo.EERR_Sp_Carga_Companias
AS

Declare @sSql as NVarchar(4000)
Declare @sSqlTexto as NVarchar(4000)
Declare @sName AS Varchar(100)
Declare @sCodigo as Varchar(10)
Declare @sCompania as Varchar(100)
Declare @sBasedatos as Varchar(100)
Declare @sRUT as Varchar(10)

BEGIN
	Set @sName = 'EERR_Sp_Carga_Companias'; 

	Begin Try

		--DECLARE @x int
		--instruccion de prueba de error
		--SELECT @x = 1/0

		--Execute EERR_sp_Log4Sql_Info @sName, '__Limpiamos la tabla de EERR_tbl_Companias antes de la carga de registros';
		--Delete from EERR_Tbl_Companias where origen = 0;
	
		Declare CompaniasD Cursor For 
			Select Distinct 
					  Com.CpnyID as Codigo
					, Com.IASEmailAddress as Name
					, DatabaseName as BaseDatos
					, Master_Fed_ID Rut
				From SistemaProduccion.DBO.COMPANY Com
				WHERE Active=1
				And CpnyID not in ('0173')
				And CpnyID not in ( SELECT IdCompania FROM Consolidado_eerr_produccion.dbo.EERR_Tbl_Companias );
		Open CompaniasD;
		Fetch Next From CompaniasD Into @sCodigo, @sCompania, @sBasedatos, @sRUT;
		While @@FETCH_STATUS = 0
			Begin
				Set @sSQl = 
					N'Insert into EERR_tbl_Companias Values 
						(	'''+rtrim(@sCodigo)+''', '''+rtrim(@sCompania)+''' , '''+rtrim(@sRUT)+''' , '''+rtrim(@sBasedatos)+'''
						, (select YtdNetIncAcct from ' + rtrim(@sBasedatos) + '.dbo.GLSETUP where CpnyID = '''+rtrim(@sCodigo)+''')
						, (select RetEarnAcct from ' + rtrim(@sBasedatos) + '.dbo.GLSETUP where CpnyID = '''+rtrim(@sCodigo)+''')
						, 0, 0 )';
					Set @sSqlTexto = '____' + @sSQl;
					Execute EERR_sp_Log4sql_Debug @sName, @sSqlTexto;

				Execute sp_executesql @sSQl;
				-- Proximo registro
				Fetch Next From CompaniasD Into @sCodigo, @sCompania, @sBasedatos, @sRUT;
			End;
		Execute EERR_sp_Log4Sql_Info @sName, '__Termino del proceso carga EERR_tbl_Companias';
		Close CompaniasD;
		Deallocate CompaniasD;
		
		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_NUMBER()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;
		
		Return (1);
	End Catch
End;
