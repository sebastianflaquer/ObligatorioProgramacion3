USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[AlojamientosPorUsuario]    Script Date: 01/05/2016 17:46:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[AlojamientosPorUsuario]
	@mail VARCHAR(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select A.*
		From ALOJAMIENTO A, REGISTRADO R
		where a.idRegistrado = r.id
		AND R.mail = @mail
	END
