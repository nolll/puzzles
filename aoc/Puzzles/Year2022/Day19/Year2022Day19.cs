using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day19;

public class Year2022Day19 : AocPuzzle
{
    public override string Title => "Not Enough Minerals";

    public override PuzzleResult RunPart1()
    {
        var factory = new RobotFactory();
        var result = factory.Part1(FileInput);

        return new PuzzleResult(result, 2193);
    }

    public override PuzzleResult RunPart2()
    {
        var factory = new RobotFactory();
        var result = factory.Part2(FileInput);

        return new PuzzleResult(result, 7200);
    }
}