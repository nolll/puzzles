using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202125;

[Name("Sea Cucumber")]
public class Aoc202125 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var herd = new HerdOfSeaCucumbers(input);
        var result = herd.MoveUntilStop();

        return new PuzzleResult(result, "b2c5d4f507c64adf10e3434888f5c9a9");
    }

    protected override PuzzleResult RunPart2(string input) => PuzzleResult.Empty;
}