using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201507;

public class Year2015Day07 : AocPuzzle
{
    public override string Name => "Some Assembly Required";

    protected override PuzzleResult RunPart1()
    {
        var circuit = new Circuit(InputFile);
        var runOne = circuit.RunOne("a");
        return new PuzzleResult(runOne, 956);
    }

    protected override PuzzleResult RunPart2()
    {
        var circuit = new Circuit(InputFile);
        var runTwo = circuit.RunTwo("a", "b");
        return new PuzzleResult(runTwo, 40_149);
    }
}