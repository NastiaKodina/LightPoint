using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TryDapper
{
    public class ConfigurationProvider
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ToString();
        }
    }
}
