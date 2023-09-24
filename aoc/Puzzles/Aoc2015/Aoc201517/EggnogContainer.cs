using System;

namespace Aoc.Puzzles.Aoc2015.Day17;

public class EggnogContainer : IEquatable<EggnogContainer>
{
    public int Id { get; }
    public int Volume { get; }

    public EggnogContainer(int id, int volume)
    {
        Id = id;
        Volume = volume;
    }

    public bool Equals(EggnogContainer? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((EggnogContainer) obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}