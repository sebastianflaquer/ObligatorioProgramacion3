USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[LeerCiudad]    Script Date: 03/05/2016 11:11:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[LeerCiudad]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From CIUDAD
		where id = @id
	END
