USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[EliminarAnuncio]    Script Date: 03/05/2016 14:23:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[EliminarAnuncio] 
	@id int
AS
BEGIN
	DELETE FROM ANUNCIO WHERE id = @id;
END