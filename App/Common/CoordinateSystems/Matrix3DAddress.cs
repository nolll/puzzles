using System;

namespace App.Common.CoordinateSystems
{
    public class Matrix3DAddress : IEquatable<Matrix3DAddress>
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public string Id { get; }

        public Matrix3DAddress(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            Id = $"{x},{y},{z}";
        }

        public int ManhattanDistanceTo(Matrix3DAddress other)
        {
            var xMax = Math.Max(X, other.X);
            var xMin = Math.Min(X, other.X);
            var xDiff = xMax - xMin;

            var yMax = Math.Max(Y, other.Y);
            var yMin = Math.Min(Y, other.Y);
            var yDiff = yMax - yMin;

            var zMax = Math.Max(Z, other.Z);
            var zMin = Math.Min(Z, other.Z);
            var zDiff = zMax - zMin;

            return xDiff + yDiff + zDiff;
        }

        public bool Equals(Matrix3DAddress other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MatrixAddress)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}