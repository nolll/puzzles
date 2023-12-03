using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202125;

public class Aoc202125 : AocPuzzle
{
    public override string Name => "Sea Cucumber";

    protected override PuzzleResult RunPart1()
    {
        var herd = new HerdOfSeaCucumbers(InputFile);
        var result = herd.MoveUntilStop();

        return new PuzzleResult(result, "b2c5d4f507c64adf10e3434888f5c9a9");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}