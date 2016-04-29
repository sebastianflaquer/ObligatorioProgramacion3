create PROCEDURE [dbo].[ServiciosPorAlojamiento]
	@idAloj int
	As
	BEGIN
		SET NOCOUNT ON

select s.*
from SERVICIO s
where idAlojamiento = @idAloj
	END