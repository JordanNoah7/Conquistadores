USE DB_SqlServer_Pathfinder
GO
-------------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.ConqSS_GetAll', N'P') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.ConqSS_GetAll
    END
GO
-------------------------------------------------------------------------------
-- Autor - Fecha - Descripción : Jordan - 08/07/2024 - Procedimiento para seleccionar los conquistadores para la LView
-- Autor - Fecha - Descripción :
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.ConqSS_GetAll
	@ConqDni VARCHAR(16)
  , @ConqNombres VARCHAR(100)
  , @ConqApellidos VARCHAR(80)
  , @CondEdad INT
AS
BEGIN

	SELECT ConqId
         , ConqDni
         , ConqNombres
		 , ConqApellidoPaterno
		 , ConqApellidoMaterno
		 , DATEDIFF(YEAR, ConqFechaNacimiento, GETDATE()) AS ConqEdad
		 , ConqCelular + ' | ' + ConqTelefono AS ConqMovil
		 , ConqCorreoPersonal + ' | ' + ConqCorreoCorporativo AS ConqCorreos
	  FROM Conquistadores
     WHERE ConqDni LIKE (ISNULL(@ConqDni, '') + '%')
       AND ConqNombres LIKE ('%' + ISNULL(@ConqNombres, '') + '%')
       AND (ConqApellidoPaterno LIKE ('%' + ISNULL(@ConqApellidos, '') + '%')
            OR ConqApellidoMaterno LIKE ('%' + ISNULL(@ConqApellidos, '') + '%'))
       AND DATEDIFF(YEAR, ConqFechaNacimiento, GETDATE()) = ISNULL(@CondEdad, DATEDIFF(YEAR, ConqFechaNacimiento, GETDATE()))

END
GO
-------------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.SesiSS_GetOneSession', N'P') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.SesiSS_GetOneSession
    END
GO
-------------------------------------------------------------------------------
-- Autor - Fecha - Descripción : Jordan - 08/07/2024 - Procedimiento para validar la sesión
-- Autor - Fecha - Descripción :
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.SesiSS_GetOneSession
    @UsuaId INT
AS
BEGIN
    DECLARE @Time INT = (SELECT ParaValor FROM Parametros WHERE ParaNombre = 'SessionTimeMinutes')

    IF EXISTS (SELECT *
                 FROM Sesiones
                WHERE UsuaId = @UsuaId
                  AND CONVERT(DATE, SesiFecha) = CONVERT(DATE, GETDATE()))
        BEGIN
            DECLARE @LastSession DATETIME = (SELECT TOP 1 SesiFecha
                                               FROM Sesiones
                                              WHERE UsuaId = @UsuaId
                                                AND CONVERT(DATE, SesiFecha) = CONVERT(DATE, GETDATE())
                                           ORDER BY AudiFechCrea DESC)
            IF DATEDIFF(MINUTE, @LastSession, GETDATE()) < @Time
                BEGIN
                    SELECT TOP 1 *
                      FROM Sesiones
                     WHERE UsuaId = @UsuaId
                       AND CONVERT(DATE, SesiFecha) = CONVERT(DATE, GETDATE())
                  ORDER BY AudiFechCrea DESC
                END
        END
END
GO