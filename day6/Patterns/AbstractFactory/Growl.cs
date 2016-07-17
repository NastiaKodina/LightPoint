using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class Growl: Sound
    {
        public override void Speak()
        {
            Console.WriteLine("Growl");
        }
    }
}
