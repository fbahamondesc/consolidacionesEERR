--Use CONSOLIDADO_EERR_DESARROLLO
Use CONSOLIDADO_EERR_PRODUCCION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Carga_Cuentas_x_Compania', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Carga_Cuentas_x_Compania;
GO

CREATE PROCEDURE EERR_Sp_Carga_Cuentas_x_Compania
AS

Declare @sName as Varchar(100);
Declare @sSql as nVarchar(2000);
Declare @sSqlTexto as nVarchar(4000);
Declare @sCodigo as Varchar(10);
Declare @sBasedatos as Varchar(100);

------- Cursores
Declare @CompaniasC as Cursor;

Begin
	Set @sName = 'EERR_Sp_Carga_Cuentas_x_Compania';
	
	Begin Try
		Execute EERR_sp_Log4Sql_Info @sName, '__Limpiamos la tabla de EERR_Tbl_Cuentas_x_Compania de los registros de dynamics antes de la carga de registros';
		Delete From EERR_Tbl_Cuentas_x_Compania Where Origen = 0;

		Set @CompaniasC = CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR
			Select Distinct idCompania, BaseDatos from EERR_Tbl_Companias where Origen = 0;
		Open @CompaniasC;
		Fetch Next From @CompaniasC Into @sCodigo, @sBasedatos;
		While @@FETCH_STATUS = 0
			Begin
				Set @sSql = 
					N'Insert Into EERR_Tbl_Cuentas_x_Compania Select '''+@sCodigo+''' as IdCompania, Acct as IdCuenta, Descr Descripcion, Accttype as Tipo, 0 Origen From '+rTrim(@sBasedatos)+'.dbo.account';
					Set @sSqlTexto = '____' + @sSql;
					Execute EERR_sp_Log4Sql_Debug @sName, @sSqlTexto;

				Execute sp_executesql @sSql
				-- Proximo registro
				Fetch Next From @CompaniasC Into @sCodigo, @sBasedatos;
			End;

		Execute EERR_sp_Log4Sql_Info @sName, '__Termino del proceso carga EERR_Tbl_Cuentas_x_Compania';
		Close @CompaniasC;
		Deallocate @CompaniasC;

		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_NUMBER()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;

		Return (1);
	End Catch
End;