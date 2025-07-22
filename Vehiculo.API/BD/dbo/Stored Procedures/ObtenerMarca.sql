CREATE PROCEDURE [dbo].[ObtenerMarca]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        id,
        Nombre 
    FROM Marcas
    WHERE id = @Id;
END;