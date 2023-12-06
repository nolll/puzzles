using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201711;

public class Aoc201711 : AocPuzzle
{
    public override string Name => "Hex Ed";

    protected override PuzzleResult RunPart1()
    {
        var navigator = new HexGridNavigator(InputFile);
        return new PuzzleResult(navigator.EndDistance, "b7c04ecac2d0150916a741834019f8ec");
    }

    protected override PuzzleResult RunPart2()
    {
        var navigator = new HexGridNavigator(InputFile);
        return new PuzzleResult(navigator.MaxDistance, "f67800158ae4e032d3f2c498107dafa8");
    }
}