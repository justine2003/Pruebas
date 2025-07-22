-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerVehiculo
	@id uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT        Vehiculo.id, Vehiculo.IdModelo, Vehiculo.Placa, Vehiculo.Color, Vehiculo.Precio, Vehiculo.Anio, Vehiculo.CorreoPropietario, Vehiculo.TelefonoPropietario, Modelos.Nombre AS Modelo, Marcas.Nombre AS Marca
FROM            Vehiculo INNER JOIN
                         Modelos ON Vehiculo.IdModelo = Modelos.id INNER JOIN
                         Marcas ON Modelos.IdMarca = Marcas.id
WHERE        (Vehiculo.id = @Id)
END