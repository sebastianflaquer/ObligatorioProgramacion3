USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[LeerAlojamiento]    Script Date: 03/05/2016 11:06:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[LeerAlojamiento]
	@id int
	As
	BEGIN
		SET NOCOUNT ON

		Select *
		From ALOJAMIENTO
		where id = @id
	END
