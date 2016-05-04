create PROCEDURE CargarAnuncioXAlojamiento
	@idAlojamiento int
	AS
	BEGIN
	SET NOCOUNT ON

	Select id
	From [dbo].[ANUNCIO]
	where idAlojamiento = @idAlojamiento
		
	END