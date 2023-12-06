using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202007;

public class Aoc202007 : AocPuzzle
{
    public override string Name => "Handy Haversacks";

    protected override PuzzleResult RunPart1()
    {
        var processor = new LuggageProcessor(InputFile);
        var count1 = processor.NumberOfBagsThatCanContainGoldBags();
        return new PuzzleResult(count1, "e58b666bd08fdb2db4284193545ca076");
    }

    protected override PuzzleResult RunPart2()
    {
        var processor = new LuggageProcessor(InputFile);
        var count2 = processor.NumberOfBagsThatAGoldBagContains();
        return new PuzzleResult(count2, "0362b078252328a96bca4cbfb7bcf250");
    }
}