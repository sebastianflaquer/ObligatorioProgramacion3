USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[LeerAnuncio]    Script Date: 03/05/2016 11:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[LeerAnuncio]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From ANUNCIO
		where id = @id
	END