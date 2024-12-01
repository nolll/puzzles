using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201618;

[Name("Like a Rogue")]
public class Aoc201618 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var detector = new FloorTrapDetector(input);
        var safeCount = detector.CountSafeTiles(40);
        return new PuzzleResult(safeCount, "e5a7af4db610ffe95694d0dd5d7b43c6");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var detector = new FloorTrapDetector(input);
        var safeCount = detector.CountSafeTiles(400_000);
        return new PuzzleResult(safeCount, "bd1b0d5a17ef0a0b7c880a805ea95cc4");
    }
}