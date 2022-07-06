
CREATE TABLE [dbo].[Orders](
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Status]  [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[ProductId] [int] NULL,
	CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id]))



