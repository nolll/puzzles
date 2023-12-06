using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201603;

public class Aoc201603 : AocPuzzle
{
    public override string Name => "Squares With Three Sides";

    protected override PuzzleResult RunPart1()
    {
        var validator = new TriangleValidator();
        var horizontalValidCount = validator.GetHorizontalValidCount(InputFile);
        return new PuzzleResult(horizontalValidCount, "186855295ba3afb3c13eac2a74cafde4");
    }

    protected override PuzzleResult RunPart2()
    {
        var validator = new TriangleValidator();
        var verticalValidCount = validator.GetVerticalValidCount(InputFile);
        return new PuzzleResult(verticalValidCount, "5c4c8d0e219270ef31fae71b72afd00e");
    }
}