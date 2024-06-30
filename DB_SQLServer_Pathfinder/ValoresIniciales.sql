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
INSERT INTO Parametros (ParaNombre, ParaValor, AudiUserCrea, AudiHostCrea)
VALUES ('SessionTimeMinutes', '60', 'SISTEMAS', 'J-PC'),
       ('Email', 'emito.tite@gmail.com', 'SISTEMAS', 'J-PC'),
       ('Password', 'ahoc znlo gunn nghm', 'SISTEMAS', 'J-PC'),
       ('Smtp', 'smtp.gmail.com', 'SISTEMAS', 'J-PC'),
       ('Port', '587', 'SISTEMAS', 'J-PC'),
       ('PasswordRecoveryTemplate', N'<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Nueva Contraseña</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 600px;
            margin: auto;
            padding: 20px;
            background: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .header {
            background-color: #007bff;
            color: #fff;
            padding: 10px;
            text-align: center;
            border-radius: 5px 5px 0 0;
        }

        .content {
            padding: 20px;
        }

        .footer {
            text-align: center;
            padding: 10px 0;
            color: #777;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="header">
            <h2>Nueva Contraseña</h2>
        </div>
        <div class="content">
            <p>Estimado %%name%%,</p>
            <p>Le hemos asignado una nueva contraseña para su cuenta. A continuación, encontrará su nueva contraseña:</p>
            <p><strong> %%newPassword%% </strong></p>
            <p>Por favor, cambie esta contraseña la próxima vez que inicie sesión.</p>
            <p>Gracias,</p>
            <p>El Equipo de Soporte</p>
        </div>
        <div class="footer">
            <p>Este es un correo electrónico automático. Por favor, no responda a este mensaje.</p>
        </div>
    </div>
</body>
</html>', 'SISTEMAS', 'J-PC')
GO
INSERT INTO Conquistadores (ConqDni, ConqNombres, ConqApellidoPaterno, ConqApellidoMaterno, ConqFechaNacimiento, UsuaId,
                            ConqCorreoPersonal, ConqCorreoCorporativo, ConqCelular, ConqTelefono, AudiUserCrea,
                            AudiHostCrea)
VALUES ('70685341', 'John Jordan', 'Quispe', 'Supo', '19990709', 1, 'j.jordan.quispe.supo@gmail.com',
        'jordan.quispe@nextsoft.com.pe', '914786862', '054329166', 'SISTEMAS', 'J-PC');
GO
INSERT INTO Tutores (TutoDni, TutoNombres, TutoApellidoPaterno, TutoApellidoMaterno, TutoFechaNacimiento,
                     TutoCorreoPersonal, TutoCorreoCorporativo, TutoCelular, TutoTelefono, AudiUserCrea, AudiHostCrea,
                     UsuaId)
VALUES ('06549277', 'Gerardo', 'Quispe', 'Supo', '19481013', '', '', '997089302', '', 'SISTEMAS', 'J-PC', 2)
GO