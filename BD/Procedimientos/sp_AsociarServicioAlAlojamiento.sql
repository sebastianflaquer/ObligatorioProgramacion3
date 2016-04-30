USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[NuevoServicio]    Script Date: 30/04/2016 15:35:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[AsociarServicioAlAlojamiento] 
	@idAlojamiento int,
	@idServicio int

AS
BEGIN
	-- Insert statements for procedure here
	INSERT INTO ALOJAMIENTO_SERVICIO VALUES(@idAlojamiento, @idServicio);
END
