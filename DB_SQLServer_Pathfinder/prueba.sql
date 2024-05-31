-- use master
-- go
-- drop database DB_SqlServer_Pathfinder

USE DB_SqlServer_Pathfinder
GO
SELECT * FROM Conquistadores
SELECT * FROM Usuarios --6b043205253a236a414f0ac9aaff1338
select * from ActividadConquistadores
select * from Roles
select * from RolesUsuario
select * from Tutores

select * from parametros
SELECT * FROM Sesiones

select * from Asistencias
select * from Inscripciones

update Usuarios
set UsuaCambiarContrasenia = 1
where UsuaId = 1