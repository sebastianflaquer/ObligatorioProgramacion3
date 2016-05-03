

create procedure [dbo].[ModificarAnuncio]
	@id int,
	@nombre varchar(60),
	@idAlojamiento int,
	@descripcion varchar(250),
	@direccion1 varchar(40),
	@direccion2 varchar(40),
	@fotos varchar(200),
	@precioBase decimal(12,2)


	as
	begin

	update ANUNCIO
	set nombre = @nombre,
	idAlojamiento = @idAlojamiento,
	descripcion = @descripcion,
	direccion1 = @direccion1,
	direccion2 = @direccion2,
	fotos = @fotos,
	precioBase = @precioBase
	where id = @id

	end 
