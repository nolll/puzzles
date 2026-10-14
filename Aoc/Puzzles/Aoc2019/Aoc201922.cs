using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

/*
 * Most of part two was copied from https://github.com/sanraith/aoc2019/blob/master/aoc2019.Puzzles/Solutions/Day22.cs
 * I understand parts of the solution, but the mathematics is just too hard. I might come back for another try later
 * Here is an in-depth explanation: https://codeforces.com/blog/entry/72593
 */
// todo: Understand code and rewrite

[NeedsRewrite]
[Name("Slam Shuffle")]
[Comment("Learn more math")]
public class Aoc201922 : AocPuzzle
{
    private const long Part2DeckSize = 119_315_717_514_047;
    private const long Part2ShuffleCount = 101_741_582_076_661;
    private const long Part2TargetPos = 2020;

    [Puzzle("40fa2fae9a8a1308387285c95b7d3844")]
    public int Part1(string input) => Shuffle(10_007, input).IndexOf(2019);

    [Puzzle("19df07b5230d776df66b9378ef69dfc8")]
    public BigInteger Part2(string input) => ShuffleBig(input);

    public IList<int> Reverse(IList<int> deck) => [.. deck.Reverse()];

    public IList<int> Cut(IList<int> deck, int count)
    {
        var offset = count < 0
            ? deck.Count + count
            : count;

        var itemsToMove = deck.Take(offset);
        var newDeck = deck.Skip(offset).ToList();
        newDeck.AddRange(itemsToMove);
        return newDeck;
    }

    public IList<int> Increment(IList<int> deck, int n)
    {
        var newDeck = new int[deck.Count];
        var position = 0;
        for (var i = 0; i < deck.Count; i++)
        {
            var card = deck[i];
            newDeck[position] = card;
            position += n;
            if (position > deck.Count - 1)
                position -= deck.Count;
        }

        return newDeck;
    }

    public IList<int> Shuffle(int deckSize, string input)
    {
        var deck = Enumerable.Range(0, deckSize).ToList();
        return Shuffle(deck, [.. input.Split(LineBreaks.Single)]);
    }

    private BigInteger ShuffleBig(string input) => ShuffleBig([.. input.Split(LineBreaks.Single)]);
    private IList<int> Shuffle(IList<int> deck, IList<string> shuffles) => shuffles.Aggregate(deck, Shuffle);
    private IList<int> Shuffle(IList<int> deck, string shuffle) => ParseType(shuffle) switch
    {
        ShuffleType.DealIntoNewStack => Reverse(deck),
        ShuffleType.DealWithIncrement => Increment(deck, int.Parse(shuffle.Split(" ").Last())),
        ShuffleType.Cut => Cut(deck, int.Parse(shuffle.Split(" ").Last())),
        _ => deck
    };

    private BigInteger ShuffleBig(IList<string> shuffles)
    {
        BigInteger a = 1;
        BigInteger b = 0;
        foreach (var shuffle in shuffles) 
            (a, b) = ShuffleBig(a, b, shuffle);

        var aBig = BigInteger.ModPow(a, Part2ShuffleCount, Part2DeckSize);
        var bBig = b * (aBig - 1) * ModuloInverse(a - 1, Part2DeckSize) % Part2DeckSize;
        var result = (Part2TargetPos - bBig) % Part2DeckSize * ModuloInverse(aBig, Part2DeckSize) % Part2DeckSize;

        if (result < 0)
            result += Part2DeckSize;

        return result;
    }

    private (BigInteger, BigInteger) ShuffleBig(BigInteger a, BigInteger b, string shuffle) => ParseType(shuffle) switch
    {
        ShuffleType.Cut => CutBig(a, b, shuffle),
        ShuffleType.DealWithIncrement => DealWithIncrementBig(a, b, shuffle),
        ShuffleType.DealIntoNewStack => DealIntoNewStackBig(a, b),
        _ => (a, b)
    };

    private (BigInteger, BigInteger) CutBig(BigInteger a, BigInteger b, string shuffle) => 
        (a, Part2DeckSize + b - long.Parse(shuffle.Split(" ").Last()));

    private (BigInteger, BigInteger) DealWithIncrementBig(BigInteger a, BigInteger b, string shuffle)
    {
        var n = long.Parse(shuffle.Split(" ").Last());
        return (a * n, b * n);
    }
    
    private (BigInteger, BigInteger) DealIntoNewStackBig(BigInteger a, BigInteger b) => (a * -1, Part2DeckSize - b - 1);

    private static BigInteger ModuloInverse(BigInteger a, BigInteger n) => BigInteger.ModPow(a, n - 2, n);

    private static ShuffleType ParseType(string s)
    {
        if (s.StartsWith("cut"))
            return ShuffleType.Cut; 
        if (s.StartsWith("deal with increment"))
            return ShuffleType.DealWithIncrement;
        return ShuffleType.DealIntoNewStack;
    }
    
    private enum ShuffleType
    {
        Cut,
        DealWithIncrement,
        DealIntoNewStack
    }
}