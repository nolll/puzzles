namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202020;

public abstract class EdgeMatcher : TileMatcher
{
    private readonly string _edgeToMatch;
    protected abstract string Edge { get; }

    protected EdgeMatcher(string edgeToMatch)
    {
        _edgeToMatch = edgeToMatch;
    }

    protected override bool IsMatch(JigsawTile tile)
    {
        return tile.Edges[Edge] == _edgeToMatch;
    }
}