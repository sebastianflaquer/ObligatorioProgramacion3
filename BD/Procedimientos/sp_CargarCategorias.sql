CREATE PROCEDURE [dbo].[CargarCategorias]
	AS
	BEGIN
		SET NOCOUNT ON

		Select C.nombre
		From CATEGORIA C
		
		END