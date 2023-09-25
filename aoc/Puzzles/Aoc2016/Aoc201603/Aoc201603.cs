using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201603;

public class Aoc201603 : AocPuzzle
{
    public override string Name => "Squares With Three Sides";

    protected override PuzzleResult RunPart1()
    {
        var validator = new TriangleValidator();
        var horizontalValidCount = validator.GetHorizontalValidCount(InputFile);
        return new PuzzleResult(horizontalValidCount, 982);
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new TriangleValidator();
        var verticalValidCount = validator.GetVerticalValidCount(InputFile);
        return new PuzzleResult(verticalValidCount, 1826);
    }
}