SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Carga_Maestro_Cuentas', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Carga_Maestro_Cuentas;
GO

CREATE PROCEDURE EERR_Sp_Carga_Maestro_Cuentas
AS

Declare @sName as Varchar(100);
Declare @sSql as nVarchar(2000);
Declare @sCodigo as Varchar(10);

Begin
	Set @sName = 'EERR_Sp_Carga_Maestro_Cuentas';
	
	Begin Try
		Execute EERR_sp_Log4Sql_Info @sName, '__Carga de cuentas faltantes en el maestro de cuentas';
		
		Insert Into EERR_Tbl_Maestro_Cuentas
			Select distinct
				CC.IdCuenta
				, (select top 1 Descripcion from EERR_Tbl_Cuentas_x_Compania a where a.idCuenta = cc.idcuenta) Descripcion
				, CC.Tipo
				, 0
				, 0
				, 1
				, 0
				,0
			From EERR_Tbl_Cuentas_x_Compania CC
			Where 1 = 1
			And IdCuenta Not in ( Select idCuenta from EERR_Tbl_Maestro_Cuentas)
		
		Execute EERR_sp_Log4Sql_Info @sName, '__Termino del proceso Carga de cuentas faltantes en el maestro de cuentas';

		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_NUMBER()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;
		
		Return (1);
	End Catch
End;