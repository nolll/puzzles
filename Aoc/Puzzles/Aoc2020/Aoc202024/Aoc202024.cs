using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202024;

[Name("Lobby Layout")]
public class Aoc202024 : AocPuzzle
{
    [Puzzle("5d93c546616fcdf4656b6333d8457200")]
    public int Part1(string input)
    {
        var floor = new HexagonalFloor(input);
        floor.Arrange();
        return floor.BlackTileCount;
    }

    [Puzzle("812d3dec4e5955c3c44ead98ed889522")]
    public int Part2(string input)
    {
        var floor = new HexagonalFloor(input);
        floor.Arrange();
        floor.Modify(100);
        return floor.BlackTileCount;
    }
}