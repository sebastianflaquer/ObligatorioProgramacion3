USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[ServiciosPorAlojamiento]    Script Date: 29/04/2016 20:42:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[RangoFechasPorAnuncio] 
	@idAnuncio int
	As
	BEGIN
		SET NOCOUNT ON

select RF.*
from RANGOFECHAS RF
where idAnuncio = @idAnuncio
	END
