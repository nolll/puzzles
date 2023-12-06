using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201612;

public class Aoc201612 : AocPuzzle
{
    public override string Name => "Leonardo's Monorail";

    protected override PuzzleResult RunPart1()
    {
        var computer = new MonorailComputer(InputFile, 0, 0);
        return new PuzzleResult(computer.ValueA, "4ba2fa440d50bec300e43771065afd61");
    }

    protected override PuzzleResult RunPart2()
    {
        var computer = new MonorailComputer(InputFile, 0, 1);
        return new PuzzleResult(computer.ValueA, "5c02e7d4176ed51a799484797ba99661");
    }
}