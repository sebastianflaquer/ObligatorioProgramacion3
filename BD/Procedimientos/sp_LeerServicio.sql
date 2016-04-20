USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[LeerUsuario]    Script Date: 20/04/2016 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerServicio]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From SERVICIO
		where id = @id
	END

