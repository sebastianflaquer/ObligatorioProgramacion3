CREATE PROCEDURE [dbo].[CargarServicios]
	AS
	BEGIN
		SET NOCOUNT ON

		Select *
		From [dbo].[SERVICIO]
		order by nombre
		
		END
