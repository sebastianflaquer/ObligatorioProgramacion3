USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[EliminarAnuncio]    Script Date: 02/05/2016 16:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[EliminarAnuncio] 
	@nombre varchar(30),
	@nuevoId int out
AS
BEGIN
	DELETE FROM ANUNCIO WHERE nombre= @nombre;
	SET @nuevoId = SCOPE_IDENTITY();
END
