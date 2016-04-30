USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[LeerAlojamiento]    Script Date: 29/04/2016 22:22:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[LeerAlojamientoPorUsuario]
	@nombre VARCHAR(60),
	@idRegistrado int

	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From ALOJAMIENTO
		where nombre = @nombre
		and idRegistrado = @idRegistrado
	END
