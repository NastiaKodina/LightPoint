using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class OrangeJuice:IJuice
    {
        public string JuiceProduction()
        {
            return "Orange Juice";
        }
    }
}
