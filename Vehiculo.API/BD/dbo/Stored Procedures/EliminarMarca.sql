CREATE PROCEDURE [dbo].[EliminarMarca]
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

	Begin Transaction
    DELETE FROM Marcas
    WHERE (Id = @Id)
	SELECT @Id
	COMMIT Transaction
END;