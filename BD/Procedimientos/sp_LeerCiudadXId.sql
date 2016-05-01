create PROCEDURE [dbo].[LeerCiudadXId]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From CIUDAD
		where id = @id
	END
