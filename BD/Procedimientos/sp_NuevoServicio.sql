USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[NuevoServicio]    Script Date: 20/04/2016 14:28:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NuevoServicio] 
	@Nombre varchar(20),
	@Descripcion varchar(250)
AS
BEGIN
	-- Insert statements for procedure here
	INSERT INTO SERVICIO VALUES(@Nombre, @Descripcion);
END

