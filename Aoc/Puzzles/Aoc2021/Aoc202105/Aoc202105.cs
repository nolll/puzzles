using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202105;

[Name("Hydrothermal Venture")]
public class Aoc202105 : AocPuzzle
{
    [Puzzle("72e2846f2036e57e75a10d9d0b5a99ad")]
    public PuzzleResult Part1(string input)
    {
        var ventsMap = new VentsMap();
        var result = ventsMap.Run(input, true);

        return new PuzzleResult(result);
    }

    [Puzzle("e07b568228a7ed5a9bc9276d343e6973")]
    public PuzzleResult Part2(string input)
    {
        var ventsMap = new VentsMap();
        var result = ventsMap.Run(input, false);

        return new PuzzleResult(result);
    }
}