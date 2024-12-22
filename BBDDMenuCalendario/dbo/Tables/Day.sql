CREATE TABLE [dbo].[Day] (
    [Id]       INT  IDENTITY (1, 1) NOT NULL,
    [Date]     DATE NOT NULL,
    [IdMeal]   INT  NULL,
    [IdDinner] INT  NULL,
    CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Day_Dinner] FOREIGN KEY ([IdDinner]) REFERENCES [dbo].[Menu] ([Id]),
    CONSTRAINT [FK_Day_Meal] FOREIGN KEY ([IdMeal]) REFERENCES [dbo].[Menu] ([Id])
);

