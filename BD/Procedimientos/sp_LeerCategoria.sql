USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[LeerCategoria]    Script Date: 03/05/2016 11:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[LeerCategoria]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From CATEGORIA
		where id = @id
	END