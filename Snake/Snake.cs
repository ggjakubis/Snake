namespace Snake
{
    public class Snake
    {
        public int SnakeLength { get; private set; }

        public ConsoleColor Color { get; private set; }
        public int Direction { get; set; }// 90 180 270 360
        public bool IsLive { get; private set; }
        public List<Point> Body { get; private set; }
        public Point Head { get; private set; }
        public Point Tail { get; private set; }
        public Snake(int length, ConsoleColor color)
        {
            Body = new List<Point>();
            Color = color;
            SnakeLength = length;
            Direction = 180;
            IsLive = true;
            for (int i = 0; i < length; i++)
            {
                Body.Add(new Point(i + 10, 10));
            }
        }

        public void Death(string epitaf)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(epitaf);
            Console.ForegroundColor = ConsoleColor.White;
            IsLive = false;
        }
        public void DrawIt()
        {
            Head = Body[0];
            Tail = Body[Body.Count - 1];
            Console.ForegroundColor = this.Color;
            foreach (Point B in Body)
            {
                Console.CursorLeft = B.RearX * 2;
                Console.CursorTop = B.RearY;
                Console.Write("██");// Alt+219 ██
            }

            
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Run()
        {
            switch (Direction)
            {
                case 90 : Body.Insert(0, new Point(Head.RearX + 1, Head.RearY)); break;//vpravo
                case 180: Body.Insert(0, new Point(Head.RearX - 1, Head.RearY)); break;//dolu
                case 270: Body.Insert(0, new Point(Head.RearX, Head.RearY + 1)); break;//vlevo
                case 360: Body.Insert(0, new Point(Head.RearX, Head.RearY - 1)); break;//nahoru
            }
            Body.RemoveAt(Body.Count - 1);
            Clear();
            
        }

        private void Clear()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorLeft = Tail.RearX * 2;
            Console.CursorTop = Tail.RearY;
            Console.Write("██");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Eat(Point B)
        {
            Body.Insert(0, B);

        }
                 

    }
}
