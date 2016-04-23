CREATE PROCEDURE [dbo].[CargarCiudades]
	AS
	BEGIN
		SET NOCOUNT ON

		Select *
		From [dbo].[CIUDAD]
		order by nombre
		
		END
