create PROCEDURE [dbo].[LeerCiudad]
	@nombre varchar(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From CIUDAD
		where nombre = @nombre
	END
