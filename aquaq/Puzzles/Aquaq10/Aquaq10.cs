using Puzzles.common.Graphs;
using Puzzles.common.Puzzles;

namespace Puzzles.aquaq.Puzzles.Aquaq10;

public class Aquaq10 : AquaqPuzzle
{
    public override string Name => "Troll Toll";

    protected override PuzzleResult Run()
    {
        var result = Run(InputFile, "TUPAC", "DIDDY");

        return new PuzzleResult(result, "970a7dc35bbbeae207c821cbc8bbb930");
    }

    public static int Run(string input, string source, string target)
    {
        var graphInput = input.Split(Environment.NewLine)
            .Skip(1)
            .Select(ParseGraphInput).ToList();

        return Graph.GetLowestCost(graphInput, source, target);
    }

    private static Graph.Input ParseGraphInput(string s)
    {
        var parts = s.Split(',');
        var from = parts[0];
        var to = parts[1];
        var cost = int.Parse(parts[2]);

        return new Graph.Input(from, to, cost);
    }
}