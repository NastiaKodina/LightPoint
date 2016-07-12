using Dapper;
using System.Collections.Generic;

namespace TryDapper
{
    public class QueryProcessor
    {
        private const string ConnectionStringName = "AdventureWorks";

        private readonly DatabaseConnectionProvider _connectionProvider;
        private readonly ConfigurationProvider _configurationProvider;

        public QueryProcessor(DatabaseConnectionProvider connectionProvider, ConfigurationProvider configurationProvider)
        {
            _connectionProvider = connectionProvider;
            _configurationProvider = configurationProvider;
        }

        public IEnumerable<Person> GetPersons()
        {
            IEnumerable<Person> result;
            var connectionString = _configurationProvider.GetConnectionString(ConnectionStringName);

            using (var connection = _connectionProvider.GetConnection(connectionString))
            {
                connection.Open();
                result = connection.Query<Person>("SELECT FirstName, LastName, Title, EmailPromotion FROM Person.Person");
                connection.Close();
            }

            return result;
        }

        public IEnumerable<StateProvince> GetProvinces()
        {
            IEnumerable<StateProvince> result;
            var connectionString = _configurationProvider.GetConnectionString(ConnectionStringName);

            using (var connection = _connectionProvider.GetConnection(connectionString))
            {
                connection.Open();
                result = connection.Query<StateProvince>("SELECT Province.TerritoryID  FROM Person.StateProvince Province " + 
                                                          "WHERE(Province.Name LIKE 'A%' OR Province.Name LIKE '%s') AND " +
                                                          "Province.TerritoryID >= 4 AND " +
                                                          "Province.CountryRegionCode = 'FR' " +
                                                          "ORDER BY Province.Name DESC");
                connection.Close();
            }

            return result;
        }

        public IEnumerable<Department> GetDepartmentNames()
        {
            IEnumerable<Department> result;
            var connectionString = _configurationProvider.GetConnectionString(ConnectionStringName);

            using (var connection = _connectionProvider.GetConnection(connectionString))
            {
                connection.Open();
                result = connection.Query<Department>("SELECT Department.Name FROM HumanResources.Department Department " +
                                                       "INNER JOIN HumanResources.EmployeeDepartmentHistory History ON " +
                                                       "History.DepartmentID = Department.DepartmentID " +
                                                       "LEFT JOIN HumanResources.Shift Shift ON " +
                                                       "History.ShiftID = Shift.ShiftID " +
                                                       "WHERE Department.Name LIKE '%in%' ");
                connection.Close();
            }

            return result;
        }

        public IEnumerable<Product> GetDepartmentProducts()
        {
            IEnumerable<Product> result;
            var connectionString = _configurationProvider.GetConnectionString(ConnectionStringName);

            using (var connection = _connectionProvider.GetConnection(connectionString))
            {
                connection.Open();
                result = connection.Query<Product>("SELECT Products.Name, Products.ProductNumber " +
                                                       "FROM ( SELECT * FROM Production.Product p WHERE p.Color = 'Black') AS Products " +
                                                       "INNER JOIN Production.ProductModel Model ON Products.ProductModelID = Model.ProductModelID " +
                                                       "INNER JOIN Production.ProductSubcategory Subcategory ON Subcategory.ProductSubcategoryID = Products.ProductSubcategoryID " +
                                                       "INNER JOIN Production.ProductCategory Category ON Category.ProductCategoryID = Subcategory.ProductCategoryID ");
                connection.Close();
            }

            return result;
        }
    }
}
