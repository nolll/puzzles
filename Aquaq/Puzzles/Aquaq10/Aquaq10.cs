using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq10;

[Name("Troll Toll")]
public class Aquaq10 : AquaqPuzzle
{
    [Puzzle("970a7dc35bbbeae207c821cbc8bbb930")]
    public PuzzleResult Solve(string input) => new(Solve(input, "TUPAC", "DIDDY"));

    public static int Solve(string input, string source, string target)
    {
        var graphInput = input.Split(LineBreaks.Single)
            .Skip(1)
            .Select(ParseGraphInput)
            .ToList();

        return Dijkstra.BestCost(graphInput, source, target);
    }

    private static GraphEdge ParseGraphInput(string s)
    {
        var parts = s.Split(',');
        var from = parts[0];
        var to = parts[1];
        var cost = int.Parse(parts[2]);

        return new GraphEdge(from, to, cost);
    }
}