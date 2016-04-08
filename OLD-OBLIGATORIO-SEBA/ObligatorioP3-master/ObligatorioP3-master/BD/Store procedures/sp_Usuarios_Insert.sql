CREATE PROCEDURE Usuarios_Insert	
	@mailPrimario varchar(50),
	@Password varchar(50)
	As BEGIN
	SET NOCOUNT ON

	Insert into Usuarios ( MailUsuario,	PassUsuario, IdRol) VALUES
		(@mailPrimario, @Password, 1)
		SELECT SCOPE_IDENTITY()

	END 
	GO

