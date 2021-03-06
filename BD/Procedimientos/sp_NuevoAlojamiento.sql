USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[NuevoAlojamiento]    Script Date: 28/04/2016 11:42:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[NuevoAlojamiento] 
	@IdCategoria int,
	@tipoHabitacion varchar(20),
	@banioPrivado bit,
	@cantHuespedes int,
	@calificacion int,
	@nombre varchar(60),
	@idCiudad int,
	@barrio varchar(20),
	@idRegistrado int,
	@nuevoId int out
	
AS
BEGIN
	-- Insert statements for procedure here
	INSERT INTO ALOJAMIENTO VALUES(@IdCategoria, @tipoHabitacion, @banioPrivado, @cantHuespedes, @barrio, @calificacion,
									@nombre, @idCiudad, @idRegistrado);
	SET @nuevoId = SCOPE_IDENTITY();
END