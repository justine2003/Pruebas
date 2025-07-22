CREATE TABLE [dbo].[Modelos] (
    [id]      UNIQUEIDENTIFIER NOT NULL,
    [IdMarca] UNIQUEIDENTIFIER NULL,
    [Nombre]  VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_Modelos] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Modelos_Marcas] FOREIGN KEY ([IdMarca]) REFERENCES [dbo].[Marcas] ([id])
);

