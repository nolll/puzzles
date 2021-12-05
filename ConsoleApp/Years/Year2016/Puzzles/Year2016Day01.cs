using Core.EasterbunnyHq;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Year2016Day01 : Year2016Day
    {
        public override int Day => 1;

        public override PuzzleResult RunPart1()
        {
            var calc = new EasterbunnyDistanceCalculator();
            calc.Go(FileInput);
            return new PuzzleResult(calc.DistanceToTarget, 262);
        }

        public override PuzzleResult RunPart2()
        {
            var calc = new EasterbunnyDistanceCalculator();
            calc.Go(FileInput);
            return new PuzzleResult(calc.DistanceToFirstRepeat, 131);
        }
    }
}