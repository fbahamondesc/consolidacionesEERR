--Use CONSOLIDADO_EERR_DESARROLLO
--Use CONSOLIDADO_EERR_PRODUCCION


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Carga_Datos_Dynamics', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Carga_Datos_Dynamics;
GO

---------------------------------------------------------------------------------------------------
-- Primer procedimiento de carga de datos desde Dynamics para el funcinamiento de NewConsolidado
-- 
---------------------------------------------------------------------------------------------------

--TABLA 1: RAISERROR Severity Categories
--Severity Range 	Error Number Info 	@@ERROR 	Logged As
--1 hasta 9 	In black 	NOT SET 	Informational
--10 	Not provided 	NOT SET 	Informational
--11 hasta 14 	In red 	SET 	Informational
--15 	In red 	SET 	Warning
--16 	In red 	SET 	Error

CREATE PROCEDURE dbo.EERR_Sp_Carga_Datos_Dynamics
AS

Declare @sName AS Varchar(100);
Declare @iRetVal as int;
Declare @sTexto as nVarchar(500);
Declare @iEstado as int;

Begin
	Set NOCOUNT ON;
	Set @sName = 'EERR_Sp_Carga_Datos_Dynamics'; 

	Begin Try
		Set @sTexto = 'Inicio de carga de datos desde Dynamics';
		Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
		--		
		Select @iEstado = ValueConcurrencia From EERR_TBL_Concurrencias  where KeyConcurrencia = 'Dynamics';
		If @iEstado = 0 -- No se esta ejecutando
			Begin
				Set @sTexto  = '_Marcamos la tabla EERR_TBL_Concurrencias';
				Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
					Update EERR_TBL_Concurrencias set ValueConcurrencia = 1 where KeyConcurrencia = 'Dynamics';
				--
					Set @sTexto = '_Llamada carga de compañias';
					Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
						Execute @iRetVal = EERR_Sp_Carga_Companias;
						If @iRetVal = 1 RAISERROR ('** Salida con Error 1', 16, 1 );
					
					Set @sTexto = '_Llamada carga de cuentas contables por compañia';
					Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
						Execute @iRetVal = EERR_Sp_Carga_Cuentas_x_Compania;
						If @iRetVal = 1 RAISERROR ('** Salida con Error 2', 16, 1 );
							
					Set @sTexto = '_Llamada carga de Maestro cuentas contables';
					Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
						Execute @iRetVal = EERR_Sp_Carga_Maestro_Cuentas;
						If @iRetVal = 1 RAISERROR ('** Salida con Error 3', 16, 1 );
							
					Set @sTexto = '_Llamada carga de datos contables por compañia ';
					Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
						Execute @iRetVal = EERR_Sp_Carga_Datos_Contables;
						If @iRetVal = 1 RAISERROR ('** Salida con Error 4', 16, 1 );
							
					Set @sTexto = '_Llamada carga de Maestro libros contables';
					Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
						Execute @iRetVal = EERR_Sp_Carga_Maestro_Libros;
						If @iRetVal = 1 RAISERROR ('** Salida con Error 5', 16, 1 );
				--				
				Set @sTexto  = '_Desmarcamos la tabla EERR_TBL_Concurrencias';
				Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
					Update EERR_TBL_Concurrencias set ValueConcurrencia = 0 where KeyConcurrencia = 'Dynamics';
			End
		Else
			Begin
				Set @sTexto = '**No se puede ejecutar el proceso, ya esta en ejecucion**';
				print '**No se puede ejecutar el proceso, ya esta en ejecucion**';
				Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
			End;
		--
		Set @sTexto = 'Termino de carga de datos desde Dynamics';
		Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;

		return (0);
	End Try
	Begin Catch
		Print 'Se ha presentado un error en la ejecucion de las tareas de carga de datos desde Dynamics {'+ERROR_MESSAGE()+'}';
		Declare @sErr as Varchar(2000);
		set @sErr = 'Num Err {' + Convert(varchar, ERROR_NUMBER()) + '} Linea {'+ Convert(varchar,ERROR_LINE()) +' } Mensaje {' + ERROR_MESSAGE() + '}';
		Execute EERR_Sp_Log4sql_ERROR @sName, @sErr;
		
		Set @sTexto  = '_Desmarcamos la tabla EERR_TBL_Concurrencias';
		Execute EERR_Sp_Log4Sql_Info @sName, @sTexto;
			Update EERR_TBL_Concurrencias set ValueConcurrencia = 0 where KeyConcurrencia = 'Dynamics';
		
		return (1);
	End Catch
End;
