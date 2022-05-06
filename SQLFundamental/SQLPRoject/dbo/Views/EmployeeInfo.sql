CREATE VIEW [dbo].[EmployeeInfo]
	AS SELECT 
	e.Id as EmployeeID, 
	CASE
        WHEN e.EmployeeName IS NOT NULL 
            THEN e.EmployeeName
            ELSE CONCAT(p.FirstName,' ',p.LastName )
    END as EmployeeName,
	CONCAT(a.ZipCode,'_',a.State,', ',a.City,'-',a.Street) AS EmplyeeAddress
	FROM Employee e
	LEFT JOIN dbo.Person p on e.PersonId = p.Id
	LEFT JOIN dbo.Address a on e.AddressId = a.Id
	LEFT JOIN dbo.Company c on c.AddressId = a.Id
	ORDER BY c.Name, a.City OFFSET 0 ROWS;

