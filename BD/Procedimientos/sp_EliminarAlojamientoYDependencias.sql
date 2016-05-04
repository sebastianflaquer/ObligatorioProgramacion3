create procedure EliminarAlojamientoYDependencias
	
	@idAlojamiento int,
	@idAnuncio int
	AS
	BEGIN

	--elimino los servicios
	DELETE FROM [dbo].[ALOJAMIENTO_SERVICIO] WHERE idAlojamiento = @idAlojamiento;

	--elimino los rangos
	DELETE FROM [dbo].[RANGOFECHAS] WHERE idAnuncio = @idAnuncio;

	--elimino los anuncios
	DELETE FROM [dbo].[ANUNCIO] WHERE [id] = @idAnuncio;

	--elimino los alojamientos
	DELETE FROM [dbo].[ALOJAMIENTO]  WHERE [id] = @idAlojamiento;

	END



