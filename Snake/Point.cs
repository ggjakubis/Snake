using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Point
    {
        public int RearX { get; private set; }
        public int RearY { get; private set; }

        public Point(int x, int y)
        {
            RearX = x;
            RearY = y;
        }
      
    }
    
}
