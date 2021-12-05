using Core.ChronalCoordinates;

namespace ConsoleApp.Puzzles.Year2018.Puzzles
{
    public class Year2018Day06 : Year2018Day
    {
        public override int Day => 6;

        public override PuzzleResult RunPart1()
        {
            var finder = new LargestAreaFinder(FileInput);
            var size = finder.GetSizeOfLargestArea();
            return new PuzzleResult(size, 3223);
        }

        public override PuzzleResult RunPart2()
        {
            var finder = new LargestAreaFinder(FileInput);
            var size = finder.GetSizeOfCentralArea(10000);
            return new PuzzleResult(size, 40_495);
        }
    }
}