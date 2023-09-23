using System.Linq;
using Common.Puzzles;
using Common.Strings;

namespace Aoc.Puzzles.Year2022.Day25;

public class Year2022Day25 : AocPuzzle
{
    public override string Name => "Full of Hot Air";

    protected override PuzzleResult RunPart1()
    {
        var result = Part1(FileInput);

        return new PuzzleResult(result, "2-=0-=-2=111=220=100");
    }

    public string Part1(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input);
        var sum = lines.Select(SnafuConverter.ToNumber).Sum();
        return SnafuConverter.ToSnafu(sum);
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}