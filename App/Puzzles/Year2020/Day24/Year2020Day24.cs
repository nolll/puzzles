using App.Platform;

namespace App.Puzzles.Year2020.Day24
{
    public class Year2020Day24 : PuzzleDay
    {
        public override PuzzleResult RunPart1()
        {
            var floor = new HexagonalFloor(FileInput);
            floor.Arrange();
            return new PuzzleResult(floor.BlackTileCount, 388);
        }

        public override PuzzleResult RunPart2()
        {
            var floor = new HexagonalFloor(FileInput);
            floor.Arrange();
            floor.Modify(100);
            return new PuzzleResult(floor.BlackTileCount, 4002);
        }
    }
}