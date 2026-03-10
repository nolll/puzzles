using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202111;

[Name("Dumbo Octopus")]
public class Aoc202111 : AocPuzzle
{
    [Puzzle("4aec5027d57e852d3dc2c0fa275d9d7a")]
    public PuzzleResult Part1(string input)
    {
        var flasher = new OctopusFlasher(input);
        var result = flasher.Run(100);
        return new PuzzleResult(result);
    }

    [Puzzle("ffd6657cda58c97fce2c4c27d8fd43a9")]
    public PuzzleResult Part2(string input)
    {
        var flasher = new OctopusFlasher(input);
        var result = flasher.Run();
        return new PuzzleResult(result);
    }
}