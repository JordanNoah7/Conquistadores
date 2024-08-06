use DB_SqlServer_Pathfinder
go
SELECT * FROM UnidadConquistadores
SELECT * FROM ClaseConquistadores
SELECT * FROM Conquistadores

SELECT * FROM tipos

SELECT * FROM UsuarioRoles


SELECT CLAS.*
FROM Conquistadores AS CONQ
JOIN ClaseConquistadores AS CLCO ON CONQ.PersId = CLCO.ConqId
JOIN Clases AS CLAS ON CLCO.ClasId = CLAS.ClasId
WHERE CLCO.ClcoTipoCargoClaseId =  2
AND CONQ.PersId = 1


declare @costo int = (SELECT ParaValor FROM Parametros WHERE ParaNombre = 'CostoInscripcion')

SELECT CONQ.PersDni
     , CONQ.PersNombres
     , CONQ.PersApellidoPaterno
     , CONQ.PersApellidoMaterno
     , unid.UnidNombre
     , tipo.TipoDescripcion
     , CLAS.ClasNombre
     , CONVERT(BIT, case when @costo - insc.inscmonto = 0
                         then 0
                         else 1
                    end) AS inscDebe
FROM Conquistadores AS CONQ
JOIN Inscripciones AS insc ON CONQ.PersId = insc.ConqId
JOIN ClaseConquistadores AS CLCO ON CLCO.ConqId = CONQ.PersId
JOIN Clases AS CLAS ON CLCO.ClasId = CLAS.ClasId
JOIN UnidadConquistadores AS unco ON unco.ConqId = CONQ.PersId
JOIN Unidades AS unid ON unco.UnidId = unid.UnidId
JOIN Tipos AS tipo ON unco.UncoCargoTabla = tipo.TipoTabla
                  AND unco.UncoCargoId = tipo.TipoId
WHERE insc.InscAnio = year(GETDATE())
AND CLCO.ClcoAnio  = year(GETDATE())
AND unco.UncoAno = year(GETDATE())

SELECT * FROM Inscripciones

SELECT * FROM Parametros



--Consulta para reporte
SELECT CONQ.PersId
     , CONCAT(CONQ.PersNombres, ' ', CONQ.PersApellidoPaterno, ' ', CONQ.PersApellidoPaterno) AS PersNombres
     , CONQ.PersFechaNacimiento
     , CONQ.PersNacionalidad
     , CONQ.PersDireccionCasa
     , CONQ.PersCiudad
     , CONQ.PersRegion
     , CONQ.PersCelular
     , CONQ.PersCorreoPersonal
     , ISNULL((SELECT CONCAT(tuto.PersNombres, ' ', tuto.PersApellidoPaterno, ' ', tuto.PersApellidoPaterno)
                 FROM Tutores AS tuto
                 JOIN TutorConquistadores AS tuco ON tuto.PersId = tuco.TutoId
                WHERE tuco.ConqId = CONQ.PersId
                  AND tuco.TucoTipoParentescoId = 1), '') AS Padre
     , ISNULL((SELECT CONCAT(tuto.PersNombres, ' ', tuto.PersApellidoPaterno, ' ', tuto.PersApellidoPaterno)
                 FROM Tutores AS tuto
                 JOIN TutorConquistadores AS tuco ON tuto.PersId = tuco.TutoId
                WHERE tuco.ConqId = CONQ.PersId
                  AND tuco.TucoTipoParentescoId = 2), '') AS Madre
     , CONQ.ConqEscuela
     , CONQ.ConqCurso
     , CONQ.ConqTurno
     , FIME.FimeSangreRH
     , FIME.FimeAlergias
     , FIME.FimeEnfermedades
     , CLAS.ClasNombre
FROM Conquistadores AS CONQ
JOIN FichasMedicas AS FIME ON CONQ.PersId = FIME.ConqId
                          AND FIME.FimeAnio = YEAR(GETDATE())
JOIN ClaseConquistadores AS CLCO ON CONQ.PersId = CLCO.ConqId
                        AND CLCO.ClcoAnio = YEAR(GETDATE())
JOIN Clases AS CLAS ON CLCO.ClasId = CLAS.ClasId
WHERE CONQ.PersId = @ConqId




SELECT STRING_AGG(TipoDescripcion, ', ')
  FROM Tipos AS TIPO
  JOIN (SELECT *
          FROM SplitString((SELECT FimeVacunas
                              FROM FichasMedicas
                             WHERE ConqId = 1), '|')) AS VACU ON TipoTabla = 'VAC'
                                                             AND TipoId = VACU.Value 











