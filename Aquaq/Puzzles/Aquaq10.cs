using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("Troll Toll")]
public class Aquaq10 : AquaqPuzzle
{
    [Puzzle("970a7dc35bbbeae207c821cbc8bbb930")]
    public int Solve(string input) => Solve(input, "TUPAC", "DIDDY");

    public int Solve(string input, string source, string target)
    {
        var graphInput = input.Split(LineBreaks.Single).Skip(1).Select(ParseGraphInput).ToList();
        return Dijkstra.BestCost(graphInput, source, target);
    }

    private static GraphEdge ParseGraphInput(string s)
    {
        var (from, to, costString) = s.Split(',');
        return new GraphEdge(from, to, int.Parse(costString));
    }
}