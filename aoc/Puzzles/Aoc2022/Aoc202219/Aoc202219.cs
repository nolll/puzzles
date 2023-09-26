using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202219;

public class Aoc202219 : AocPuzzle
{
    public override string Name => "Not Enough Minerals";

    protected override PuzzleResult RunPart1()
    {
        var factory = new RobotFactory();
        var result = factory.Part1(InputFile);

        return new PuzzleResult(result, 2193);
    }

    protected override PuzzleResult RunPart2()
    {
        var factory = new RobotFactory();
        var result = factory.Part2(InputFile);

        return new PuzzleResult(result, 7200);
    }
}