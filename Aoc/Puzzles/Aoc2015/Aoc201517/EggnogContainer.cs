namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201517;

public class EggnogContainer(int id, int volume) : IEquatable<EggnogContainer>
{
    private readonly int _id = id;
    public int Volume { get; } = volume;

    public bool Equals(EggnogContainer? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _id == other._id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((EggnogContainer) obj);
    }

    public override int GetHashCode() => _id;
}