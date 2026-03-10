using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202106;

[Name("Lanternfish")]
public class Aoc202106 : AocPuzzle
{
    [Puzzle("f41058112a3490c1842a14e75ebfef8c")]
    public PuzzleResult Part1(string input)
    {
        var fishCounter = new FishCounter(input);
        var result = fishCounter.FishCountAfter(80);
        return new PuzzleResult(result);
    }

    [Puzzle("d49cf732d5285745340ba70c6a3ddc15")]
    public PuzzleResult Part2(string input)
    {
        var fishCounter = new FishCounter(input);
        var result = fishCounter.FishCountAfter(256);
        return new PuzzleResult(result);
    }
}