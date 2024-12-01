using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201507;

[Name("Some Assembly Required")]
public class Aoc201507 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var circuit = new Circuit(input);
        var runOne = circuit.RunOne("a");
        return new PuzzleResult(runOne, "d726fcd2e75525a2fa0a5c741cc7582f");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var circuit = new Circuit(input);
        var runTwo = circuit.RunTwo("a", "b");
        return new PuzzleResult(runTwo, "135c8ac6a573e214fabaf9728fc2cddb");
    }
}