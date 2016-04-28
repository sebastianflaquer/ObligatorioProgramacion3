USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[AlojamientosPorUsuario]    Script Date: 28/04/2016 14:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[AlojamientosPorUsuario]
	@mail VARCHAR(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select A.id, A.nombre
		From ALOJAMIENTO A, REGISTRADO R
		where a.idRegistrado = r.id
		AND R.mail = @mail
	END
