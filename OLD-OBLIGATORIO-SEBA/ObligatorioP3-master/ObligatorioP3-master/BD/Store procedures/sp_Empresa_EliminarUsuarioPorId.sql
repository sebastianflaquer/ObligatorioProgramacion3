CREATE PROCEDURE Eliminar_UsuarioxEmpresa
	@idUsuario int

	As
	BEGIN
		SET NOCOUNT ON

		DELETE FROM Usuarios
		WHERE Usuarios.idUsuario=@idUsuario;
		
	END
	GO


