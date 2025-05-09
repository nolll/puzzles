using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201811;

[Name("Chronal Charge")]
public class Aoc201811 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var grid = new PowerGrid(300, int.Parse(input));
        var maxCoords = grid.GetMaxCoords();
        var strCoords = $"{maxCoords.X},{maxCoords.Y}";
        return new PuzzleResult(strCoords, "f3fc6e4f392f91227d656e153bc6797b");
    }

    public PuzzleResult RunPart2(string input)
    {
        var grid = new PowerGrid(300, int.Parse(input));
        var (coords, size) = grid.GetMaxCoordsAnySize();
        var strCoordsAndSize2 = $"{coords.X},{coords.Y},{size}";
        return new PuzzleResult(strCoordsAndSize2, "3519b00562141f570c15da87657755e1");
    }
}