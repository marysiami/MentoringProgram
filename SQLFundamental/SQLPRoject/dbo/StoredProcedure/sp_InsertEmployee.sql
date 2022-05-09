CREATE PROCEDURE [dbo].[sp_InsertEmployee]
	@EmployeeName nvarchar(100),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@CompanyName nvarchar(20),
	@Position nvarchar(30),
	@Street nvarchar(50),
	@City nvarchar(20),
	@State nvarchar(20),
	@ZipCode nvarchar(50)
AS
	IF(
		TRIM(@LastName) IS NULL AND 
		TRIM(@FirstName) IS NULL AND 
		TRIM(@EmployeeName) IS NULL 
	) 
	RETURN 0

	ELSE 
		BEGIN

		DECLARE @AddresID INT, @PersonID INT

		INSERT INTO Person (FirstName,LastName)
		VALUES (@FirstName,@LastName)
		SET @PersonID = SCOPE_IDENTITY()

		INSERT INTO Address (Street, City, State, ZipCode)
		VALUES (@Street, @City, @State, @ZipCode)
		SET @AddresID = SCOPE_IDENTITY()
		
		IF LEN(@CompanyName) > 20
		SET @CompanyName = SUBSTRING(@CompanyName, 1, 20)		

		INSERT INTO Employee (EmployeeName, CompanyName, Position, AddressId, PersonId)
		VALUES (@EmployeeName, @CompanyName, @Position, @AddresID, @PersonID)

		END
RETURN 0
