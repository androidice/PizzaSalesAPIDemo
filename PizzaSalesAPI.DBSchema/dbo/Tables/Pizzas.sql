CREATE TABLE [dbo].[Pizzas] (
    [Id]          VARCHAR (50)    NOT NULL,
    [PizzaTypeId] VARCHAR (50)    NULL,
    [Size]        VARCHAR (5)     NULL,
    [Price]       DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Pizzas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pizzas_PizzaTypes] FOREIGN KEY ([PizzaTypeId]) REFERENCES [dbo].[PizzaTypes] ([Id]) ON DELETE CASCADE
);

