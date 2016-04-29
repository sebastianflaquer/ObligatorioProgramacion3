USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[AlojamientosPorUsuario]    Script Date: 29/04/2016 19:47:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[AnunciosPorUsuario]
	@mail VARCHAR(50)
	As
	BEGIN
		SET NOCOUNT ON

		Select A.id, A.nombre
		From ANUNCIO A, REGISTRADO R
		where a.idRegistrado = r.id
		AND R.mail = @mail
	END

