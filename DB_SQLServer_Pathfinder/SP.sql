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

	SELECT CONQ.PersId AS ConqId
         , CONQ.PersDni AS ConqDni
         , CONQ.PersNombres AS ConqNombres
		 , CONQ.PersApellidoPaterno AS ConqApellidoPaterno
		 , CONQ.PersApellidoMaterno AS ConqApellidoMaterno
		 , DATEDIFF(YEAR, CONQ.PersFechaNacimiento, GETDATE()) AS ConqEdad
		 , CONQ.PersCelular + ' | ' + CONQ.PersTelefono AS ConqMovil
		 , CONQ.PersCorreoPersonal + ' | ' + CONQ.PersCorreoCorporativo AS ConqCorreos
         , ISNULL(CLAS.ClasNombre, '') AS ConqClase
         , ISNULL(UNID.UnidNombre, '') AS ConqUnidad
	  FROM Conquistadores AS CONQ
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
-------------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.ConqSS_GetAllTutor', N'P') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.ConqSS_GetAllTutor
    END
GO
-------------------------------------------------------------------------------
-- Autor - Fecha - Descripción : Jordan - 08/07/2024 - Procedimiento para seleccionar los conquistadores para la LView
-- Autor - Fecha - Descripción :
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.ConqSS_GetAllTutor
	@UsuaId INT
