CREATE PROCEDURE Empresa_EliminarPorId
	@idEmpresa int
	As
	BEGIN
		SET NOCOUNT ON

		DELETE FROM Empresas
		WHERE Empresas.idEmpresa=@idEmpresa
		
	END
	GO


	exec Empresa_EliminarPorId 2