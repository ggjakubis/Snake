using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        public void LetsPlay()
        {
            Console.CursorVisible = false;
            Playground deska = new Playground(20, 20);
            Snake had = new Snake(6, ConsoleColor.Green);
            Food jidlo = new Food(ConsoleColor.Red);
            deska.SetPlayground(ConsoleColor.Cyan);
            jidlo.ThrowFood();
            while (had.IsLive)
            {
                //test na smrt hada (zeď)
                foreach (Point i in deska.Borders)
                {
                    if ((i.RearX == had.Body[0].RearX) && (i.RearY == had.Body[0].RearY))
                    {
                        had.Death("Had narazil do zdi");
                    }
                }

                //test na smrt hada (tělo)
                for (int i = 1; i < had.Body.Count - 1; i++)
                {
                    if (had.Body[i].RearX == had.Body[0].RearX && had.Body[i].RearY == had.Body[0].RearY)
                    {
                        had.Death("Had se zakousl");
                    }
                }

                //test na ulovení potravy
                if (had.Body[0].RearX == jidlo.potrava.RearX && had.Body[0].RearY == jidlo.potrava.RearY)
                {
                    had.Eat(jidlo.potrava);
                    jidlo.ThrowFood();
                }

                had.DrawIt(); // Vykreslení hada
                had.Run(); // Posun hada  
                Thread.Sleep(150); // Čekáme n milisekund

                // Pokud je stisknuta nějaká klávesa
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo klavesa = Console.ReadKey(); // Načtení klávesy
                                                                // Reakce na jednotlivé klávesy
                    if (klavesa.Key == ConsoleKey.RightArrow)
                        had.Direction = 90;
                    if (klavesa.Key == ConsoleKey.LeftArrow)
                        had.Direction = 180;
                    if (klavesa.Key == ConsoleKey.DownArrow)
                        had.Direction = 270;
                    if (klavesa.Key == ConsoleKey.UpArrow)
                        had.Direction = 360;
                }
            }
        }
    }
}
