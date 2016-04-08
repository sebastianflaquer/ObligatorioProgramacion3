CREATE PROCEDURE Empresa_CargarDatos
	As
	BEGIN
		SET NOCOUNT ON

		Select * 
		From Empresas
	END
	GO

exec Empresa_CargarDatos