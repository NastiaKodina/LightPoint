using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Toy dog = new Toy(new ElectronicDogFactory());
            dog.Move();
            dog.Speak();

            Toy teddy = new Toy(new TeddyToyFactory());
            teddy.Move();
            teddy.Speak();

            Console.ReadLine();
        }
    }
}
