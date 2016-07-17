using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class TeddyToyFactory: ToyFactory
    {
        public override Movement CreateMovement()
        {
            return new NoMovement();

        }

        public override Sound CreateSound()
        {
            return new Singing();
        }
    }
}
