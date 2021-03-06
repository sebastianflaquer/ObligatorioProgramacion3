USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[ModificarAlojamiento]    Script Date: 03/05/2016 15:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ModificarAlojamiento]
	@id int,
	@nombre varchar(60),
	@idCategoria int,
	@tipoHabitacion varchar(20),
	@banioPrivado bit,
	@cantHuespedes int,
	@idCiudad int,
	@barrio varchar(25)

	as
	begin

	update ALOJAMIENTO
	set nombre = @nombre,
	idCategoria = @idCategoria,
	tipoHabitacion = @tipoHabitacion,
	banioPrivado = @banioPrivado,
	cantHuespedes = @cantHuespedes,
	idCiudad = @idCategoria, 
	barrio = @barrio
	where id = @id

	end