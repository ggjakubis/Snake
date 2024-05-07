using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Snake.Program;

namespace Snake
{
    public class Playground
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public List<Point> Borders { get; private set; }

        public Playground(int x, int y)
        {
            X = x;
            Y = y;
            Borders = new List<Point>();
        }

        private void Rears()
        {
            // Horní + dolní 
            for (int i = 0; i <= X; i++)
            {
                Borders.Add(new Point(i, 0));
                Borders.Add(new Point(i, Y));
            }
            //Pravý + Levý 
            for (int i = 1; i <= Y; i++)
            {
                Borders.Add(new Point(0, i));
                Borders.Add(new Point(X, i));
            }
        }
        

        public void SetPlayground(ConsoleColor Barva)
        {
            Rears();
            Console.ForegroundColor = Barva;

            foreach (Point i in Borders)
            {
                Console.CursorLeft = i.RearX * 2;
                Console.CursorTop = i.RearY;
                Console.Write("██");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        
    }
}
