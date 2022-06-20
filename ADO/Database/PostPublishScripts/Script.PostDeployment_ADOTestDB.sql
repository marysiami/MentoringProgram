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
SELECT @productId = Id FROM dbo.Product where Name = 'Car' AND Description = 'Opel Astra'
if (@productId IS NULL)
BEGIN
    INSERT INTO [dbo].[Product]
           ([Name]
           ,[Description]
           ,[Weight]
           ,[Width]
           ,[Length])
     VALUES
           ('Car'
           , 'Opel Astra'
           ,100
           ,200
           ,100);
END
SELECT @productId = Id FROM dbo.Product where Name = 'Car' AND Description = 'Opel Astra'

BEGIN
   INSERT INTO [dbo].[Order]
           ([Status]
           ,[CreatedDate]
           ,[UpdatedDate]
           ,[ProductId])
     VALUES
           ('OK'
           ,GETDATE()
           ,GETDATE()
           ,@productId);
END
