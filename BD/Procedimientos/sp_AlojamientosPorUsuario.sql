
CREATE PROCEDURE [dbo].[AlojamientosPorUsuario]
	@mail VARCHAR(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select A.id
		From ALOJAMIENTO A, REGISTRADO R, ANUNCIO A2
		where A2.idAlojamiento = A.id
		AND A2.idRegistrado = R.id
		AND R.mail = @mail
	END
