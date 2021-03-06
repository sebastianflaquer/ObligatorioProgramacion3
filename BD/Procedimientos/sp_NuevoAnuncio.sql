USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[NuevoAnuncio]    Script Date: 01/05/2016 16:21:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NuevoAnuncio] 
	@nombre varchar(50),
	@idAlojamiento int,
	@descripcion varchar(250),
	@direccion1 varchar(40),
	@direccion2 varchar(40),
	@fotos varchar(200),
	@preciobase decimal(12,2),
	@idRegistrado int,
	@nuevoId int out
AS
BEGIN
	-- Insert statements for procedure here
	INSERT INTO ANUNCIO VALUES(@nombre, @idAlojamiento, @descripcion, @direccion1, @direccion2, @preciobase, @idRegistrado, @fotos);
	SET @nuevoId = SCOPE_IDENTITY();
END