
create PROCEDURE ComprobarPassword
	@mail VARCHAR(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select password
		From REGISTRADO
		where mail = @mail
	END