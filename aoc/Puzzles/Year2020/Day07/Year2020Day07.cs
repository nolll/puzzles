using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day07;

public class Year2020Day07 : AocPuzzle
{
    public override string Name => "Handy Haversacks";

    public override PuzzleResult RunPart1()
    {
        var processor = new LuggageProcessor(FileInput);
        var count1 = processor.NumberOfBagsThatCanContainGoldBags();
        return new PuzzleResult(count1, 272);
    }

    public override PuzzleResult RunPart2()
    {
        var processor = new LuggageProcessor(FileInput);
        var count2 = processor.NumberOfBagsThatAGoldBagContains();
        return new PuzzleResult(count2, 172246);
    }
}