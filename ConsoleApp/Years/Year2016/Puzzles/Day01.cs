using Core.EasterbunnyHq;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day01 : Day2016
    {
        public Day01() : base(1)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calc = new EasterbunnyDistanceCalculator();
            calc.Go(FileInput);
            return new PuzzleResult($"Distance to target: {calc.DistanceToTarget}");
        }

        public override PuzzleResult RunPart2()
        {
            var calc = new EasterbunnyDistanceCalculator();
            return new PuzzleResult($"Distance to first repeated address: {calc.DistanceToFirstRepeat}");
        }
    }
}