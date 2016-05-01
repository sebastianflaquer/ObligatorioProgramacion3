create PROCEDURE [dbo].[LeerAlojamientoXId]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From ALOJAMIENTO
		where id = @id
	END

