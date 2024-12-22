CREATE TABLE [dbo].[Menu] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (150) NOT NULL,
    [Description] VARCHAR (250) NULL,
    CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED ([Id] ASC)
);

