using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleApp.Puzzles.Year2019.Day22
{
    /*
     * Most of part two was copied from https://github.com/sanraith/aoc2019/blob/master/aoc2019.Puzzles/Solutions/Day22.cs
     * I understand parts of the solution, but the mathematics is just too hard. I might come back for another try later
     * Here is an in-depth explanation: https://codeforces.com/blog/entry/72593
     */
    // todo: Understand code and rewrite
    public class CardShuffler
    {
        public IList<int> Reverse(IList<int> deck)
        {
            return deck.Reverse().ToList();
        }

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
            var deck = new List<int>();
            for (var i = 0; i < deckSize; i++)
            {
                deck.Add(i);
            }

            return Shuffle(deck, input.Trim().Split('\n').Select(o => o.Trim()).ToList());
        }

        public BigInteger ShuffleBig(string input)
        {
            return ShuffleBig(input.Trim().Split('\n').Select(o => o.Trim()).ToList());
        }

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