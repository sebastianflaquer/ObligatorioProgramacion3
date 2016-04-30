create procedure [dbo].[CargarServiciosPorAlojamiento]
@idAlojamiento int

as
begin
select S.*
from ALOJAMIENTO A, ALOJAMIENTO_SERVICIO A2, SERVICIO S
where s.id = a2.idServicio
and a2.idAlojamiento = a.id
and a2.idAlojamiento = @idAlojamiento
end
