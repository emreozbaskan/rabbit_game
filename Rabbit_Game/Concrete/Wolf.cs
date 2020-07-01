using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game.Concrete
{
    using Abstract;
    public class Wolf : IObstacle, IGameObject, IDead
    {
        public string Name { get; set; }
        public Wolf()
        {
            this.Name = "Kurt";
        }
    }
}
