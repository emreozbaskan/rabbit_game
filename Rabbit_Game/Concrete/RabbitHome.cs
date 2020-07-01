using Rabbit_Game.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game.Concrete
{
    using Abstract;
    public class RabbitHome : IGameObject
    {
        public string Name { get; set; }
        public RabbitHome()
        {
            this.Name = "T.Yuva";
        }
    }
}
