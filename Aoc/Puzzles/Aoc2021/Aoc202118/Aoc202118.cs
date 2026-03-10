using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202118;

[Name("Snailfish")]
public class Aoc202118 : AocPuzzle
{
    [Puzzle("1d3da7fb83304ae6368c25c4835fb0af")]
    public PuzzleResult Part1(string input)
    {
        var math = new SnailfishMath();
        var result = math.Sum(input);

        return new PuzzleResult(result.Magnitude);
    }

    [Puzzle("a9626bd58c604514d0e274952464ba7d")]
    public PuzzleResult Part2(string input)
    {
        var math = new SnailfishMath();
        var result = math.LargestMagnitude(input);

        return new PuzzleResult(result);
    }
}