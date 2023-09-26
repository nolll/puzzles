using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Aoc201725;

public class Aoc201725 : AocPuzzle
{
    public override string Name => "The Halting Problem";

    protected override PuzzleResult RunPart1()
    {
        var turingMachine = new TuringMachine(InputFile);
        var checksum = turingMachine.Run();
        return new PuzzleResult(checksum, 4387);
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}