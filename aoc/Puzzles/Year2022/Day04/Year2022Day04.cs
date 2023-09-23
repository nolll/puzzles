using Common.Puzzles;

namespace Aoc.Puzzles.Year2022.Day04;

public class Year2022Day04 : AocPuzzle
{
    public override string Name => "Camp Cleanup";

    protected override PuzzleResult RunPart1()
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part1(FileInput);

        return new PuzzleResult(result, 571);
    }

    protected override PuzzleResult RunPart2()
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part2(FileInput);

        return new PuzzleResult(result, 917);
    }
}