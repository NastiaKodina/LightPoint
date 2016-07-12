using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryProcessor = new QueryProcessor(new DatabaseConnectionProvider(), new ConfigurationProvider());

            //var persons = queryProcessor.GetPersons();
            // var provinces = queryProcessor.GetProvinces();
            // var departments = queryProcessor.GetDepartmentNames();
            var products = queryProcessor.GetDepartmentProducts();
            Console.ReadKey();
        }
    }
}
