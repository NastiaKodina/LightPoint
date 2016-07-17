using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class ElectronicDogFactory:ToyFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();

        }

        public override Sound CreateSound()
        {
            return new Growl();
        }

    }
}
