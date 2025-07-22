CREATE PROCEDURE [dbo].[ObtenerModelos]
    @IdMarca UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        id,
        Nombre 
    FROM Modelos
    WHERE IdMarca = @IdMarca;
END;