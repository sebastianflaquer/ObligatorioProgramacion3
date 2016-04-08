CREATE PROCEDURE Evento_EliminarPorIdEvento
	@idEvento varchar(30)
	As
	BEGIN
		SET NOCOUNT ON

		delete 
		From Eventos
		Where Eventos.idEvento = @idEvento
			END
			GO
			 

Exec Evento_EliminarPorTitulo 'Rock&Roll'