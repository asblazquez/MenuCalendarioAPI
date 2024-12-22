CREATE TABLE [dbo].[User] (
    [Id]       INT           NOT NULL,
    [Name]     VARCHAR (50)  NOT NULL,
    [LastName] VARCHAR (150) NOT NULL,
    [Email]    VARCHAR (150) NOT NULL,
    [Password] VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

