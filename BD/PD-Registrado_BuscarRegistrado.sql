CREATE PROCEDURE Registrado_BuscarRegistrado
	As
	BEGIN
		SET NOCOUNT ON

		Select * 
		From [dbo].[REGISTRADO]
	END
	GO

--exec Registrado_BuscarRegistrado