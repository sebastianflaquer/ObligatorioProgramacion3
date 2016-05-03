CREATE PROCEDURE [dbo].[EliminarAlojamientoServicio] 
	@IdAlojamiento int
AS
BEGIN
	DELETE FROM ALOJAMIENTO_SERVICIO WHERE idAlojamiento = @IdAlojamiento
END

GO
