using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202024;

public class Aoc202024 : AocPuzzle
{
    public override string Name => "Lobby Layout";

    protected override PuzzleResult RunPart1()
    {
        var floor = new HexagonalFloor(InputFile);
        floor.Arrange();
        return new PuzzleResult(floor.BlackTileCount, "5d93c546616fcdf4656b6333d8457200");
    }

    protected override PuzzleResult RunPart2()
    {
        var floor = new HexagonalFloor(InputFile);
        floor.Arrange();
        floor.Modify(100);
        return new PuzzleResult(floor.BlackTileCount, "812d3dec4e5955c3c44ead98ed889522");
    }
}