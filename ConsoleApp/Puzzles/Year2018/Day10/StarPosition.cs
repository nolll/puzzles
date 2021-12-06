namespace ConsoleApp.Puzzles.Year2018.Day10
{
    public class StarPosition
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Vx { get; }
        public int Vy { get; }

        public StarPosition(int x, int y, int vx, int vy)
        {
            X = x;
            Y = y;
            Vx = vx;
            Vy = vy;
        }

        public void Move()
        {
            X += Vx;
            Y += Vy;
        }
    }
}