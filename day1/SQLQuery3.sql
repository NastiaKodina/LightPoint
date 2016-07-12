SELECT * FROM Person.StateProvince Province
WHERE (Province.Name LIKE 'A%' OR
	  Province.Name LIKE '%s') AND
	  Province.TerritoryID >= 4 AND
	  Province.CountryRegionCode = 'FR'
ORDER BY Province.Name DESC
