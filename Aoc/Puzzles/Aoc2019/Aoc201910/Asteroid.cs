namespace Puzzles.Aoc.Puzzles.Aoc2019.Aoc201910;

public class Asteroid : IEquatable<Asteroid>
{
    public char Name { get; }
    public int X { get; }
    public int Y { get; }

    public Asteroid(char name, int x, int y)
    {
        Name = name;
        X = x;
        Y = y;
    }

    public bool Equals(Asteroid? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Asteroid) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (X * 397) ^ Y;
        }
    }
}