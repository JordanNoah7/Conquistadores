USE DB_SqlServer_Pathfinder
GO
SELECT * FROM Conquistadores
SELECT * FROM Usuarios
INSERT INTO Usuarios (UsuaUsuario, UsuaContrasenia, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES ('JJ70685341', '123456', 'SISTEMAS', GETDATE(), 'J-PC')

alter table Usuarios alter column AudiFechCrea datetime