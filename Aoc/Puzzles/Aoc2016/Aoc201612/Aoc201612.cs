using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201612;

[Name("Leonardo's Monorail")]
public class Aoc201612(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var computer = new MonorailComputer(input, 0, 0);
        return new PuzzleResult(computer.ValueA, "4ba2fa440d50bec300e43771065afd61");
    }

    protected override PuzzleResult RunPart2()
    {
        var computer = new MonorailComputer(input, 0, 1);
        return new PuzzleResult(computer.ValueA, "5c02e7d4176ed51a799484797ba99661");
    }
}