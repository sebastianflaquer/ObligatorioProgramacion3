USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[NuevoServicio]    Script Date: 21/04/2016 19:38:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].NuevoRangoFechas 
	@fechaIni datetime,
	@fechaFin datetime,
	@precio decimal (12,2),
	@idAnuncio int
AS
BEGIN
	-- Insert statements for procedure here
	INSERT INTO RANGOFECHAS VALUES(@fechaIni, @fechaFin, @precio, @idAnuncio);
END