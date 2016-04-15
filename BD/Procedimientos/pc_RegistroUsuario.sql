CREATE PROCEDURE RegistroUsuario
	-- Add the parameters for the stored procedure here
	@nombre VARCHAR(30),
	@apellido VARCHAR(40),
	@mail VARCHAR(50),
	@password VARCHAR(20),
	@direccion VARCHAR(50),
	@celular VARCHAR(20),
	@foto VARBINARY,
	@descripcion VARCHAR(250)
As BEGIN
SET NOCOUNT ON
	
	Insert into REGISTRADO ([nombre],[apellido],[mail],[password],[direccion],[celular],[foto],[descripcion]) values 
		(@nombre, @apellido, @mail, @password, @direccion, @celular, @foto, @descripcion)

END
GO

-- select * from REGISTRADO