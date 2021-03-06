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

DECLARE @personId INT 
SELECT @personId = Id FROM dbo.Person where FirstName = 'Demo' AND LastName = 'User'
if (@personId IS NULL)
BEGIN
    INSERT INTO dbo.Person (FirstName, LastName)
    VALUES ('Demo', 'User');
END
SELECT @personId = Id FROM dbo.Person where FirstName = 'Demo' AND LastName = 'User'

DECLARE @addressId INT 
SELECT @addressId = Id FROM dbo.Address where Street = 'Warszawska' AND City = 'Bialystok' AND State = 'Podlasie' AND ZipCode = '00-001'
if (@addressId IS NULL)
BEGIN
    INSERT INTO dbo.Address(Street, City, State, ZipCode)
    VALUES ('Warszawska', 'Bialystok', 'Podlasie', '00-001');
END

SELECT @addressId = Id FROM dbo.Address where Street = 'Warszawska' AND City = 'Bialystok' AND State = 'Podlasie' AND ZipCode = '00-001'


DECLARE @companyId INT
SELECT @companyId = Id FROM dbo.Company where Name = 'DemoCompany' AND AddressId = @addressId
if (@companyId IS NULL)
BEGIN
    INSERT INTO dbo.Company(Name, AddressId)
    VALUES ('DemoCompany', @addressId);
END

SELECT @addressId = Id FROM dbo.Company where Name = 'DemoCompany' AND AddressId = @addressId

DECLARE @employeeId INT
SELECT @employeeId = Id FROM dbo.Employee where AddressId = @addressId AND PersonId = @personId AND CompanyName = 'DemoDemo' AND Position = 'line worker' AND EmployeeName = 'developer'
if (@employeeId IS NULL)
BEGIN
    INSERT INTO dbo.Employee(AddressId, PersonId, CompanyName, Position, EmployeeName)
    VALUES (@addressId, @personId, 'DemoCompany','line worker', 'Demo User');

END

