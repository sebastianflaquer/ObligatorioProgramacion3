USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[ServiciosQueLeFaltan]    Script Date: 04/05/2016 16:14:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ServiciosQueLeFaltan]
@idAlojamiento int
AS
BEGIN

SELECT S.*
FROM SERVICIO S, ALOJAMIENTO_SERVICIO S2
EXCEPT
(SELECT S3.*
FROM SERVICIO S3, ALOJAMIENTO_SERVICIO S4
WHERE S3.id = S4.idServicio
AND S4.idAlojamiento = @idAlojamiento)	
		
		
END
