using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201502;

public class Aoc201502 : AocPuzzle
{
    public override string Name => "I Was Told There Would Be No Math";

    protected override PuzzleResult RunPart1()
    {
        var paperResult = GiftWrappingCalculator.GetRequiredPaper(InputFile);

        return new PuzzleResult(paperResult, "dfdf9c79dfad493d6417a9a284a9670b");
    }

    protected override PuzzleResult RunPart2()
    {
        var ribbonResult = GiftWrappingCalculator.GetRequiredRibbon(InputFile);
            
        return new PuzzleResult(ribbonResult, "385d3372d91329e3166413c1cb3126d5");
    }
}