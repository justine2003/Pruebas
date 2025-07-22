CREATE PROCEDURE [dbo].[AgregarMarca]
    @id as uniqueidentifier,
    @Nombre VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

	Begin Transaction

    INSERT INTO [dbo].[Marcas] 
	      ([id], 
		   [Nombre])
    VALUES 
	(@id, 
	@Nombre)
	SELECT @id
	COMMIT TRANSACTION


END;