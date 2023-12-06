using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201725;

public class Aoc201725 : AocPuzzle
{
    public override string Name => "The Halting Problem";

    protected override PuzzleResult RunPart1()
    {
        var turingMachine = new TuringMachine(InputFile);
        var checksum = turingMachine.Run();
        return new PuzzleResult(checksum, "a18cb67e5cdfb9d5e9a4afd12de0d627");
    }

    protected override PuzzleResult RunPart2() => PuzzleResult.Empty;
}