create PROCEDURE [dbo].[LeerCategoriaXId]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From CATEGORIA
		where id = @id
	END

