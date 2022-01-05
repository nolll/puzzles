using Core.Platform;

namespace Core.Puzzles.Year2015.Day02;

public class Year2015Day02 : Puzzle
{
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