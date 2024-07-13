USE DB_SqlServer_Pathfinder
GO
SELECT * FROM Conquistadores
GO
-------------------------------------------------------------------------------
-- Autor - Fecha - Descripción : Jordan - 08/07/2024 - Procedimiento para seleccionar los conquistadores para la LView
-- Autor - Fecha - Descripción :
-------------------------------------------------------------------------------
CREATE PROCEDURE dbo.Sample_Procedure
AS
BEGIN

	SELECT ConqNombres
		 , ConqApellidoPaterno
		 , ConqApellidoMaterno
		 , DATEDIFF(YEAR, ConqFechaNacimiento, GETDATE()) AS ConqEdad
		 , ConqCelular + ' | ' + ConqTelefono AS ConqMovil
		 , ConqCorreoPersonal + ' | ' + ConqCorreoCorporativo AS ConqCorreos
	  FROM Conquistadores

END
GO