using App.Platform;

namespace App.Puzzles.Year2018.Day25;

public class Year2018Day25 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var finder = new ConstellationFinder(FileInput);
        var constellationCount = finder.Find();
        return new PuzzleResult(constellationCount, 375);
    }

    public override PuzzleResult RunPart2()
    {
        return new EmptyPuzzleResult();
    }
}