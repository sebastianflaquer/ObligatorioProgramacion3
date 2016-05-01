create PROCEDURE [dbo].[ServiciosPorAlojamiento]
	@idAlojamiento int
	As
	BEGIN
		SET NOCOUNT ON

select s.*
from SERVICIO S, ALOJAMIENTO_SERVICIO S2
where idAlojamiento = @idAlojamiento
	END