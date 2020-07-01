using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game.Concrete
{
    using Abstract;
    public class Fox : IObstacle, IGameObject, IDead
    {
        public string Name { get; set; }
        public Fox()
        {
            this.Name = "Tilki";
        }
    }
}
