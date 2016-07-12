SELECT Products.Name, Products.ProductNumber,
	   Model.Name AS Model,
	   Category.Name AS Category, 
	   Subcategory.Name AS Subcategory 
FROM
(
	SELECT * FROM Production.Product p
	WHERE
		p.Color = 'Black'
) AS Products
INNER JOIN Production.ProductModel Model ON 
	Products.ProductModelID = Model.ProductModelID
INNER JOIN Production.ProductSubcategory Subcategory ON
	Subcategory.ProductSubcategoryID = Products.ProductSubcategoryID
INNER JOIN Production.ProductCategory Category ON
	Category.ProductCategoryID = Subcategory.ProductCategoryID

