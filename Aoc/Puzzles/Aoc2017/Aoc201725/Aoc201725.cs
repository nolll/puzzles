using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201725;

[Name("The Halting Problem")]
public class Aoc201725 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var turingMachine = new TuringMachine(input);
        var checksum = turingMachine.Run();
        return new PuzzleResult(checksum, "a18cb67e5cdfb9d5e9a4afd12de0d627");
    }
}