

ALTER PROCEDURE [dbo].[NuevoServicio] 
	@idAlojamiento int,
	@nombre varchar(20),
	@descripcion varchar(250)
AS
BEGIN
	-- Insert statements for procedure here
	INSERT INTO SERVICIO VALUES(@nombre, @descripcion, @idAlojamiento);
END

