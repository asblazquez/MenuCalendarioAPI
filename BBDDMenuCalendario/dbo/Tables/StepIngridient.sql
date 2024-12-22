CREATE TABLE [dbo].[StepIngridient] (
    [IdStep]       INT NOT NULL,
    [IdIngridient] INT NOT NULL,
    CONSTRAINT [FK_StepIngridient_Ingridient] FOREIGN KEY ([IdIngridient]) REFERENCES [dbo].[Ingredient] ([Id]),
    CONSTRAINT [FK_StepIngridient_Step] FOREIGN KEY ([IdStep]) REFERENCES [dbo].[Step] ([Id])
);

