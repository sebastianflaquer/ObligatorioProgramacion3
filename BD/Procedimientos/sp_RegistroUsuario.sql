USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[RegistroUsuario]    Script Date: 20/04/2016 11:26:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[RegistroUsuario]
	-- Add the parameters for the stored procedure here
	@nombre VARCHAR(30),
	@apellido VARCHAR(40),
	@mail VARCHAR(50),
	@password VARCHAR(20),
	@direccion VARCHAR(50),
	@celular VARCHAR(20),
	@foto VARCHAR(500),
	@descripcion VARCHAR(250)
As BEGIN
SET NOCOUNT ON
	
	Insert into REGISTRADO ([nombre],[apellido],[mail],[password],[direccion],[celular],[foto],[descripcion]) values 
		(@nombre, @apellido, @mail, @password, @direccion, @celular, @foto, @descripcion)

END
