using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class RunMovement:Movement
    {
        public override void Move()
        {
            Console.WriteLine("Run");
        }
    }
}
