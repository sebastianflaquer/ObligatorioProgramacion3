create PROCEDURE [dbo].[LeerCategoria]
	@nombre varchar(30)
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From CATEGORIA
		where nombre = @nombre
	END

