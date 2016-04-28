USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[LeerUsuario]    Script Date: 28/04/2016 17:52:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[LeerAlojamiento]
	@nombre VARCHAR(60)
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From ALOJAMIENTO
		where nombre = @nombre
	END
