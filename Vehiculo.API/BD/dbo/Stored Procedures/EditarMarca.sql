CREATE PROCEDURE [dbo].[EditarMarca]
    @Id UNIQUEIDENTIFIER,
    @Nombre VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

	Begin Transaction
    UPDATE [dbo].[Marcas]
    SET [Nombre] = @Nombre
    WHERE Id = @Id;
	Select @Id
	COMMIT Transaction
  
END;