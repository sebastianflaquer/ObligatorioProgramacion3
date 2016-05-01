create PROCEDURE [dbo].[LeerAnuncioXId]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From ANUNCIO
		where id = @id
	END
