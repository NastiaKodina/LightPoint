using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class Creator
    {
        public IJuice FactoryMethod(int id)
        {
            switch (id)
            {
                case 0:
                    return new AppleJuice();
                case 1:
                    return new OrangeJuice();
                case 2:
                    return new GrapeJuice();
                default:
                    return null;
            }
        }
    }
}
