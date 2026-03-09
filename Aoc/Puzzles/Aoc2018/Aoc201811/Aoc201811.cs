using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201811;

[Name("Chronal Charge")]
public class Aoc201811 : AocPuzzle
{
    [Puzzle("f3fc6e4f392f91227d656e153bc6797b")]
    public string Part1(string input) => new PowerGrid(300, int.Parse(input)).GetMaxCoords().Id;

    [Puzzle("3519b00562141f570c15da87657755e1")]
    public string Part2(string input)
    {
        var grid = new PowerGrid(300, int.Parse(input));
        var (coords, size) = grid.GetMaxCoordsAnySize();
        return $"{coords.Id},{size}";
    }
}