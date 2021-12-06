using System;

namespace Core.Puzzles.Year2019.Day10
{
    public class Ray : IEquatable<Ray>
    {
        public double Angle { get; }
        public double Distance { get; }
        public Asteroid Target { get; }

        public Ray(Asteroid here, Asteroid there)
        {
            Target = there;
            double xDiff = there.X - here.X;
            double yDiff = there.Y - here.Y;
            var angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI + 90;
            Angle = angle < 0 ? angle + 360 : angle;
            Distance = Math.Sqrt(yDiff * yDiff + xDiff * xDiff);
        }

        public bool Equals(Ray other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Angle.Equals(other.Angle);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Ray)obj);
        }

        public override int GetHashCode()
        {
            return Angle.GetHashCode();
        }
    }
}