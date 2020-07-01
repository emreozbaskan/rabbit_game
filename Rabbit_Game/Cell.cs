using Rabbit_Game.Obstacle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game
{
    using Abstract;
    using Concrete;
    public class Cell : IDraw
    {
        public int x { get; set; }
        public int y { get; set; }
        public int index { get; set; }
        public string content { get; set; }
        public IGameObject gameObject { get; set; }
        public Cell(int x, int y, int index)
        {
            this.x = x;
            this.y = y;
            this.index = index;
        }

        public void Draw()
        {
            try
            {
                //Yukarı Çizgi
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(x + i, y);
                    Console.Write("*");
                }

                ////Aşağıya çizgi
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(x, y + i);
                    Console.Write("*");
                }
                //Aşağı Çizgi
                for (int i = 0; i < 10; i++)
                {
                    Console.SetCursorPosition(x + i, Console.CursorTop);
                    Console.Write("*");
                }

                //Sağ çizgi
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition((x + 10), y + i);
                    Console.Write("*");
                }

                if (this.gameObject != null)
                {
                    Console.SetCursorPosition(x + 2, y + 2);
                    Console.Write(gameObject.Name);
                }

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}
