--CREATE DATABASE OrderHomework1

USE OrderHomework1

CREATE TABLE [dbo].[OrderItem] (
    [Id]                        INT             IDENTITY (1, 1)			NOT NULL,
    [ItemName]					NVARCHAR (120)  DEFAULT ('')			NOT NULL,
	[Producer]					NVARCHAR (120)  DEFAULT ('')			NOT NULL,
    [UnitPrice]                 MONEY           DEFAULT (0)				NOT NULL,	
	[IsDeleted]                 BIT             DEFAULT (0)				NOT NULL,

    CONSTRAINT [PK_OrderItem_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    
);

CREATE TABLE [dbo].[Order] (
    [Id]                            INT             IDENTITY (1, 1)							NOT NULL,	
    [OrderItemId]					INT														NOT NULL,
	[ItemsQuantity]                 INT				DEFAULT (0)								NOT NULL,
	[OrderDate]						DATETIME		DEFAULT ('0001-01-01 00:00:00.0000000')	NOT NULL,
	[OrderStatus]					NVARCHAR(20)	DEFAULT ('')							NOT NULL,
	[IsInternationalTransaction]    BIT             DEFAULT (0)								NOT NULL,
	[IsDeleted]                     BIT             DEFAULT (0)								NOT NULL,

    CONSTRAINT [PK_Order_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Order_OrderItemId_OrderItem_Id] FOREIGN KEY ([OrderItemId]) REFERENCES [dbo].[OrderItem] ([Id]),
);

CREATE TABLE [dbo].[Cart] (
    [Id]                        INT             IDENTITY (1, 1)			NOT NULL,
	[OrderId]					INT										NOT NULL,
	[Discount]					INT             DEFAULT (0)				NOT NULL,

    CONSTRAINT [PK_Cart_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cart_OrderId_Order_Id] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
	
);

USE OrderHomework1

INSERT INTO [OrderItem] (ItemName,Producer,UnitPrice,IsDeleted) VALUES ('Hand cream','Nivea',20,0)
INSERT INTO [OrderItem] (ItemName,Producer,UnitPrice,IsDeleted) VALUES ('Gel','Palmolive',10,0)
INSERT INTO [OrderItem] (ItemName,Producer,UnitPrice,IsDeleted) VALUES ('Shampoo','Garnier',30,0)
INSERT INTO [OrderItem] (ItemName,Producer,UnitPrice,IsDeleted) VALUES ('Foot cream','Shauma',75,0)

INSERT INTO [Order](OrderItemId,ItemsQuantity,OrderDate,IsInternationalTransaction,IsDeleted) VALUES (2,40,'2016-07-12 01:11:18',0,0)
INSERT INTO [Order](OrderItemId,ItemsQuantity,OrderDate,IsInternationalTransaction,IsDeleted) VALUES (1,40,'2016-07-14 10:11:18',0,0)
INSERT INTO [Order](OrderItemId,ItemsQuantity,OrderDate,IsInternationalTransaction,IsDeleted) VALUES (3,40,'2016-07-13 10:11:18',0,0)
INSERT INTO [Order](OrderItemId,ItemsQuantity,OrderDate,IsInternationalTransaction,IsDeleted) VALUES (2,40,'2016-07-18 10:11:18',0,0)

INSERT INTO [Cart](OrderId,Discount) VALUES (2,15)
INSERT INTO [Cart](OrderId,Discount) VALUES (3,25)
INSERT INTO [Cart](OrderId,Discount) VALUES (2,37)
INSERT INTO [Cart](OrderId,Discount) VALUES (4,18)
SELECT * FROM  [OrderItem]
SELECT * FROM  [Order]
SELECT * FROM  [Cart]
