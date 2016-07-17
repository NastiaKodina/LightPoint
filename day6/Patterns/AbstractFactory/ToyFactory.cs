using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class ToyFactory
    {
        public abstract Movement CreateMovement();
        public abstract Sound CreateSound();
    }
}
