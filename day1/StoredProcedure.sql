CREATE PROCEDURE GetMaxPrice1
	@FirstNumber int,
	@SecondNumber int
AS
BEGIN
    SELECT MAX(UnitPrice) FROM Sales.SalesOrderDetail Detail
	WHERE Detail.SalesOrderID NOT BETWEEN @FirstNumber AND @SecondNumber 
	AND Detail.UnitPrice < 2000
		
END
GO

EXEC GetMaxPrice1 5000,6000