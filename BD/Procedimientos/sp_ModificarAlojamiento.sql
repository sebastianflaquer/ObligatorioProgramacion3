USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[ModificarAlojamiento]    Script Date: 26/04/2016 16:55:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[ModificarAlojamiento]
	@id int,
	@nombre varchar(30),
	@idCategoria int,
	@tipoHabitacion varchar(20),
	@banioPrivado bit,
	@cantHuespedes int,
	@barrio varchar(20),
	@calificacion int,
	@idCiudad int

	as
	begin

	update ALOJAMIENTO
	set idCategoria = @idCategoria,
	tipoHabitacion = @tipoHabitacion,
	banioPrivado = @banioPrivado,
	cantHuespedes = @cantHuespedes,
	barrio = @barrio,
	calificacion = @calificacion,
	nombre = @nombre,
	idCiudad = @idCiudad
	where id = @id


	end