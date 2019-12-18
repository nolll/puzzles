using System;

namespace Core.Tools
{
    public class MatrixDirection : IEquatable<MatrixDirection>
    {
        public string Name { get; }
        public int X { get; }
        public int Y { get; }

        private MatrixDirection(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }
        
        public static readonly MatrixDirection Up = new MatrixDirection("up", 0, -1);
        public static readonly MatrixDirection Right = new MatrixDirection("right", 1, 0);
        public static readonly MatrixDirection Down = new MatrixDirection("down", 0, 1);
        public static readonly MatrixDirection Left = new MatrixDirection("left", -1, 0);

        public bool Equals(MatrixDirection other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((MatrixDirection) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}