using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202007;

[Name("Handy Haversacks")]
public class Aoc202007 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var processor = new LuggageProcessor(input);
        var count1 = processor.NumberOfBagsThatCanContainGoldBags();
        return new PuzzleResult(count1, "e58b666bd08fdb2db4284193545ca076");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var processor = new LuggageProcessor(input);
        var count2 = processor.NumberOfBagsThatAGoldBagContains();
        return new PuzzleResult(count2, "0362b078252328a96bca4cbfb7bcf250");
    }
}