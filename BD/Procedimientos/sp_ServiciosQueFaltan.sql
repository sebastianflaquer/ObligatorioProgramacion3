CREATE PROCEDURE [dbo].[ServiciosQueLeFaltan]
@idAlojamiento int
AS
BEGIN

SELECT S.*
FROM SERVICIO S, ALOJAMIENTO_SERVICIO S2
WHERE S.id = S2.idServicio
EXCEPT
(SELECT S3.*
FROM SERVICIO S3, ALOJAMIENTO_SERVICIO S4
WHERE S3.id = S4.idServicio
AND S4.idAlojamiento = @idAlojamiento)	
		
		
END
go
