Use CONSOLIDADO_EERR_DESARROLLO
--Use CONSOLIDADO_EERR_PRODUCCION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Log4Sql', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Log4Sql;
GO

CREATE PROCEDURE dbo.EERR_Sp_Log4Sql
	@iAccion as int,
	@sProcedimiento varchar(100),          -- Nombre del procedimiento que ejecuta la accion
	@sGlosa varchar(5000)                  -- Glosa del mensaje
AS
BEGIN
	/*

	Procedimiento Padre que escribre en la tabla de log de procesos
		-- Tipo de Mensaje
		-- 1: Debug
		-- 2: Informativo
		-- 3: Alerta
		-- 4: Error
		-- 5: Ninguno
	*/
	Declare @iNivel as Int;
	
	Select @iNivel = isNull(cast(ValorConfiguracion as int), 0)
				From EERR_Tbl_Configuraciones
				Where 1=1
				And KeyConfiguracion = 'Nivel'
	If @iAccion >= @iNivel
	Begin 	
		INSERT INTO EERR_Tbl_Log4SQL  VALUES
		(
			getDate()
			,@sProcedimiento
			,@iAccion
			,@sGlosa 
		);
	End;
END;
