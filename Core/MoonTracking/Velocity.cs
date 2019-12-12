namespace Core.MoonTracking
{
    public class Velocity
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Velocity(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}