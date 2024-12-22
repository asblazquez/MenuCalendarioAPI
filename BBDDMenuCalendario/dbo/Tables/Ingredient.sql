CREATE TABLE [dbo].[Ingredient] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (150) NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED ([Id] ASC)
);

