using System.Collections.Generic;

namespace Aoc.Puzzles.Aoc2020.Aoc202020;

public class TopLeftCornerMatcher : TileMatcher
{
    private readonly Dictionary<string, List<JigsawTile>> _matchesByEdge;

    public TopLeftCornerMatcher(Dictionary<string, List<JigsawTile>> matchesByEdge)
    {
        _matchesByEdge = matchesByEdge;
    }

    protected override bool IsMatch(JigsawTile tile) =>
        _matchesByEdge[tile.Edges["left"]].Count == 0 &&
        _matchesByEdge[tile.Edges["top"]].Count == 0;
}