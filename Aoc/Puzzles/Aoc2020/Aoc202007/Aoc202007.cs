using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202007;

[Name("Handy Haversacks")]
public class Aoc202007 : AocPuzzle
{
    [Puzzle("e58b666bd08fdb2db4284193545ca076")]
    public PuzzleResult Part1(string input)
    {
        var processor = new LuggageProcessor(input);
        var count1 = processor.NumberOfBagsThatCanContainGoldBags();
        return new PuzzleResult(count1);
    }

    [Puzzle("0362b078252328a96bca4cbfb7bcf250")]
    public PuzzleResult Part2(string input)
    {
        var processor = new LuggageProcessor(input);
        var count2 = processor.NumberOfBagsThatAGoldBagContains();
        return new PuzzleResult(count2);
    }
}