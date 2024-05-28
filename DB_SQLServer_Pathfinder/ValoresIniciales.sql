INSERT INTO Usuarios (UsuaUsuario, UsuaContrasenia, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES ('dyfmeks', 'd51d6c6902da30d427b8e29267b94036', 'SISTEMAS', GETDATE(), 'J-PC')
GO
INSERT INTO Roles (RoleNombre, RoleDescripcion, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES ('Administrador', 'Administrador del sistema', 'SISTEMAS', GETDATE(), 'J-PC'),
       ('Director', 'Director o director asociado', 'SISTEMAS', GETDATE(), 'J-PC'),
       ('Instructor', 'Instructor de una clase', 'SISTEMAS', GETDATE(), 'J-PC'),
       ('Consejero', 'Consejero de una unidad', 'SISTEMAS', GETDATE(), 'J-PC'),
       ('Apoderado', 'Apoderado de un conquistador', 'SISTEMAS', GETDATE(), 'J-PC'),
       ('Conquistador', 'Conquistador', 'SISTEMAS', GETDATE(), 'J-PC')
GO
INSERT INTO RolUsuario (RoleUsuariosUsuaID, UsuaRolesRoleID)
VALUES (1, 1),
       (1, 2),
       (1, 3)
GO