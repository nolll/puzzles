using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201603;

[Name("Squares With Three Sides")]
public class Aoc201603 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var validator = new TriangleValidator();
        var horizontalValidCount = validator.GetHorizontalValidCount(input);
        return new PuzzleResult(horizontalValidCount, "186855295ba3afb3c13eac2a74cafde4");
    }

    public PuzzleResult RunPart2(string input)
    {
        var validator = new TriangleValidator();
        var verticalValidCount = validator.GetVerticalValidCount(input);
        return new PuzzleResult(verticalValidCount, "5c4c8d0e219270ef31fae71b72afd00e");
    }
}