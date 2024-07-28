USE DB_SqlServer_Pathfinder
GO
DBCC CHECKIDENT (Usuarios, RESEED, 1)
DBCC CHECKIDENT (Roles, RESEED, 1)
DBCC CHECKIDENT (Conquistadores, RESEED, 1)
DBCC CHECKIDENT (Tutores, RESEED, 1)
DBCC CHECKIDENT (Categorias, RESEED, 1)
DBCC CHECKIDENT (Unidades, RESEED, 1)
INSERT INTO Tipos
(TipoTabla, TipoId, TipoDescripcion, TipoEstaActivo, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES
('UND'    , 1     , 'Consejero'    , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS'),
('UND'    , 2     , 'Capellan'     , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS'),
('UND'    , 3     , 'Secretario'   , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS'),
('UND'    , 4     , 'Tesorero'     , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS')
GO
INSERT INTO Parametros (ParaNombre, ParaValor, AudiUserCrea, AudiHostCrea)
VALUES ('SessionTimeMinutes', '240', 'SISTEMAS', 'J-PC'),
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
INSERT INTO UsuarioRoles(RoleId, UsuaId, AudiUserCrea, AudiHostCrea)
VALUES (1, 1, 'SISTEMAS', 'J-PC'),
       (2, 1, 'SISTEMAS', 'J-PC'),
       (3, 1, 'SISTEMAS', 'J-PC')
GO
INSERT INTO Conquistadores
( PersDni			              , PersNombres		               , PersApellidoPaterno, PersApellidoMaterno, PersFechaNacimiento, UsuaId
, PersCorreoPersonal              , PersCorreoCorporativo          , PersCelular		, PersTelefono	     , AudiUserCrea	      , AudiHostCrea
, PersSexo                        , ConqEscuela                    , ConqCurso          , ConqTurno          , PersDireccionCasa  , PersNacionalidad
, PersRegion                      , PersCiudad)
VALUES
 ('70685341'		              , 'John Jordan'		           , 'Quispe'			, 'Supo'			 , '19990709'		  , 1
, 'j.jordan.quispe.supo@gmail.com', 'jordan.quispe@nextsoft.com.pe', '914786862'        , '054329166'        , 'SISTEMAS'		  , 'J-PC'
, 'M'                             , ''                             , ''                 , ''                 , ''                 , 'Peruana'
, 'Arequipa'                      , 'Arequipa')
GO
INSERT INTO Tutores
( PersDni			   , PersNombres         , PersApellidoPaterno, PersApellidoMaterno, PersFechaNacimiento, PersCorreoPersonal
, PersCorreoCorporativo, PersCelular         , PersTelefono		  , AudiUserCrea	   , AudiHostCrea	    , UsuaId
, TutoCentroTrabajo    , TutoDireccionTrabajo, PersSexo           , PersDireccionCasa  , PersNacionalidad   , PersRegion
, PersCiudad)
VALUES
( '06549277'		   , 'Gerardo'           , 'Quispe'			 , 'Huisa'			   , '19481013'		    , ''
, ''				   , '997089302'         , ''				 , 'SISTEMAS'		   , 'J-PC'			    , 2
, ''                   , ''                  , 'M'               , ''                  , 'Peruana'          , 'Arequipa'
, 'Arequipa')
GO
INSERT INTO Categorias
(CateNombre                             , CateColor, AudiUserCrea, AudiFechCrea, AudiHostCrea, CateDescripcion)
VALUES
('ADRA'                                 , '#A8A5DA', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades de ADRA (Agencia Adventista de Desarrollo y Recursos Asistenciales) están diseñadas para fomentar un espíritu de servicio y compasión. Estas especialidades enseñan a los jóvenes a involucrarse en actividades de asistencia y desarrollo comunitario, así como en la respuesta a desastres y emergencias. Los conquistadores aprenden sobre el trabajo humanitario, la gestión de recursos y la organización de proyectos de ayuda social.'),
('Artes y habilidades manuales'         , '#A8E1FC', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Esta categoría incluye especialidades que desarrollan la creatividad y la destreza manual de los jóvenes. Abarca una amplia gama de actividades artísticas y artesanales, como la pintura, el dibujo, la escultura, la cerámica, el trabajo con madera, el tejido y otras manualidades. Estas especialidades fomentan la autoexpresión y la apreciación por el arte y la cultura.'),
('Actividades agrícolas'                , '#C1925A', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades agrícolas enseñan a los conquistadores sobre la agricultura sostenible, la jardinería, el cultivo de plantas y la cría de animales. Los jóvenes aprenden técnicas de cultivo, manejo del suelo, control de plagas y cosecha, así como la importancia de la agricultura en la seguridad alimentaria y el cuidado del medio ambiente.'),
('Actividades misioneras y comunitarias', '#7aadda', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Estas especialidades están enfocadas en el servicio comunitario y la evangelización. Los conquistadores aprenden a participar en proyectos misioneros, actividades de voluntariado, distribución de literatura religiosa y organización de eventos comunitarios. Se enfatiza la importancia de ayudar a los demás y compartir su fe de manera práctica y significativa.'),
('Actividades profesionales'            , '#f6846c', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades profesionales introducen a los jóvenes en diversas profesiones y oficios. Estas especialidades pueden incluir temas como la mecánica, la carpintería, la electricidad, la fontanería, la cocina profesional, entre otros. Los conquistadores adquieren habilidades prácticas que pueden ser útiles en su vida cotidiana y futuras carreras.'),
('Actividades recreativas'              , '#a7db89', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Esta categoría incluye especialidades que promueven la actividad física, el deporte y el entretenimiento saludable. Los conquistadores pueden aprender sobre deportes específicos, técnicas de campamento, orientación, supervivencia al aire libre y otras actividades recreativas. Estas especialidades fomentan el trabajo en equipo, la disciplina y un estilo de vida activo.'),
('Ciencia y salud'                      , '#b394cf', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades de ciencia y salud están diseñadas para aumentar el conocimiento de los jóvenes sobre el cuerpo humano, la salud, la nutrición y las ciencias naturales. Pueden incluir temas como la anatomía, la fisiología, la biología, la química y la física. Los conquistadores también aprenden sobre primeros auxilios, RCP, y prácticas de vida saludable.'),
('Estudio de la naturaleza'             , '#bcbcbc', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Esta categoría abarca especialidades relacionadas con la exploración y el estudio del mundo natural. Los conquistadores aprenden sobre la flora, la fauna, la geología, la meteorología, la astronomía y la ecología. Estas especialidades fomentan la apreciación y el respeto por la naturaleza y promueven la conservación del medio ambiente.'),
('Habilidades domésticas'               , '#fdcc06', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades de habilidades domésticas enseñan a los jóvenes competencias esenciales para la vida diaria en el hogar. Incluyen temas como la cocina, la costura, el cuidado del hogar, la planificación del presupuesto, la jardinería doméstica y otras habilidades que contribuyen al bienestar personal y familiar.'),
('Maestrías'                            , '#efefef', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las maestrías son especialidades avanzadas que requieren un nivel más alto de conocimiento y habilidad. Están diseñadas para aquellos conquistadores que desean profundizar en un área específica y alcanzar un dominio notable. Las maestrías pueden abarcar cualquiera de las categorías anteriores y suelen involucrar proyectos más complejos y un mayor compromiso.')
GO
INSERT INTO Unidades
(UnidNombre, UnidLema                       , UnidGritoGuerra                             , UnidDescripcion    , UnidImagen, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES
('Halcones', 'Volamos Alto, Vencemos Juntos', '¡Halcones! ¡Altos volamos, unidos ganamos!', 'Unidad de varones', 'halcones.png', 'SISTEMAS'  , GETDATE()   , 'SISTEMAS')
GO
INSERT INTO UnidadConquistadores
(UnidId, ConqId, UncoAno, UncoCargoTabla, UncoCargoId, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES
(1     , 1     , 2024   , 'UND'         , 1          , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS')
GO