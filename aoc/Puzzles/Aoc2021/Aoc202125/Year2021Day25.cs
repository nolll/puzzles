using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202125;

public class Year2021Day25 : AocPuzzle
{
    public override string Name => "Sea Cucumber";

    protected override PuzzleResult RunPart1()
    {
        var herd = new HerdOfSeaCucumbers(InputFile);
        var result = herd.MoveUntilStop();

        return new PuzzleResult(result, 518);
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}