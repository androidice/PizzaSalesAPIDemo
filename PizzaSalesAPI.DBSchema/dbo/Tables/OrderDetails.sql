CREATE TABLE [dbo].[OrderDetails] (
    [Id]       INT          NOT NULL,
    [OrderId]  INT          NULL,
    [PizzaId]  VARCHAR (50) NULL,
    [Quantity] INT          NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderDetails_Pizzas] FOREIGN KEY ([PizzaId]) REFERENCES [dbo].[Pizzas] ([Id])
);



