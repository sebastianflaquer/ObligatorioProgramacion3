USE [BienvenidosUY]
GO
/****** Object:  StoredProcedure [dbo].[CargarCategorias]    Script Date: 23/04/2016 14:26:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CargarCategorias]
	AS
	BEGIN
		SET NOCOUNT ON

		Select *
		From CATEGORIA C
		
		END