using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202024;

[Name("Lobby Layout")]
public class Aoc202024 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var floor = new HexagonalFloor(input);
        floor.Arrange();
        return new PuzzleResult(floor.BlackTileCount, "5d93c546616fcdf4656b6333d8457200");
    }

    public PuzzleResult RunPart2(string input)
    {
        var floor = new HexagonalFloor(input);
        floor.Arrange();
        floor.Modify(100);
        return new PuzzleResult(floor.BlackTileCount, "812d3dec4e5955c3c44ead98ed889522");
    }
}