using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201618;

public class Year2016Day18 : AocPuzzle
{
    public override string Name => "Like a Rogue";

    protected override PuzzleResult RunPart1()
    {
        var detector = new FloorTrapDetector(InputFile);
        var safeCount = detector.CountSafeTiles(40);
        return new PuzzleResult(safeCount, 1989);
    }

    protected override PuzzleResult RunPart2()
    {
        var detector = new FloorTrapDetector(InputFile);
        var safeCount = detector.CountSafeTiles(400_000);
        return new PuzzleResult(safeCount, 19_999_894);
    }
}