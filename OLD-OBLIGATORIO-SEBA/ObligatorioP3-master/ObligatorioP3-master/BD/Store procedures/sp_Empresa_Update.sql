CREATE PROCEDURE Update_Empresa	
	@Nombre varchar(30),
	@Telefono varchar(50),
	@Mails varchar(300),
	@Url varchar(50),
	@idEmpresa int

	As BEGIN
	SET NOCOUNT ON

		UPDATE Empresas
		SET Nombre=@Nombre,Telefono=@Telefono, Mails=@Mails, Url=@Url
		WHERE IdEmpresa=@idEmpresa;
	END 
	GO

	exec Empresa_Insert 'Juan','123456','hola','holaurl', 7