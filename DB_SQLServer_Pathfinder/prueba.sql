-- use master
-- go
-- drop database DB_SqlServer_Pathfinder

USE DB_SqlServer_Pathfinder
GO
SELECT * FROM Conquistadores
SELECT * FROM Usuarios
select * from ActividadConquistadores
select * from Roles
select * from RolesUsuario

select * from parametros
SELECT * FROM Sesiones

select * from Asistencias
select * from Inscripciones


update Sesiones
set SesiId = 1
where UsuaId =  1

INSERT INTO [Sesiones] ([SesiId], [UsuaId], [AudiHostCrea], [AudiUserCrea], [SesiFecha])
      VALUES (1, 1, 'dyfmeks', '179.6.10.154', getdate());
