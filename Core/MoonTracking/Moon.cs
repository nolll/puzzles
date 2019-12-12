namespace Core.MoonTracking
{
    public class Moon
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public Velocity Velocity { get; set; }

        public Moon(int x, int y, int z, Velocity velocity = null)
        {
            X = x;
            Y = y;
            Z = z;
            Velocity = velocity ?? new Velocity(0, 0, 0);
        }
    }
}