namespace Core.MoonTracking
{
    public class Moon
    {
        public int Id { get; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }
        public Velocity Velocity { get; private set; }

        public Moon(int id, int x, int y, int z, Velocity velocity = null)
        {
            Id = id;
            X = x;
            Y = y;
            Z = z;
            Velocity = velocity ?? new Velocity(0, 0, 0);
        }

        public void ChangeVelocity(Velocity velocity)
        {
            Velocity = velocity;
        }

        public void Move()
        {
            X += Velocity.X;
            Y += Velocity.Y;
            Z += Velocity.Z;
        }
    }
}