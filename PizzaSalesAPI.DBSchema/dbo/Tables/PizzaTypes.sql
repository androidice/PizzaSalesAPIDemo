CREATE TABLE [dbo].[PizzaTypes] (
    [Id]          VARCHAR (50)  NOT NULL,
    [Name]        VARCHAR (MAX) NULL,
    [Category]    VARCHAR (50)  NULL,
    [Ingredients] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_PizzaTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

