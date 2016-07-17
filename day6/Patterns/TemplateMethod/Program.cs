using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rich man is going to start a family:");
            RichMan richMan = new RichMan();
            richMan.StartFamily();

            Console.WriteLine("\nPoor man is going to start a family:");
            PoorMan poorMan = new PoorMan();
            poorMan.StartFamily();

            Console.ReadLine();


        }
    }
}
