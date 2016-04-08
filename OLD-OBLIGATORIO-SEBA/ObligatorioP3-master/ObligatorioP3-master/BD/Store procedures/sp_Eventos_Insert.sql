CREATE PROCEDURE Eventos_Insert
	@Titulo varchar(30),
	@Descripcion varchar(300),
	@NombreArtistas varchar(300),
	@Fecha date,
	@Hora time(7),
	@NombreLugar varchar(50),
	@DireccionLugar varchar(50),
	@BarrioLugar varchar(30),
	@CapasidadMaxima varchar(30),
	@Imagen varbinary(max),
	@Precio varchar(300),
	@Estado char(1),
	@idEmpresa int
	As
	BEGIN
		SET NOCOUNT ON

		INSERT INTO Eventos
			(
			 Titulo,
			 Descripcion,
			 NombreArtistas,
			 Fecha,
			 Hora,
			 NombreLugar,
			 DireccionLugar,
			 BarrioLugar,
			 CapasidadMaxima,
			 Imagen,
			 Precio,
			 Estado,
			 idEmpresa
			 )
		VALUES
			(
			 @Titulo,
			 @Descripcion,
			 @NombreArtistas,
			 @Fecha,
			 @Hora,
			 @NombreLugar,
			 @DireccionLugar,
			 @BarrioLugar,
			 @CapasidadMaxima,
			 @Imagen,
			 @Precio,
			 @Estado,
			 @idEmpresa
			)
			END
			GO


--Probamos el procedimiento
EXEC Eventos_Insert 'holahola','Evento de Samba','Pedro','15/12/2015','21:00:00','Lugar2','Calle 2',00000,'520','D','1'