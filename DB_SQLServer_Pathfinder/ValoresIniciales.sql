USE DB_SqlServer_Pathfinder
GO
DBCC CHECKIDENT (Usuarios, RESEED, 1)
DBCC CHECKIDENT (Roles, RESEED, 1)
DBCC CHECKIDENT (Conquistadores, RESEED, 1)
DBCC CHECKIDENT (Tutores, RESEED, 1)
DBCC CHECKIDENT (Categorias, RESEED, 1)
DBCC CHECKIDENT (Unidades, RESEED, 1)
DBCC CHECKIDENT (Clases, RESEED, 1)
INSERT INTO Tipos
(TipoTabla, TipoId, TipoDescripcion, TipoEstaActivo, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES
('CLA'    , 2     , 'Conquistador' , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS'),
('CLA'    , 1     , 'Instructor'   , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS'),
('UND'    , 1     , 'Consejero'    , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS'),
('UND'    , 2     , 'Capellan'     , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS'),
('UND'    , 3     , 'Secretario'   , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS'),
('UND'    , 4     , 'Tesorero'     , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS'),
('PAR'    , 1     , 'Padre'        , 1             , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS')
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
             <title>Nueva Contrase�a</title>
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
                     <h2>Nueva Contrase�a</h2>
                 </div>
                 <div class="content">
                     <p>Estimado %%name%%,</p>
                     <p>Le hemos asignado una nueva contrase�a para su cuenta. A continuaci�n, encontrar� su nueva contrase�a:</p>
                     <p><strong> %%newPassword%% </strong></p>
                     <p>Por favor, cambie esta contrase�a la pr�xima vez que inicie sesi�n.</p>
                     <p>Gracias,</p>
                     <p>El Equipo de Soporte</p>
                 </div>
                 <div class="footer">
                     <p>Este es un correo electr�nico autom�tico. Por favor, no responda a este mensaje.</p>
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
INSERT INTO UsuarioRoles
(RoleId, UsuaId, AudiUserCrea, AudiHostCrea)
VALUES 
(1     , 1     , 'SISTEMAS'  , 'J-PC'),
(2     , 1     , 'SISTEMAS'  , 'J-PC'),
(3     , 1     , 'SISTEMAS'  , 'J-PC'),
(5     , 2     , 'SISTEMAS'  , 'J-PC')
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
('ADRA'                                 , '#A8A5DA', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades de ADRA (Agencia Adventista de Desarrollo y Recursos Asistenciales) est�n dise�adas para fomentar un esp�ritu de servicio y compasi�n. Estas especialidades ense�an a los j�venes a involucrarse en actividades de asistencia y desarrollo comunitario, as� como en la respuesta a desastres y emergencias. Los conquistadores aprenden sobre el trabajo humanitario, la gesti�n de recursos y la organizaci�n de proyectos de ayuda social.'),
('Artes y habilidades manuales'         , '#A8E1FC', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Esta categor�a incluye especialidades que desarrollan la creatividad y la destreza manual de los j�venes. Abarca una amplia gama de actividades art�sticas y artesanales, como la pintura, el dibujo, la escultura, la cer�mica, el trabajo con madera, el tejido y otras manualidades. Estas especialidades fomentan la autoexpresi�n y la apreciaci�n por el arte y la cultura.'),
('Actividades agr�colas'                , '#C1925A', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades agr�colas ense�an a los conquistadores sobre la agricultura sostenible, la jardiner�a, el cultivo de plantas y la cr�a de animales. Los j�venes aprenden t�cnicas de cultivo, manejo del suelo, control de plagas y cosecha, as� como la importancia de la agricultura en la seguridad alimentaria y el cuidado del medio ambiente.'),
('Actividades misioneras y comunitarias', '#7aadda', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Estas especialidades est�n enfocadas en el servicio comunitario y la evangelizaci�n. Los conquistadores aprenden a participar en proyectos misioneros, actividades de voluntariado, distribuci�n de literatura religiosa y organizaci�n de eventos comunitarios. Se enfatiza la importancia de ayudar a los dem�s y compartir su fe de manera pr�ctica y significativa.'),
('Actividades profesionales'            , '#f6846c', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades profesionales introducen a los j�venes en diversas profesiones y oficios. Estas especialidades pueden incluir temas como la mec�nica, la carpinter�a, la electricidad, la fontaner�a, la cocina profesional, entre otros. Los conquistadores adquieren habilidades pr�cticas que pueden ser �tiles en su vida cotidiana y futuras carreras.'),
('Actividades recreativas'              , '#a7db89', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Esta categor�a incluye especialidades que promueven la actividad f�sica, el deporte y el entretenimiento saludable. Los conquistadores pueden aprender sobre deportes espec�ficos, t�cnicas de campamento, orientaci�n, supervivencia al aire libre y otras actividades recreativas. Estas especialidades fomentan el trabajo en equipo, la disciplina y un estilo de vida activo.'),
('Ciencia y salud'                      , '#b394cf', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades de ciencia y salud est�n dise�adas para aumentar el conocimiento de los j�venes sobre el cuerpo humano, la salud, la nutrici�n y las ciencias naturales. Pueden incluir temas como la anatom�a, la fisiolog�a, la biolog�a, la qu�mica y la f�sica. Los conquistadores tambi�n aprenden sobre primeros auxilios, RCP, y pr�cticas de vida saludable.'),
('Estudio de la naturaleza'             , '#bcbcbc', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Esta categor�a abarca especialidades relacionadas con la exploraci�n y el estudio del mundo natural. Los conquistadores aprenden sobre la flora, la fauna, la geolog�a, la meteorolog�a, la astronom�a y la ecolog�a. Estas especialidades fomentan la apreciaci�n y el respeto por la naturaleza y promueven la conservaci�n del medio ambiente.'),
('Habilidades dom�sticas'               , '#fdcc06', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las especialidades de habilidades dom�sticas ense�an a los j�venes competencias esenciales para la vida diaria en el hogar. Incluyen temas como la cocina, la costura, el cuidado del hogar, la planificaci�n del presupuesto, la jardiner�a dom�stica y otras habilidades que contribuyen al bienestar personal y familiar.'),
('Maestr�as'                            , '#efefef', 'SISTEMAS'  , GETDATE()   , 'JORDAN-PC' , 'Las maestr�as son especialidades avanzadas que requieren un nivel m�s alto de conocimiento y habilidad. Est�n dise�adas para aquellos conquistadores que desean profundizar en un �rea espec�fica y alcanzar un dominio notable. Las maestr�as pueden abarcar cualquiera de las categor�as anteriores y suelen involucrar proyectos m�s complejos y un mayor compromiso.')
GO
INSERT INTO Unidades
(UnidNombre, UnidLema                       , UnidGritoGuerra                             , UnidDescripcion    , UnidImagen, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES
('Halcones', 'Volamos Alto, Vencemos Juntos', '�Halcones! �Altos volamos, unidos ganamos!', 'Unidad de varones', 'halcones.png', 'SISTEMAS'  , GETDATE()   , 'SISTEMAS')
GO
INSERT INTO Clases
(ClasNombre                       , ClasDescripcion            , ClasImagen                      , AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES
('Amigo'                          , 'Clase regular de 10 a�os' , 'amigo.png'                     , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Amigo de la naturaleza'         , 'Clase avanzada de 10 a�os', 'amigo_naturaleza.png'          , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Compa�ero'                      , 'Clase regular de 11 a�os' , 'compa�ero.png'                 , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Compa�ero de excursionismo'     , 'Clase avanzada de 11 a�os', 'compa�ero_excursionismo.png'   , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Explorador'                     , 'Clase regular de 12 a�os' , 'explorador.png'                , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Explorador de campo y de bosque', 'Clase avanzada de 12 a�os', 'explorador_campo_bosque.png'   , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Pionero'                        , 'Clase regular de 13 a�os' , 'pionero.png'                   , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Pionero de nuevas fronteras'    , 'Clase avanzada de 13 a�os', 'pionero_nuevas_fronteras.png'  , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Excursionista'                  , 'Clase regular de 14 a�os' , 'excursionista.png'             , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Excursionista en el bosque'     , 'Clase avanzada de 14 a�os', 'excursionista_bosque.png'      , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Guia'                           , 'Clase regular de 15 a�os' , 'guia.png'                      , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Guia de exploracion'            , 'Clase avanzada de 15 a�os', 'guia_exploracion.png'          , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Guia mayor'                     , 'Clase de liderazgo 1'     , 'guia_mayor.png'                , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Guia mayor master'              , 'Clase de liderazgo 2'     , 'guia_mayor_master.png'         , 'SYSTEM'    , GETDATE()   , 'localhost'),
('Guia mayor master avanzado'     , 'Clase de liderazgo 3'     , 'guia_mayor_master_avanzado.png', 'SYSTEM'    , GETDATE()   , 'localhost')
GO
INSERT INTO UnidadConquistadores
(UnidId, ConqId, UncoAno, UncoCargoTabla, UncoCargoId, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES
(1     , 1     , 2024   , 'UND'         , 1          , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS')
GO
INSERT INTO TutorConquistadores
(TutoId, ConqId, TucoTipoParentescoTabla, TucoTipoParentescoId, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES
(1     , 1     , 'PAR'                  , 1                   , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS')
GO
INSERT INTO ClaseConquistadores
(ClasId, ConqId, ClcoTipoCargoClaseTabla, ClcoTipoCargoClaseId, ClcoAprobado, AudiUserCrea, AudiFechCrea, AudiHostCrea)
VALUES
(11    , 1     , 'CLA'                  , 2                   , 0           , 'SISTEMAS'  , GETDATE()   , 'SISTEMAS')