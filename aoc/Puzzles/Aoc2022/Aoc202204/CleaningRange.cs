namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202204;

public class CleaningRange
{
    private readonly int _from;
    private readonly int _to;

    public CleaningRange(int from, int to)
    {
        _from = from;
        _to = to;
    }

    public bool Contains(CleaningRange other)
    {
        return other._from >= _from && other._to <= _to;
    }

    public bool Overlaps(CleaningRange other)
    {
        return other._to >= _from && other._to <= _to || 
               other._from <= _to && other._from >= _from;
    }
}