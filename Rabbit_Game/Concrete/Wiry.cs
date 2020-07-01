using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game.Concrete
{
    using Abstract;
    //Tel
    public class Wiry : IObstacle, IGameObject, IBarrier
    {
        public string Name { get; set; }
        public Wiry()
        {
            this.Name = "Tel";
        }
    }
}
