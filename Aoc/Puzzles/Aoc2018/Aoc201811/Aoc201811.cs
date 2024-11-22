using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201811;

[Name("Chronal Charge")]
public class Aoc201811(string input) : AocPuzzle
{
    private int IntInput => int.Parse(input);

    protected override PuzzleResult RunPart1()
    {
        var grid = new PowerGrid(300, IntInput);
        var maxCoords = grid.GetMaxCoords();
        var strCoords = $"{maxCoords.X},{maxCoords.Y}";
        return new PuzzleResult(strCoords, "f3fc6e4f392f91227d656e153bc6797b");
    }

    protected override PuzzleResult RunPart2()
    {
        var grid = new PowerGrid(300, IntInput);
        var (coords, size) = grid.GetMaxCoordsAnySize();
        var strCoordsAndSize2 = $"{coords.X},{coords.Y},{size}";
        return new PuzzleResult(strCoordsAndSize2, "3519b00562141f570c15da87657755e1");
    }
}