AS
BEGIN

    DECLARE @TutoId INT = (SELECT TUTO.PersId
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
         , ISNULL(CLAS.ClasNombre, 'Sin clase') AS ConqClase
         , ISNULL(UNID.UnidNombre, 'Sin unidad') AS ConqUnidad
	  FROM Conquistadores AS CONQ
 LEFT JOIN TutorConquistadores AS TUCO ON TUCO.ConqId = CONQ.PersId
 LEFT JOIN ClaseConquistadores AS CLCO ON CONQ.PersId = CLCO.ConqId
                                      AND YEAR(CLCO.AudiFechCrea) = YEAR(GETDATE())
 LEFT JOIN Clases AS CLAS ON CLCO.ClasId = CLAS.ClasId
 LEFT JOIN UnidadConquistadores AS UNCO ON UNCO.ConqId = CONQ.PersId
                                       AND YEAR(UNCO.AudiFechCrea) = YEAR(GETDATE())
 LEFT JOIN Unidades AS UNID ON UNCO.UnidId = UNID.UnidId
     WHERE TUCO.TutoId = ISNULL(@TutoId, TUCO.TutoId)

END
GO
-------------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.SplitString', N'TF') IS NOT NULL
    BEGIN
        DROP FUNCTION dbo.SplitString
    END
GO
-------------------------------------------------------------------------------
-- Autor - Fecha - Descripción : Jordan - 05/08/2024 - Función para separar un string por un caracter predeterminado
-- Autor - Fecha - Descripción :
-------------------------------------------------------------------------------
CREATE FUNCTION dbo.SplitString(
    @string nvarchar(max)
  , @separator char(1))
RETURNS @result TABLE (Value NVARCHAR(max))
AS
BEGIN
    DECLARE @xml xml
    SET @xml = CAST('<r>' + REPLACE(@string, @separator, '</r><r>') + '</r>' AS XML)

    INSERT INTO @result
    SELECT r.value('.','nvarchar(max)') AS Value
    FROM @xml.nodes('//r') AS records(r)

    RETURN
END
GO
-------------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.ConqSS_GetRegistro', N'P') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.ConqSS_GetRegistro
    END
GO
-------------------------------------------------------------------------------
-- Autor - Fecha - Descripción : Jordan - 08/07/2024 - Procedimiento para seleccionar los conquistadores para la LView
-- Autor - Fecha - Descripción :
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.ConqSS_GetRegistro
	@ConqId INT
AS
BEGIN

    SELECT CONQ.PersId
         , CONCAT(CONQ.PersNombres, ' ', CONQ.PersApellidoPaterno, ' ', CONQ.PersApellidoMaterno) AS PersNombres
         , CONQ.PersFechaNacimiento
         , CONQ.PersNacionalidad
         , CONQ.PersDireccionCasa
         , CONQ.PersCiudad
         , CONQ.PersRegion
         , CONQ.PersCelular
         , CONQ.PersCorreoPersonal
         , ISNULL((SELECT CONCAT(tuto.PersNombres, ' ', tuto.PersApellidoPaterno, ' ', tuto.PersApellidoMaterno)
                     FROM Tutores AS tuto
                     JOIN TutorConquistadores AS tuco ON tuto.PersId = tuco.TutoId
                    WHERE tuco.ConqId = CONQ.PersId
                      AND tuco.TucoTipoParentescoId = 1), '') AS Padre
         , ISNULL((SELECT CONCAT(tuto.PersNombres, ' ', tuto.PersApellidoPaterno, ' ', tuto.PersApellidoMaterno)
                     FROM Tutores AS tuto
                     JOIN TutorConquistadores AS tuco ON tuto.PersId = tuco.TutoId
                    WHERE tuco.ConqId = CONQ.PersId
                      AND tuco.TucoTipoParentescoId = 2), '') AS Madre
         , CONQ.ConqEscuela
         , CONQ.ConqCurso
         , CONQ.ConqTurno
         , FIME.FimeSangreRH
         , ISNULL((SELECT STRING_AGG(TipoDescripcion, ', ')
                     FROM Tipos AS TIPO
                     JOIN (SELECT *
                             FROM dbo.SplitString(FIME.FimeAlergias, '|')) AS VACU ON TipoTabla = 'ALE'
                                                                             AND TipoId = VACU.Value), '') AS FimeAlergias
         , ISNULL((SELECT STRING_AGG(TipoDescripcion, ', ')
                     FROM Tipos AS TIPO
                     JOIN (SELECT *
                             FROM dbo.SplitString(FIME.FimeEnfermedades, '|')) AS VACU ON TipoTabla = 'ENF'
                                                                             AND TipoId = VACU.Value), '') AS FimeEnfermedades
         , CLAS.ClasNombre
         , ISNULL((SELECT STRING_AGG(ESPE.EspeCodigo, ', ')
                     FROM ConquistadorEspecialidades AS COES
                     JOIN Especialidades AS ESPE ON COES.EspeId = ESPE.EspeId
                     JOIN Categorias AS CATE ON ESPE.CateId = CATE.CateId
                    WHERE COES.ConqId = CONQ.PersId), '') AS ConqEspecialidades
      FROM Conquistadores AS CONQ
      JOIN FichasMedicas AS FIME ON CONQ.PersId = FIME.ConqId
                                AND FIME.FimeAnio = YEAR(GETDATE())
      JOIN ClaseConquistadores AS CLCO ON CONQ.PersId = CLCO.ConqId
                              AND CLCO.ClcoAnio = YEAR(GETDATE())
      JOIN Clases AS CLAS ON CLCO.ClasId = CLAS.ClasId
     WHERE CONQ.PersId = @ConqId

END
GO
-------------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.ConqSS_GetFichaMedica', N'P') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.ConqSS_GetFichaMedica
    END
GO
-------------------------------------------------------------------------------
-- Autor - Fecha - Descripción : Jordan - 08/07/2024 - Procedimiento para seleccionar la ficha medica del conquistador para el reporte
-- Autor - Fecha - Descripción :
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.ConqSS_GetFichaMedica
	@ConqId INT
AS
BEGIN

    SELECT CONQ.PersId
         , CONCAT(CONQ.PersNombres, ' ', CONQ.PersApellidoPaterno, ' ', CONQ.PersApellidoMaterno) AS PersNombres
         , FIME.FimeSangreRH
         , CONCAT(TUTO.PersNombres, ' ', TUTO.PersApellidoPaterno, ' ', TUTO.PersApellidoMaterno) AS TutoNombre
         , TIPO.TipoDescripcion AS TucoParentesco
         , TUTO.PersCelular
         , ISNULL((SELECT STRING_AGG(TipoDescripcion, ', ')
                     FROM Tipos AS TIPO
                     JOIN (SELECT *
                             FROM dbo.SplitString(FIME.FimeAlergias, '|')) AS VACU ON TipoTabla = 'ALE'
                                                                                  AND TipoId = VACU.Value), '') AS FimeAlergias
         , ISNULL((SELECT STRING_AGG(TipoDescripcion, ', ')
                     FROM Tipos AS TIPO
                     JOIN (SELECT *
                             FROM dbo.SplitString(FIME.FimeEnfermedades, '|')) AS VACU ON TipoTabla = 'ENF'
                                                                                      AND TipoId = VACU.Value), '') AS FimeEnfermedades
         , ISNULL((SELECT STRING_AGG(TipoDescripcion, ', ')
                     FROM Tipos AS TIPO
                     JOIN (SELECT *
                             FROM dbo.SplitString(FIME.FimeVacunas, '|')) AS VACU ON TipoTabla = 'VAC'
                                                                                 AND TipoId = VACU.Value), '') AS FimeVacunas
      FROM Conquistadores AS CONQ
      JOIN FichasMedicas AS FIME ON CONQ.PersId = FIME.ConqId
                                AND FIME.FimeAnio = YEAR(GETDATE())
 LEFT JOIN TutorConquistadores AS TUCO ON CONQ.PersId = TUCO.ConqId
 LEFT JOIN Tutores AS TUTO ON TUCO.TutoId = TUTO.PersId
 LEFT JOIN Tipos AS TIPO ON TUCO.TucoTipoParentescoTabla = TIPO.TipoTabla
                        AND TUCO.TucoTipoParentescoId = TIPO.TipoId
     WHERE CONQ.PersId = @ConqId

END
GO
-------------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.UsroSS_AllByRol', N'P') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.UsroSS_AllByRol
    END
GO
-------------------------------------------------------------------------------
-- Autor - Fecha - Descripción : Jordan - 08/07/2024 - Procedimiento para seleccionar los usuarios por rol
-- Autor - Fecha - Descripción :
-------------------------------------------------------------------------------
CREATE PROCEDURE UsroSS_AllByRol
    @RoleId INT
AS
BEGIN
    
    SELECT USUA.UsuaId      , CONQ.PersNombres , USUA.UsuaUsuario
         , USRO.AudiFechCrea, USRO.AudiUserCrea, CLCO.ClasId
         , UNCO.UnidId      , CLAS.ClasNombre  , UNID.UnidNombre
      FROM Roles AS ROLE
      JOIN UsuarioRoles AS USRO ON ROLE.RoleId = USRO.RoleId
      JOIN Usuarios AS USUA ON USRO.UsuaId = USUA.UsuaId
      JOIN Conquistadores AS CONQ ON USUA.UsuaId = CONQ.UsuaId
 LEFT JOIN ClaseConquistadores AS CLCO ON CONQ.PersId = CLCO.ConqId
                                      AND CLCO.ClcoTipoCargoClaseId = 1
 LEFT JOIN UnidadConquistadores AS UNCO ON CONQ.PersId = UNCO.ConqId
                                       AND UNCO.UncoCargoId = 1
 LEFT JOIN Clases AS CLAS ON CLCO.ClasId = CLAS.ClasId
 LEFT JOIN Unidades AS UNID ON UNCO.UnidId = UNID.UnidId
     where ROLE.RoleId = @RoleId

END
GO