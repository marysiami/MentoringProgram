CREATE PROCEDURE GetOrdersProcedure @Status nvarchar(50), @CreatedDateFrom date, @CreatedDateTo date, @ProductId int
AS
BEGIN
    SELECT *
    FROM [dbo].[Order]
	WHERE Status = @Status AND CreatedDate > @CreatedDateFrom AND CreatedDate <= @CreatedDateTo AND ProductId = @ProductId 
END
