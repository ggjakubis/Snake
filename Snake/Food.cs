using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Snake.Program;

namespace Snake
{

    class Food
    {
        public Point potrava;
        Random rand;
        private ConsoleColor barvaJidla;

        public Food(ConsoleColor barvicka)
        {
            barvaJidla = barvicka;
        }

        private int SetXYFood()
        {
            rand = new Random();
            return rand.Next(1, 19);
        }

        public void ThrowFood()
        {
            Console.ForegroundColor = barvaJidla;
            potrava = new Point(SetXYFood(), SetXYFood());
            Console.CursorLeft = potrava.RearX * 2;
            Console.CursorTop = potrava.RearY;
            Console.Write("██");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
