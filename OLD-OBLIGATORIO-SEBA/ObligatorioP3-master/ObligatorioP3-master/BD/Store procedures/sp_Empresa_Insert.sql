CREATE PROCEDURE Empresa_Insert	
	@Nombre varchar(30),
	@Telefono varchar(50),
	@Mails varchar(300),
	@Url varchar(50),
	@idUsuario int

	As BEGIN
	SET NOCOUNT ON

	Insert into Empresas( Nombre, Telefono, Mails, Url, idUsuario) VALUES
		(@Nombre, @Telefono,@Mails,@Url,@idUsuario)
	END 
	GO

	exec Empresa_Insert 'Juan','123456','hola','holaurl', 7