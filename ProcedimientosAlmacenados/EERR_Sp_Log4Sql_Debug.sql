SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Log4Sql_Debug', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_sp_Log4Sql_Debug;
GO

CREATE PROCEDURE dbo.EERR_Sp_Log4Sql_Debug
	@sProcedimiento varchar(100),          -- Nombre del procedimiento que ejecuta la accion
	@sGlosa varchar(5000)                   -- Glosa del mensaje
AS
BEGIN
	Execute EERR_Sp_Log4Sql 1, @sProcedimiento, @sGlosa
END;
