CREATE PROCEDURE Admin_CargarDatos
	As
	BEGIN
		SET NOCOUNT ON

		Select * 
		From Administradores
	END
	GO

exec Admin_CargarDatos