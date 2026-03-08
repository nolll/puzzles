using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201711;

[Name("Hex Ed")]
public class Aoc201711 : AocPuzzle
{
    [Puzzle("b7c04ecac2d0150916a741834019f8ec")]
    public int Part1(string input) => new HexGridNavigator(input).EndDistance;

    [Puzzle("f67800158ae4e032d3f2c498107dafa8")]
    public int Part2(string input) => new HexGridNavigator(input).MaxDistance;
}