using Core.GiftWrapping;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day02 : Day2015
    {
        public Day02() : base(2)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calc = new GiftWrappingCalculator();
            var paperResult = calc.GetRequiredPaper(FileInput);
            return new PuzzleResult($"Required wrapping paper: {paperResult} square feet");
        }

        public override PuzzleResult RunPart2()
        {
            var calc = new GiftWrappingCalculator();
            var ribbonResult = calc.GetRequiredRibbon(FileInput);
            return new PuzzleResult($"Required ribbon: {ribbonResult} feet");
        }
    }
}