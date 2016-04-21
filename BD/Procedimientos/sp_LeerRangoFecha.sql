USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[LeerServicio]    Script Date: 21/04/2016 19:53:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerRangoFecha]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From RANGOFECHAS
		where id = @id
	END