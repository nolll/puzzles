using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202007;

[Name("Handy Haversacks")]
public class Aoc202007 : AocPuzzle
{
    [Puzzle("e58b666bd08fdb2db4284193545ca076")]
    public int Part1(string input) => new LuggageProcessor(input).NumberOfBagsThatCanContainGoldBags();

    [Puzzle("0362b078252328a96bca4cbfb7bcf250")]
    public int Part2(string input) => new LuggageProcessor(input).NumberOfBagsThatAGoldBagContains();
}