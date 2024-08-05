use DB_SqlServer_Pathfinder
go
select * from UnidadConquistadores
select * from ClaseConquistadores
select * from Conquistadores

select * from tipos

select * from UsuarioRoles


select clas.*
from Conquistadores as conq
join ClaseConquistadores as clco on conq.PersId = clco.ConqId
join Clases as clas on clco.ClasId = clas.ClasId
where clco.ClcoTipoCargoClaseId =  2
and conq.PersId = 1


declare @costo int = (select ParaValor from Parametros where ParaNombre = 'CostoInscripcion')

select conq.PersDni
     , conq.PersNombres
     , conq.PersApellidoPaterno
     , conq.PersApellidoMaterno
     , unid.UnidNombre
     , tipo.TipoDescripcion
     , clas.ClasNombre
     , CONVERT(BIT, case when @costo - insc.inscmonto = 0
                         then 0
                         else 1
                    end) as inscDebe
from Conquistadores as conq
join Inscripciones as insc on conq.PersId = insc.ConqId
join ClaseConquistadores as clco on clco.ConqId = conq.PersId
join Clases as clas on clco.ClasId = clas.ClasId
join UnidadConquistadores as unco on unco.ConqId = conq.PersId
join Unidades as unid on unco.UnidId = unid.UnidId
join Tipos as tipo on unco.UncoCargoTabla = tipo.TipoTabla
                  and unco.UncoCargoId = tipo.TipoId
where insc.InscAnio = year(GETDATE())
and clco.ClcoAnio  = year(GETDATE())
and unco.UncoAno = year(GETDATE())

select * from Inscripciones

select * from Parametros



--Consulta para reporte
select conq.PersId
     , CONCAT(conq.PersNombres, ' ', conq.PersApellidoPaterno, ' ', conq.PersApellidoPaterno) as PersNombres
     , conq.PersFechaNacimiento
     , conq.PersNacionalidad
     , conq.PersDireccionCasa
     , conq.PersCiudad
     , conq.PersRegion
     , conq.PersCelular
     , conq.PersCorreoPersonal
     , ISNULL((select CONCAT(tuto.PersNombres, ' ', tuto.PersApellidoPaterno, ' ', tuto.PersApellidoPaterno)
                 from Tutores as tuto
                 join TutorConquistadores as tuco on tuto.PersId = tuco.TutoId
                where tuco.ConqId = conq.PersId
                  and tuco.TucoTipoParentescoId = 1), '') as Padre
     , ISNULL((select CONCAT(tuto.PersNombres, ' ', tuto.PersApellidoPaterno, ' ', tuto.PersApellidoPaterno)
                 from Tutores as tuto
                 join TutorConquistadores as tuco on tuto.PersId = tuco.TutoId
                where tuco.ConqId = conq.PersId
                  and tuco.TucoTipoParentescoId = 2), '') as Madre
     , conq.ConqEscuela
     , conq.ConqCurso
     , conq.ConqTurno
     , fime.FimeSangreRH
     , fime.FimeAlergias
     , fime.FimeEnfermedades
     , clas.ClasNombre
from Conquistadores as conq
join FichasMedicas as fime on conq.PersId = fime.ConqId
                          and fime.FimeAnio = YEAR(GETDATE())
join ClaseConquistadores as clco on conq.PersId = clco.ConqId
                        and clco.ClcoAnio = YEAR(GETDATE())
join Clases as clas on clco.ClasId = clas.ClasId