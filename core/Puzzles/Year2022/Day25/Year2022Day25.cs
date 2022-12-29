using System.Linq;
using Core.Common.Strings;
using Core.Platform;

namespace Core.Puzzles.Year2022.Day25;

public class Year2022Day25 : Puzzle
{
    public override PuzzleResult RunPart1()
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

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }
}