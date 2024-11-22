using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201502;

[Name("I Was Told There Would Be No Math")]
public class Aoc201502(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var paperResult = GiftWrappingCalculator.GetRequiredPaper(input);

        return new PuzzleResult(paperResult, "dfdf9c79dfad493d6417a9a284a9670b");
    }

    protected override PuzzleResult RunPart2()
    {
        var ribbonResult = GiftWrappingCalculator.GetRequiredRibbon(input);
            
        return new PuzzleResult(ribbonResult, "385d3372d91329e3166413c1cb3126d5");
    }
}