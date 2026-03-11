using System.Numerics;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201922;

[NeedsRewrite]
[Name("Slam Shuffle")]
[Comment("Learn more math")]
public class Aoc201922 : AocPuzzle
{
    [Puzzle("40fa2fae9a8a1308387285c95b7d3844")]
    public int Part1(string input)
    {
        var shuffler1 = new CardShuffler();
        var deck = shuffler1.Shuffle(10_007, input);
        return deck.IndexOf(2019);
    }

    [Puzzle("19df07b5230d776df66b9378ef69dfc8")]
    public BigInteger Part2(string input) => new CardShuffler().ShuffleBig(input);
}