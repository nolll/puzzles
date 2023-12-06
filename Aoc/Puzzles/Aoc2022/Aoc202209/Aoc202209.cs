using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202209;

public class Aoc202209 : AocPuzzle
{
    public override string Name => "Rope Bridge";

    protected override PuzzleResult RunPart1()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part1(InputFile);

        return new PuzzleResult(result, "5b3410f2b268346d61d197ac2087314e");
    }

    protected override PuzzleResult RunPart2()
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part2(InputFile);

        return new PuzzleResult(result, "05bd61537764e7f00abe6ea63344d6ba");
    }
}