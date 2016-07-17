using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Toy
    {
        private Movement _movement;
        private Sound _sound;
        public Toy(ToyFactory toyFactory)
        {
            _movement = toyFactory.CreateMovement();
            _sound = toyFactory.CreateSound();
        }

        public void Move()
        {
            _movement.Move();
        }

        public void Speak()
        {
            _sound.Speak();
        }
    }
}
