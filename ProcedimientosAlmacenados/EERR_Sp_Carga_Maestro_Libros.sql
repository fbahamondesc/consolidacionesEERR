SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Carga_Maestro_Libros', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Carga_Maestro_Libros;
GO

CREATE PROCEDURE EERR_Sp_Carga_Maestro_Libros
AS

Declare @sSql as NVarchar(4000)
Declare @sName AS Varchar(100)
Declare @sCodigo as Varchar(10)
Declare @sCompania as Varchar(100)
Declare @sBasedatos as Varchar(100)
Declare @sRUT as Varchar(10)

BEGIN
	Set @sName = 'EERR_Sp_Carga_Maestro_Libros'; 

	Begin Try

		Execute EERR_sp_Log4Sql_Info @sName, '__ Agregamos los libros que puedan faltar al maestro';

		Insert Into eerr_tbl_maestro_libros
		Select Libro 
			From EERR_Tbl_Saldos_Contables 
			Where Libro Not in ( Select Libro From eerr_tbl_maestro_libros )
			Group by Libro;

		Execute EERR_sp_Log4Sql_Info @sName, '__ Termino de carga de Maestro Libros';
		
		Return (0);
	End Try
	Begin Catch
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num : {' + Convert(varchar, ERROR_NUMBER()) + '} Mensaje : {' + ERROR_MESSAGE() + '}';
		Execute EERR_sp_Log4sql_ERROR @sName, @sErr;

		Return (1);
	End Catch
End;
