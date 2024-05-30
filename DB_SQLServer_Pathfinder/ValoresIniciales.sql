INSERT INTO Usuarios (UsuaUsuario, UsuaContrasenia, AudiUserCrea, AudiHostCrea)
VALUES ('dyfmeks', 'd51d6c6902da30d427b8e29267b94036', 'SISTEMAS', 'J-PC'),
    ('gQuispe', '6b043205253a236a414f0ac9aaff1338', 'SISTEMAS', 'J-PC')
GO
INSERT INTO Roles (RoleNombre, RoleDescripcion, AudiUserCrea, AudiHostCrea)
VALUES ('Administrador', 'Administrador del sistema', 'SISTEMAS', 'J-PC'),
       ('Director', 'Director o director asociado', 'SISTEMAS', 'J-PC'),
       ('Instructor', 'Instructor de una clase', 'SISTEMAS', 'J-PC'),
       ('Consejero', 'Consejero de una unidad', 'SISTEMAS', 'J-PC'),
       ('Apoderado', 'Apoderado de un conquistador', 'SISTEMAS', 'J-PC'),
       ('Conquistador', 'Conquistador', 'SISTEMAS', 'J-PC')
GO
INSERT INTO RolesUsuario (RoleId, UsuaId, AudiUserCrea, AudiHostCrea)
VALUES (1, 1, 'SISTEMAS', 'J-PC'),
       (2, 1, 'SISTEMAS', 'J-PC'),
       (3, 1, 'SISTEMAS', 'J-PC')
GO
INSERT INTO Parametros (ParaNombre, ParaValor, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES ('TiempoSesion', '60', 'SISTEMAS', GETDATE(), 'J-PC')
GO
INSERT INTO Conquistadores (ConqDni, ConqNombres, ConqApellidoPaterno, ConqApellidoMaterno, ConqFechaNacimiento, UsuaId, ConqCorreoPersonal, ConqCorreoCorporativo, ConqCelular, ConqTelefono, AudiUserCrea, AudiHostCrea)
VALUES ('70685341', 'John Jordan', 'Quispe', 'Supo', '19990709', 1, 'j.jordan.quispe.supo@gmail.com', 'jordan.quispe@nextsoft.com.pe', '914786862', '054329166', 'SISTEMAS', 'J-PC');
GO
INSERT INTO Tutores (TutoDni, TutoNombres, TutoApellidoPaterno, TutoApellidoMaterno, TutoFechaNacimiento, TutoCorreoPersonal, TutoCorreoCorporativo, TutoCelular, TutoTelefono, AudiUserCrea, AudiHostCrea, UsuaId)
VALUES ('06549277', 'Gerardo', 'Quispe', 'Supo', '19481013', '', '', '997089302', '', 'SISTEMAS', 'J-PC', 2)
GO