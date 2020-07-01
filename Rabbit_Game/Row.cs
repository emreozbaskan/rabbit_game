using Rabbit_Game.Concrete;
using Rabbit_Game.Obstacle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game
{
    using Abstract;
    using System.Threading;

    public class Row
    {
        public Board Board { get; set; }
        public List<Cell> Cells { get; set; }
        public int RowNumber { get; set; }
        public Row(int Rownumber, Board board)
        {
            this.RowNumber = Rownumber;
            this.Board = board;
            this.Cells = new List<Cell>();
            CreateCell();
            SetObstacles();
        }

        private void CreateCell()
        {
            for (int i = 0; i < this.Board._Dimencion; i++)
            {
                var myCell = new Cell((i * 10), (RowNumber * 4), i);
                if (this.RowNumber == 0 && i == 0)
                {
                    this.Board.Rabbit = new Rabbit(this, myCell);
                    myCell.gameObject = this.Board.Rabbit;
                }

                if ((this.Board._Dimencion == RowNumber + 1) && (i == this.Board._Dimencion - 1))
                {
                    myCell.gameObject = new RabbitHome();
                }

                this.Cells.Add(myCell);
            }
        }
        private void SetObstacles()
        {
            int count = Convert.ToInt32(this.Board.Obstacles.Count / this.Board._Dimencion);//  this.RowNumber % 2 == 0 ? 2 : 1;
            if (count == 0) count = 1;
            var rnd = new Random();
            var parentRow = this.Board.Rows.FirstOrDefault(t0 => t0.RowNumber == (this.RowNumber - 1));
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(100);
                int index = rnd.Next(0, this.Board._Dimencion);
                var myCell = this.Cells[index];
                if (myCell.gameObject != null)
                {
                    i--;
                    continue;
                }

                if (parentRow != null)
                {
                    //Engel koyulabilir mi ona bakılıyor.
                    if (parentRow.IsControlObstable(index))
                    {
                        myCell.gameObject = (IGameObject)this.Board.Obstacles.Dequeue();
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    myCell.gameObject = (IGameObject)this.Board.Obstacles.Dequeue();
                }
            }
        }

        private bool IsControlObstable(int index)
        {
            bool leftCellObstacle = false;
            bool rightCellObstacle = false;
            //ilk satır veya son satır ise 
            if (this.RowNumber == 0 || (this.RowNumber == this.Board._Dimencion - 1))
                return true;

            var myTopCell = this.Cells.FirstOrDefault(t0 => t0.index == index);
            var myLeftCell = this.Cells.FirstOrDefault(t0 => t0.index == index - 1);
            var myRightCell = this.Cells.FirstOrDefault(t0 => t0.index == index + 1);

            //Üst Nesne engel olmaması gerekiyor
            if (myTopCell.gameObject is IObstacle)
            {
                return false;
            }


            //sol veya sağ taraf ikiside dolu ise
            if (myLeftCell != null)
                if (myLeftCell.gameObject is IObstacle)
                    leftCellObstacle = true;

            if (myRightCell != null)
                if (myRightCell.gameObject is IObstacle)
                    rightCellObstacle = true;

            if (leftCellObstacle || rightCellObstacle)
                return false;


            return true;
        }

    }
}
