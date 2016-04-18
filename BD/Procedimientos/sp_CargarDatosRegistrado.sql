create PROCEDURE CargarDatosRegistrado
	@mail VARCHAR(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From REGISTRADO
		where mail = @mail
	END