USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[EliminarRangoFecha]    Script Date: 02/05/2016 16:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[EliminarRangoFecha] 
	@id int
AS
BEGIN
	DELETE FROM RANGOFECHAS WHERE idAnuncio = @id;
END
