SELECT * FROM HumanResources.Department Department
INNER JOIN HumanResources.EmployeeDepartmentHistory History ON
	History.DepartmentID = Department.DepartmentID
LEFT JOIN HumanResources.Shift Shift ON
History.ShiftID = Shift.ShiftID
WHERE Department.Name LIKE '%in%' 