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
	@ConqDni VARCHAR(16) = NULL
  , @ConqNombres VARCHAR(100) = NULL
  , @ConqApellidos VARCHAR(80) = NULL
  , @CondEdad INT = NULL
  , @TutoId INT = NULL
AS
BEGIN

    DECLARE @UsuaId INT = @TutoId
    SET @TutoId = (SELECT TUTO.PersId
                     FROM Tutores AS TUTO
                    WHERE UsuaId = @UsuaId)

	SELECT CONQ.PersId AS ConqId
         , CONQ.PersDni AS ConqDni
         , CONQ.PersNombres AS ConqNombres
		 , CONQ.PersApellidoPaterno AS ConqApellidoPaterno
		 , CONQ.PersApellidoMaterno AS ConqApellidoMaterno
		 , DATEDIFF(YEAR, CONQ.PersFechaNacimiento, GETDATE()) AS ConqEdad
		 , CONQ.PersCelular + ' | ' + CONQ.PersTelefono AS ConqMovil
		 , CONQ.PersCorreoPersonal + ' | ' + CONQ.PersCorreoCorporativo AS ConqCorreos
         , ISNULL(CLAS.ClasNombre, '') AS ClasNombre
         , ISNULL(UNID.UnidNombre, '') AS UnidNombre
	  FROM Conquistadores AS CONQ
 LEFT JOIN TutorConquistadores AS TUCO ON TUCO.ConqId = CONQ.PersId
 LEFT JOIN ClaseConquistadores AS CLCO ON CONQ.PersId = CLCO.ConqId
                                      AND YEAR(CLCO.AudiFechCrea) = YEAR(GETDATE())
 LEFT JOIN Clases AS CLAS ON CLCO.ClasId = CLAS.ClasId
 LEFT JOIN UnidadConquistadores AS UNCO ON UNCO.ConqId = CONQ.PersId
                                       AND YEAR(UNCO.AudiFechCrea) = YEAR(GETDATE())
 LEFT JOIN Unidades AS UNID ON UNCO.UnidId = UNID.UnidId
     WHERE PersDni LIKE (ISNULL(@ConqDni, '') + '%')
       AND PersNombres LIKE ('%' + ISNULL(@ConqNombres, '') + '%')
       AND (PersApellidoPaterno LIKE ('%' + ISNULL(@ConqApellidos, '') + '%')
            OR PersApellidoMaterno LIKE ('%' + ISNULL(@ConqApellidos, '') + '%'))
       AND DATEDIFF(YEAR, PersFechaNacimiento, GETDATE()) = ISNULL(@CondEdad, DATEDIFF(YEAR, PersFechaNacimiento, GETDATE()))
       AND ISNULL(TUCO.TutoId, '') = ISNULL(@TutoId, ISNULL(TUCO.TutoId, ''))

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