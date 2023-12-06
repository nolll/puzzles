using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

public class Aoc201507 : AocPuzzle
{
    public override string Name => "Some Assembly Required";

    protected override PuzzleResult RunPart1()
    {
        var circuit = new Circuit(InputFile);
        var runOne = circuit.RunOne("a");
        return new PuzzleResult(runOne, "d726fcd2e75525a2fa0a5c741cc7582f");
    }

    protected override PuzzleResult RunPart2()
    {
        var circuit = new Circuit(InputFile);
        var runTwo = circuit.RunTwo("a", "b");
        return new PuzzleResult(runTwo, "135c8ac6a573e214fabaf9728fc2cddb");
    }
}