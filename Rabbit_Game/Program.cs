using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Orman Boyutlarında 4-8-16 değerleri kabul edilecektir.");
                Console.Write("Lütfen orman boyutunu giriniz...:");
                int dimencion = Convert.ToInt32(Console.ReadLine());

                Board board = new Board(dimencion);
                board.DisplayRender();

                Console.SetCursorPosition(0, (dimencion * 4) + 1);

                Console.WriteLine("İleri (n) Geri (p) Sağ (r) Sol (l) Zipla (j) Eğil (i)");
                Console.Write("Lütfen adımları aralarda virgül olacak şekilde giriniz..:");
                string path = Console.ReadLine();
                board.Run(path);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
