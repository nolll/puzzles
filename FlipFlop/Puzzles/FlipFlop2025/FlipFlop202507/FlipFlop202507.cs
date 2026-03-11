using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202507;

[Name("Hyper grids")]
public class FlipFlop202507 : FlipFlopPuzzle
{
    [Puzzle("7b616e8fb5d65258e63524b0fc6a38a8")]
    public long Part1(string input) => Solve(input, ParseDimensionsPart1);
    
    [Puzzle("acc5b7834fbceedcbea8e40329558fe9")]
    public long Part2(string input) => Solve(input, ParseDimensionsPart2);

    [Puzzle("4b85e2a44300b9cdb015d5b57f717a50")]
    public long Part3(string input) => Solve(input, ParseDimensionsPart3);

    private long Solve(string input, Func<string, int[]> parseDimensions) => 
        input.Split(LineBreaks.Single).Sum(line => CountWays(parseDimensions(line)));

    private static int[] ParseDimensionsPart1(string line) => Numbers.IntsFromString(line);
    
    private static int[] ParseDimensionsPart2(string line)
    {
        var (w, h) = Numbers.IntsFromString(line);
        return [w, h, w];
    }
    
    private static int[] ParseDimensionsPart3(string line)
    {
        var (dimensionCount, size) = Numbers.IntsFromString(line);
        return Enumerable.Range(0, dimensionCount).Select(_ => size).ToArray();
    }

    public long CountWays(params int[] dimensions)
    {
        var n = Numbers.Factorial(dimensions.Sum() - dimensions.Length);
        var d = dimensions.Aggregate(1L, (current, dimension) => current * Numbers.Factorial(dimension - 1));
        return n / d;
    }
}