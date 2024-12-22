CREATE TABLE [dbo].[Step] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [IdMenu]      INT           NOT NULL,
    [Title]       VARCHAR (150) NOT NULL,
    [Description] VARCHAR (250) NOT NULL,
    [StepNumber]  INT           NOT NULL,
    CONSTRAINT [PK_Step] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Step_Menu] FOREIGN KEY ([IdMenu]) REFERENCES [dbo].[Menu] ([Id])
);

