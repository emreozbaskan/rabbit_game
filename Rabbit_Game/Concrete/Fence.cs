using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game.Concrete
{
    using Abstract;
    //Çit
    public class Fence : IObstacle, IGameObject, IBarrier
    {
        public string Name { get; set; }
        public Fence()
        {
            this.Name = "Çit";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
