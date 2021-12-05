using Core.GiftWrapping;

namespace ConsoleApp.Puzzles.Year2015.Puzzles
{
    public class Year2015Day02 : Year2015Day
    {
        public override int Day => 2;

        public override PuzzleResult RunPart1()
        {
            var calc = new GiftWrappingCalculator();
            var paperResult = calc.GetRequiredPaper(FileInput);

            return new PuzzleResult(paperResult, 1_606_483);
        }

        public override PuzzleResult RunPart2()
        {
            var calc = new GiftWrappingCalculator();
            var ribbonResult = calc.GetRequiredRibbon(FileInput);
            
            return new PuzzleResult(ribbonResult, 3_842_356);
        }
    }
}