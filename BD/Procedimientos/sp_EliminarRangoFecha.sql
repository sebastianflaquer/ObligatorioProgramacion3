USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[EliminarRangoFecha]    Script Date: 03/05/2016 14:29:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[EliminarRangoFecha] 
	@idAnuncio int
AS
BEGIN
	DELETE FROM RANGOFECHAS WHERE idAnuncio = @idAnuncio;
END