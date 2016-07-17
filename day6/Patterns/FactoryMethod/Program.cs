using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator creator = new Creator();
            for (int i = 0; i <= 3; i++)
            {
                var type = creator.FactoryMethod(i);
                if (type != null)
                {
                    Console.WriteLine("This is Product : " + type.JuiceProduction());
                }
            }
            Console.ReadLine();
        }
    }
}
