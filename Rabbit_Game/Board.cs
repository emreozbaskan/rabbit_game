using Rabbit_Game.Obstacle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game
{
    using Abstract;
    using Rabbit_Game.Concrete;
    using System.Threading;

    public class Board
    {
        public bool IsFinish { get; set; }
        public Rabbit Rabbit { get; set; }
        public List<Row> Rows { get; set; }
        public Queue<IObstacle> Obstacles { get; set; }

        //private int _Dimencion = 4;
        public int _Dimencion { get; set; } = 4;

        public Board(int Dimencion)
        {
            if (!(Dimencion == 4 || Dimencion == 8 || Dimencion == 16))
                throw new Exception("istenilen ölçüde gelmedi");
            _Dimencion = Dimencion;
            this.Rows = new List<Row>();
            CreateObstacle();
            CreateBoard();
        }

        private void CreateObstacle()
        {
            this.Obstacles = new ObstacleManager(this._Dimencion).GenerateObtacle();
        }

        public void CreateBoard()
        {
            for (int i = 0; i < _Dimencion; i++)
            {
                this.Rows.Add(new Row(i, this));
            }
        }

        public void DisplayRender()
        {
            Console.Clear();
            for (int i = 0; i < this.Rows.Count; i++)
            {
                var myRow = this.Rows[i];
                for (int s = 0; s < myRow.Cells.Count; s++)
                {
                    var myCell = myRow.Cells[s];
                    myCell.Draw();
                }
            }
        }

        //protected static int origTop;
        //protected static int origLeft;
        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public void Run(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Error");
                Console.WriteLine("Girilen adımlar anlaşılamadı. Lütfen tekrar deneyiniz.");
            }

            string[] paths = path.Split(',');
            for (int i = 0; i < paths.Length; i++)
            {
                if (!this.IsFinish)
                {
                    Rabbit.Step(paths[i]);
                    Thread.Sleep(1000);
                    Console.Clear();
                    this.DisplayRender();
                }
            }
        }



    }

}
