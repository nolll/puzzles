using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2017.Day25;

public class Year2017Day25 : AocPuzzle
{
    public override string Title => "The Halting Problem";

    public override PuzzleResult RunPart1()
    {
        var turingMachine = new TuringMachine(FileInput);
        var checksum = turingMachine.Run();
        return new PuzzleResult(checksum, 4387);
    }

    public override PuzzleResult RunPart2() => PuzzleResult.Empty;
}