using Puzzles.common.Graphs;
using Puzzles.common.Puzzles;
using Puzzles.common.Strings;

namespace Puzzles.aquaq.Puzzles.Aquaq21;

public class Aquaq21 : AquaqPuzzle
{
    public override string Name => "Clean Sweep";

    protected override PuzzleResult Run()
    {
        return new PuzzleResult(Run(InputFile, 5), "e9476ebab07e71bb8b8872bca85185f5");
    }

    public static int Run(string input, int width)
    {
        var lines = StringReader.ReadLines(input);
        var rows = lines.Select(o => o.Split(' ').Select(int.Parse).ToArray()).ToList();

        var inputs = new List<Graph.Input>();

        var firstRow = rows.First();
        for (var position = 0; position <= firstRow.Length - width; position++)
        {
            const string startId = "start";
            var toId = $"0-{position}";
            var cost = firstRow.Skip(position).Take(width).Sum();
            inputs.Add(new Graph.Input(startId, toId, cost));
        }

        for (var rowIndex = 0; rowIndex < rows.Count - 1; rowIndex++)
        {
            var row = rows[rowIndex];
            for (var position = 0; position <= row.Length - width; position++)
            {
                var startId = $"{rowIndex}-{position}";
                for (var offset = -1; offset <= 1; offset++)
                {
                    if (position + offset < 0 || position + offset > row.Length - width)
                        continue;

                    var toId = $"{rowIndex + 1}-{position + offset}";
                    var cost = rows[rowIndex + 1].Skip(position + offset).Take(width).Sum();
                    inputs.Add(new Graph.Input(startId, toId, cost));
                }
            }
        }

        var lastRow = rows.Last();
        for (var position = 0; position <= lastRow.Length - width; position++)
        {
            var startId = $"{rows.Count - 1}-{position}";
            const string toId = "end";
            inputs.Add(new Graph.Input(startId, toId, 0));
        }

        inputs.Add(new Graph.Input("end", "start", 0));

        var result = Graph.GetHighestCost(inputs, "start", "end");
        return result;
    }
}