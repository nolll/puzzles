using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202307;

[Name("Camel Cards")]
public class Aoc202307 : AocPuzzle
{
    [Puzzle("eb6c5937d75bbb79d79d7e01895aacd4")]
    public long Part1(string input) => Poker(input, new Part1PokerHandComparer());
    
    [Puzzle("dd9dfa02733e4b1eec0869e16d5b27ff")]
    public long Part2(string input) => Poker(input, new Part2PokerHandComparer());

    private static long Poker(string input, PokerHandComparer comparer) => input.Split(LineBreaks.Single)
        .Select(o => o.Split())
        .Select(o => new PokerHand(o.First(), int.Parse(o.Last())))
        .Order(comparer)
        .Select((o, index) => o.Bid * (index + 1))
        .Sum();
}