using Rabbit_Game.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game.Concrete
{
    using Abstract;
    public class Rabbit : IGameObject
    {
        public string Name { get; set; }
        public Row Row { get; set; }
        public Cell Cell { get; set; }
        public Rabbit(Row Row, Cell Cell)
        {
            this.Name = "Tavşan";
            this.Row = Row;
            this.Cell = Cell;
        }

        public void Step(string step)
        {
            switch (step.ToLower())
            {
                case "n":
                    {
                        Next();
                        break;
                    }
                case "p":
                    {
                        Back();
                        break;
                    }
                case "r":
                    {
                        Right();
                        break;
                    }
                case "l":
                    {
                        Left();
                        break;
                    }
                case "j":
                    {
                        Jump();
                        break;
                    }
                case "i":
                    {
                        Droop();
                        break;
                    }
            }
        }

        private void Next()
        {
            var myRow = this.Row.Board.Rows.FirstOrDefault(t0 => t0.RowNumber == this.Row.RowNumber + 1);
            Run(myRow, this.Cell.index, Movement.Next);
        }

        private void Back()
        {
            var myRow = this.Row.Board.Rows.FirstOrDefault(t0 => t0.RowNumber == this.Row.RowNumber - 1);
            Run(myRow, this.Cell.index, Movement.Back);
        }
        private void Right()
        {
            var myRow = this.Row.Board.Rows.FirstOrDefault(t0 => t0.RowNumber == this.Row.RowNumber);
            Run(myRow, this.Cell.index + 1, Movement.Right);
        }

        private void Left()
        {
            var myRow = this.Row.Board.Rows.FirstOrDefault(t0 => t0.RowNumber == this.Row.RowNumber);
            Run(myRow, this.Cell.index - 1, Movement.Left);
        }

        private void Jump()
        {
            var myRow = this.Row.Board.Rows.FirstOrDefault(t0 => t0.RowNumber == this.Row.RowNumber);
            Run(myRow, this.Cell.index, Movement.Jump);
        }

        private void Droop()
        {
            var myRow = this.Row.Board.Rows.FirstOrDefault(t0 => t0.RowNumber == this.Row.RowNumber);
            Run(myRow, this.Cell.index, Movement.Droop);
        }


        private void Run(Row Row, int index, Movement movement)
        {
            if (Row != null)
            {
                var myNextCell = Row.Cells.FirstOrDefault(t0 => t0.index == index);
                if (myNextCell != null)
                {
                    if (myNextCell.gameObject != null)
                    {
                        GameObjectControl(myNextCell.gameObject, movement);
                    }
                    this.Cell.gameObject = null;
                    myNextCell.gameObject = this;
                    this.Row = Row;
                    this.Cell = myNextCell;
                }
            }
        }

        private void GameObjectControl(IGameObject gameObject, Movement movement)
        {
            if (gameObject is IObstacle)
            {
                if (gameObject is IDead)
                {
                    Console.Clear();
                    Console.WriteLine("Tavşan öldü");
                    this.Row.Board.IsFinish = true;
                }
                else if (gameObject is IBarrier)
                {
                    if (!(movement == Movement.Jump || movement == Movement.Droop))
                    {
                        Console.Clear();
                        Console.WriteLine("Tavşan engele takıldı");
                        this.Row.Board.IsFinish = true;
                    }
                }
            }
            else if (gameObject is RabbitHome)
            {
                Console.Clear();
                Console.WriteLine("Tavşan evine kavuştu");
                this.Row.Board.IsFinish = true;
            }
        }
    }

    public enum Movement
    {
        Next,
        Back,
        Left,
        Right,
        Jump,
        Droop
    }
}
