using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202225;

[Name("Full of Hot Air")]
public class Aoc202225(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = Part1(input);

        return new PuzzleResult(result, "793d1443281edc7d7e628e25d8aa07a4");
    }

    public string Part1(string input)
    {
        var lines = StringReader.ReadLines(input);
        var sum = lines.Select(SnafuConverter.ToNumber).Sum();
        return SnafuConverter.ToSnafu(sum);
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}