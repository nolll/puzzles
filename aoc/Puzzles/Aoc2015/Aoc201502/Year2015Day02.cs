using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201502;

public class Year2015Day02 : AocPuzzle
{
    public override string Name => "I Was Told There Would Be No Math";

    protected override PuzzleResult RunPart1()
    {
        var paperResult = GiftWrappingCalculator.GetRequiredPaper(InputFile);

        return new PuzzleResult(paperResult, 1_606_483);
    }

    protected override PuzzleResult RunPart2()
    {
        var ribbonResult = GiftWrappingCalculator.GetRequiredRibbon(InputFile);
            
        return new PuzzleResult(ribbonResult, 3_842_356);
    }
}