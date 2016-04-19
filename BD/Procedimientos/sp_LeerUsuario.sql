create PROCEDURE LeerUsuario
	@mail VARCHAR(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From REGISTRADO
		where mail = @mail
	END
	GO

--exec Usuario_BuscarUsuario