using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day18;

public class Year2016Day18 : AocPuzzle
{
    public override string Title => "Like a Rogue";

    public override PuzzleResult RunPart1()
    {
        var detector = new FloorTrapDetector(FileInput);
        var safeCount = detector.CountSafeTiles(40);
        return new PuzzleResult(safeCount, 1989);
    }

    public override PuzzleResult RunPart2()
    {
        var detector = new FloorTrapDetector(FileInput);
        var safeCount = detector.CountSafeTiles(400_000);
        return new PuzzleResult(safeCount, 19_999_894);
    }
}