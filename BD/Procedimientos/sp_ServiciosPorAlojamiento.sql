USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[ServiciosPorAlojamiento]    Script Date: 03/05/2016 11:37:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ServiciosPorAlojamiento]
	@idAlojamiento int
	As
	BEGIN
		SET NOCOUNT ON

select s.*
from SERVICIO S, ALOJAMIENTO_SERVICIO S2
where s.id = s2.idServicio
and idAlojamiento = @idAlojamiento
	END