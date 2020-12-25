using Core.HexagonalFlooring;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day24 : Day2020
    {
        public Day24() : base(24)
        {
        }

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