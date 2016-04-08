 CREATE PROCEDURE Eliminar_EventoxEmpresa
	@idEmpresa varchar(50)
	As
	BEGIN
		SET NOCOUNT ON

		DELETE FROM Eventos
		WHERE Eventos.idEmpresa=@idEmpresa
		
	END
	GO