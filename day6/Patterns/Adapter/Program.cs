using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square();
            square.Size = 10;
            CalculatorAdapter calculatorAdapter = new CalculatorAdapter();
            int squareArea = calculatorAdapter.GetArea(square);
            Console.WriteLine(squareArea);
            Console.ReadLine();
        }
    }
}
