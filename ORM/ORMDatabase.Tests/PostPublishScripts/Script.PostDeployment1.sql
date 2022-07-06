/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DECLARE @productId INT 
SELECT @productId = Id FROM dbo.Products where Name = 'Car'
if (@productId IS NULL)
BEGIN
    INSERT INTO dbo.Products (Name, Description, Weight, Width, Length)
    VALUES ('Car', 'Black', 10, 100, 20);
END
SELECT @productId = Id FROM dbo.Person where Name = 'Car'

DECLARE @orderId INT 
SELECT @orderId = Id FROM dbo.Orders where Status = 1 AND ProductId = @productId
if (@orderId IS NULL)
BEGIN
    INSERT INTO dbo.Orders(Status, CreatedDate, UpdatedDate, ProductId)
    VALUES (1, GETDATE(), GETDATE(), @productId);
END

DECLARE @productId INT 
SELECT @productId = Id FROM dbo.Products where Name = 'Cat'
if (@productId IS NULL)
BEGIN
    INSERT INTO dbo.Products (Name, Description, Weight, Width, Length)
    VALUES ('Cat', 'Red', 25, 5, 45);
END
SELECT @productId = Id FROM dbo.Person where Name = 'Cat'

DECLARE @orderId INT 
SELECT @orderId = Id FROM dbo.Orders where Status = 1 AND ProductId = @productId
if (@orderId IS NULL)
BEGIN
    INSERT INTO dbo.Orders(Status, CreatedDate, UpdatedDate, ProductId)
    VALUES (1, GETDATE(), GETDATE(), @productId);
END

DECLARE @productId INT 
SELECT @productId = Id FROM dbo.Products where Name = 'Dog'
if (@productId IS NULL)
BEGIN
    INSERT INTO dbo.Products (Name, Description, Weight, Width, Length)
    VALUES ('Dog', 'Yellow', 22, 52, 435);
END
SELECT @productId = Id FROM dbo.Person where Name = 'Dog'

DECLARE @orderId INT 
SELECT @orderId = Id FROM dbo.Orders where Status = 1 AND ProductId = @productId
if (@orderId IS NULL)
BEGIN
    INSERT INTO dbo.Orders(Status, CreatedDate, UpdatedDate, ProductId)
    VALUES (1, GETDATE(), GETDATE(), @productId);
END