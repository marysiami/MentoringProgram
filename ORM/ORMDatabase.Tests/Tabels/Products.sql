CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Weight] [int] NULL,
	[Width] [int] NULL,
	[Length] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) ON [PRIMARY]
GO
