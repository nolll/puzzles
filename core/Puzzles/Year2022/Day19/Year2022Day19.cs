using Core.Platform;

namespace Core.Puzzles.Year2022.Day19;

public class Year2022Day19 : Puzzle
{
    public override string Title => "Not Enough Minerals";

    public override PuzzleResult RunPart1()
    {
        var factory = new RobotFactory();
        var result = factory.Part1(FileInput);

        return new PuzzleResult(result);
    }

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }
}