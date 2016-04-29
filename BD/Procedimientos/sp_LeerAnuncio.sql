create PROCEDURE [dbo].[LeerAnuncio]
	@nombre VARCHAR(30)
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From ANUNCIO
		where nombre = @nombre
	END
