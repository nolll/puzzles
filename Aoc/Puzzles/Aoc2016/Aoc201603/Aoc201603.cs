using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201603;

[Name("Squares With Three Sides")]
public class Aoc201603 : AocPuzzle
{
    [Puzzle("186855295ba3afb3c13eac2a74cafde4")]
    public int Part1(string input) => new TriangleValidator().GetHorizontalValidCount(input);

    [Puzzle("5c4c8d0e219270ef31fae71b72afd00e")]
    public int Part2(string input) => new TriangleValidator().GetVerticalValidCount(input);
}