CREATE TRIGGER [trigger_InsertCompany]
	ON Employee
	FOR INSERT
	AS
	BEGIN
		INSERT INTO Company (Name, AddressId)		
		SELECT i.CompanyName, i.AddressId
		FROM inserted AS i
		
	END
