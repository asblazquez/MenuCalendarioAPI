CREATE TABLE [master].[Store] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([Id] ASC)
);

