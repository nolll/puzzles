using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202209;

[Name("Rope Bridge")]
public class Aoc202209 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part1(input);

        return new PuzzleResult(result, "5b3410f2b268346d61d197ac2087314e");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var ropeBridge = new RopeBridge();
        var result = ropeBridge.Part2(input);

        return new PuzzleResult(result, "05bd61537764e7f00abe6ea63344d6ba");
    }
}