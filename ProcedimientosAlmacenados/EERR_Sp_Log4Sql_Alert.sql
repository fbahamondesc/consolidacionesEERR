SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ( 'EERR_Sp_Log4Sql_Alert', 'P' ) IS NOT NULL 
    DROP PROCEDURE EERR_Sp_Log4Sql_Alert;
GO

CREATE PROCEDURE dbo.EERR_Sp_Log4Sql_Alert
	@sProcedimiento varchar(100),          -- Nombre del procedimiento que ejecuta la accion
	@sGlosa varchar(5000)                   -- Glosa del mensaje
AS
BEGIN
	Execute EERR_Sp_Log4Sql 3, @sProcedimiento, @sGlosa
END;
