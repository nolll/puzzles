using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day07;

public class Year2015Day07 : AocPuzzle
{
    public override string Name => "Some Assembly Required";

    public override PuzzleResult RunPart1()
    {
        var circuit = new Circuit(FileInput);
        var runOne = circuit.RunOne("a");
        return new PuzzleResult(runOne, 956);
    }

    public override PuzzleResult RunPart2()
    {
        var circuit = new Circuit(FileInput);
        var runTwo = circuit.RunTwo("a", "b");
        return new PuzzleResult(runTwo, 40_149);
    }
}