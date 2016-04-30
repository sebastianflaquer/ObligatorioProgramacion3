create PROCEDURE [dbo].[LeerAnuncioPorUsuario]
	@nombre VARCHAR(60),
	@idRegistrado int

	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From ANUNCIO
		where nombre = @nombre
		and idRegistrado = @idRegistrado
	END
