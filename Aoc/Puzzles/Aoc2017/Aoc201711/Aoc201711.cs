using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201711;

[Name("Hex Ed")]
public class Aoc201711 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var navigator = new HexGridNavigator(input);
        return new PuzzleResult(navigator.EndDistance, "b7c04ecac2d0150916a741834019f8ec");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var navigator = new HexGridNavigator(input);
        return new PuzzleResult(navigator.MaxDistance, "f67800158ae4e032d3f2c498107dafa8");
    }
}