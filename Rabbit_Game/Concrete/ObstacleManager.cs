using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game.Obstacle
{
    using Abstract;
    using Concrete;
    public class ObstacleManager
    {
        private Queue<IObstacle> Obstacles { get; set; }
        private int _Dimension;
        public ObstacleManager(int Dimension)
        {
            this._Dimension = Dimension;
            this.Obstacles = new Queue<IObstacle>();
        }
        public Queue<IObstacle> GenerateObtacle()
        {
            for (int i = 0; i < this._Dimension; i++)
            {
                var index = new Random().Next(0, 5);
                IObstacle obstacle = GetObstacle(index);
                var asd = IsAddObstacle(obstacle);
                if (IsAddObstacle(obstacle))
                {
                    Obstacles.Enqueue(obstacle);
                }
                else
                {
                    i--;
                }
            }
            return this.Obstacles;
        }



        public IObstacle GetObstacle(int index)
        {
            IObstacle myReturnObstacle;
            switch (index)
            {
                case 1: { myReturnObstacle = new Fence(); break; }
                case 2: { myReturnObstacle = new Fox(); break; }
                case 3: { myReturnObstacle = new Wiry(); break; }
                case 4: { myReturnObstacle = new Wolf(); break; }
                default: { myReturnObstacle = new Wolf(); break; }
            }
            return myReturnObstacle;
        }

        public bool IsAddObstacle(IObstacle item)
        {
            return this.Obstacles.Where(t0 => t0.GetType() == item.GetType()).ToList().Count >= 4 ? false : true;
        }

        private double GetFactor()
        {
            double factor = 1.5;
            if (this._Dimension == 16)
                factor = 1;
            return factor;
        }



    }
}
