using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2020.Aoc202024;

public class Year2020Day24 : AocPuzzle
{
    public override string Name => "Lobby Layout";

    protected override PuzzleResult RunPart1()
    {
        var floor = new HexagonalFloor(InputFile);
        floor.Arrange();
        return new PuzzleResult(floor.BlackTileCount, 388);
    }

    protected override PuzzleResult RunPart2()
    {
        var floor = new HexagonalFloor(InputFile);
        floor.Arrange();
        floor.Modify(100);
        return new PuzzleResult(floor.BlackTileCount, 4002);
    }
}