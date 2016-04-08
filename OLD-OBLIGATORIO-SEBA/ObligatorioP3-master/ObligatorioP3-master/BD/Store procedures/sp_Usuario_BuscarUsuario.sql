CREATE PROCEDURE Usuario_BuscarUsuario
	As
	BEGIN
		SET NOCOUNT ON

		Select * 
		From Usuarios
	END
	GO

exec Usuario_BuscarUsuario