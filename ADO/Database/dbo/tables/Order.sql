
CREATE TABLE [dbo].[Order](
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[Status] [nvarchar](50) NOT NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[ProductId] [int] NULL,
	CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id]))



