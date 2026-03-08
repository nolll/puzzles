namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202204;

public class CleaningRange(int from, int to)
{
    private readonly int _from = from;
    private readonly int _to = to;

    public bool Contains(CleaningRange other) => other._from >= _from && other._to <= _to;

    public bool Overlaps(CleaningRange other) =>
        other._to >= _from && other._to <= _to || 
        other._from <= _to && other._from >= _from;
}