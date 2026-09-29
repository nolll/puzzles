using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

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
    
    /*
     * Most of part two was copied from https://github.com/sanraith/aoc2019/blob/master/aoc2019.Puzzles/Solutions/Day22.cs
     * I understand parts of the solution, but the mathematics is just too hard. I might come back for another try later
     * Here is an in-depth explanation: https://codeforces.com/blog/entry/72593
     */
    // todo: Understand code and rewrite
    public class CardShuffler
    {
        public IList<int> Reverse(IList<int> deck) => deck.Reverse().ToList();

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
            return Shuffle(deck, input.Trim().Split(LineBreaks.Single).Select(o => o.Trim()).ToList());
        }

        public BigInteger ShuffleBig(string input) => ShuffleBig(input.Trim().Split(LineBreaks.Single).Select(o => o.Trim()).ToList());

        private IList<int> Shuffle(IList<int> deck, IList<string> shuffles)
        {
            foreach (var shuffle in shuffles)
            {
                if (shuffle == "deal into new stack")
                {
                    deck = Reverse(deck);
                }
                else if (shuffle.StartsWith("deal with increment"))
                {
                    var n = int.Parse(shuffle.Split(" ").Last());
                    deck = Increment(deck, n);
                }
                else if (shuffle.StartsWith("cut"))
                {
                    var n = int.Parse(shuffle.Split(" ").Last());
                    deck = Cut(deck, n);
                }
            }

            return deck;
        }

        private BigInteger ShuffleBig(IList<string> shuffles)
        {
            const long deckSize = 119_315_717_514_047;
            const long shuffleCount = 101_741_582_076_661;
            const long targetPos = 2020;

            BigInteger a = 1;
            BigInteger b = 0;
            foreach (var shuffle in shuffles)
            {
                if (shuffle.StartsWith("cut"))
                {
                    BigInteger n = long.Parse(shuffle.Split(" ").Last());
                    b = deckSize + b - n;
                }
                else if (shuffle.StartsWith("deal with increment"))
                {
                    var n = long.Parse(shuffle.Split(" ").Last());
                    a *= n;
                    b *= n;

                }
                else if (shuffle == "deal into new stack")
                {
                    a *= -1;
                    b = deckSize - b - 1;
                }
            }

            var aBig = BigInteger.ModPow(a, shuffleCount, deckSize);
            var bBig = b * (aBig - 1) * ModuloInverse(a - 1, deckSize) % deckSize;
            var result = (targetPos - bBig) % deckSize * ModuloInverse(aBig, deckSize) % deckSize;

            if (result < 0)
                result += deckSize;

            return result;
        }

        private static BigInteger ModuloInverse(BigInteger a, BigInteger n) => BigInteger.ModPow(a, n - 2, n);
    }
}