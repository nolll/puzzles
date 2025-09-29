using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler054;

[Name("Poker Hands")]
public class Euler054 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var cards = line.Split();
            var h1 = cards.Take(5);
            var h2 = cards.Skip(5);
        }

        return new PuzzleResult(0);
    }

    public class Card
    {
        public char Suit { get; }
        public char Value { get; }
        public int Rank { get; }
        
        public Card(char suit, char value)
        {
            Suit = suit;
            Value = value;
            Rank = GetRank(value);
        }

        public Card(string id) : this(id[1], id[0])
        {
        }

        private int GetRank(char value) => value switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => 11,
            'T' => 10,
            _ => int.Parse(value.ToString())
        };
    }

    public class Hand
    {
        public Hand(Card[] cards)
        {
            Cards = cards;
        }
        
        public Hand(string cards) : this(cards.Split().Select(o => new Card(o)).ToArray())
        {
        }

        public Card[] Cards { get; }

        public bool IsStr8Flush => IsFlush && IsStr8;

        public bool IsQuads
        {
            get
            {
                var groups = Cards.GroupBy(o => o.Value).OrderByDescending(o => o.Count()).ToList();
                return groups.Count == 2 && groups.First().Count() == 4;
            }
        }

        public bool IsBoat
        {
            get
            {
                var groups = Cards.GroupBy(o => o.Value).OrderByDescending(o => o.Count()).ToList();
                return groups.Count == 2 && groups.First().Count() == 3 && groups.Last().Count() == 2;
            }
        }

        public bool IsFlush => Cards.Select(o => o.Suit).ToHashSet().Count == 1;

        public bool IsStr8
        {
            get
            {
                var sorted = Cards.OrderByDescending(o => o.Rank).ToArray();
                
                return sorted[0].Rank - 1 == sorted[1].Rank &&
                       sorted[1].Rank - 1 == sorted[2].Rank &&
                       sorted[2].Rank - 1 == sorted[3].Rank &&
                       sorted[3].Rank - 1 == sorted[4].Rank ||
                       sorted[0].Rank == 14 &&
                       sorted[1].Rank == 5 &&
                       sorted[2].Rank == 4 &&
                       sorted[3].Rank == 3 &&
                       sorted[4].Rank == 2;
            }
        }

        public bool IsTrips
        {
            get
            {
                var groups = Cards.GroupBy(o => o.Value).OrderByDescending(o => o.Count()).ToList();
                return groups.Count == 3 && groups.First().Count() == 3;
            }
        }

        public bool Is2Pair
        {
            get
            {
                var groups = Cards.GroupBy(o => o.Value).OrderByDescending(o => o.Count()).ToList();
                return groups.Count == 3 && groups.First().Count() == 2;
            }
        }

        public bool IsPair
        {
            get
            {
                var groups = Cards.GroupBy(o => o.Value).OrderByDescending(o => o.Count()).ToList();
                return groups.Count == 4 && groups.First().Count() == 2;
            }
        }
    }
}