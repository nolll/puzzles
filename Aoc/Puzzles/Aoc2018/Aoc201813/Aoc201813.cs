using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201813;

[Name("Mine Cart Madness")]
public class Aoc201813 : AocPuzzle
{
    [Puzzle("289dd4c6742ccddf660417b3b45acad3")]
    public string Part1(string input)
    {
        var detector = new CollisionDetector(input);
        detector.RunCarts();
        return detector.LocationOfFirstCollision!.Id;
    }

    [Puzzle("b4f2a42936a725f796e9f00399495d54")]
    public string Part2(string input)
    {
        var detector = new CollisionDetector(input);
        detector.RunCarts();
        return detector.LocationOfLastCart!.Id;
    }
}