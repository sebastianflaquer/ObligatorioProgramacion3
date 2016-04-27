USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[AlojamientosPorUsuario]    Script Date: 26/04/2016 16:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AlojamientosPorUsuario]
	@mail VARCHAR(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select A.*
		From ALOJAMIENTO A, REGISTRADO R
		where r.id = a.IdRegistrado
		AND R.mail = @mail
	END
