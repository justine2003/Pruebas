CREATE TABLE [dbo].[Marcas] (
    [id]     UNIQUEIDENTIFIER NOT NULL,
    [Nombre] VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED ([id] ASC)
);

