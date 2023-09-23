using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day12;

public class Year2016Day12 : AocPuzzle
{
    public override string Name => "Leonardo's Monorail";

    protected override PuzzleResult RunPart1()
    {
        var computer = new MonorailComputer(FileInput, 0, 0);
        return new PuzzleResult(computer.ValueA, 318_003);
    }

    protected override PuzzleResult RunPart2()
    {
        var computer = new MonorailComputer(FileInput, 0, 1);
        return new PuzzleResult(computer.ValueA, 9_227_657);
    }
}