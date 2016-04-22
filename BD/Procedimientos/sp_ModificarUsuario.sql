alter procedure ModificarUsuario
	@id int,
	@nombre varchar(30),
	@apellido varchar(40),
	@mail varchar(50),
	@foto varchar(500),
	@direccion varchar(50),
	@celular varchar(20),
	@descripcion varchar(25)

	as
	begin

	update REGISTRADO
	set [nombre] = @nombre, [apellido] = @apellido,[mail] = @mail,[foto] = @foto ,[direccion] = @direccion,[celular] = @celular,[descripcion] = @descripcion
	where id = @id

	end
