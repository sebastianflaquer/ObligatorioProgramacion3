CREATE PROCEDURE LeerUsuario
	@mail VARCHAR(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select mail
		From REGISTRADO
		where mail = @mail
	END
	GO

--exec Usuario_BuscarUsuario