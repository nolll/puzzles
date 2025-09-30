using Pzl.Common;
using Pzl.Tools.Debug;
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
            var h1 = new Hand(cards.Take(5));
            var h2 = new Hand(cards.Skip(5));

            var comparison = h1.CompareTo(h2);
            var result = GetWinDescription(comparison);
            
            DebugPrinter.Print(string.Join(" ", h1.Cards.Select(o => o.ToString())), h1.Rank.ToString());
            DebugPrinter.Print(string.Join(" ", h2.Cards.Select(o => o.ToString())), h2.Rank.ToString());
            DebugPrinter.Print(result);
            Console.WriteLine();
        }

        return new PuzzleResult(0);
    }

    private string GetWinDescription(int comparison) => comparison switch
    {
        1 => "P1 Wins",
        -1 => "P2 Wins",
        _ => "Draw"
    };

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

        private static int GetRank(char value) => value switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => 11,
            'T' => 10,
            _ => int.Parse(value.ToString())
        };

        public override string ToString() => $"{Value}{Suit}";
    }

    public enum HandRank
    {
        Str8Flush = 9,
        Quads = 8,
        Boat = 7,
        Flush = 6,
        Str8 = 5,
        Trips = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1
    }
    
    public class Hand
    {
        private int[] _rankComparer = [];
        
        public HandRank Rank { get; private set; }
        
        public Hand(Card[] cards)
        {
            Cards = cards;
            EvaluateHand(cards);
        }
        
        public Hand(string cards) : this(cards.Split())
        {
        }
        
        public Hand(IEnumerable<string> cards) : this(cards.Select(o => new Card(o)).ToArray())
        {
        }

        public Card[] Cards { get; }

        private static bool IsStr8(Card[] cards)
        {
            var sorted = cards.OrderByDescending(o => o.Rank).ToArray();
            
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

        public int CompareTo(Hand other)
        {
            if (other.Rank > Rank)
                return 1;
            if (other.Rank < Rank)
                return -1;

            for (var i = 0; i < _rankComparer.Length; i++)
            {
                if (other._rankComparer[i] > _rankComparer[i])
                    return 1;
                if (other._rankComparer[i] < _rankComparer[i])
                    return 1;
            }
            
            return 0;
        }
        
        private void EvaluateHand(Card[] cards)
        {
            var rankGroups = cards.GroupBy(o => o.Value).OrderByDescending(o => o.Count()).ThenByDescending(o => o.First().Rank).ToList();
            var rankGroupCount = rankGroups.Count;
            var largestGroupSize = rankGroups.First().Count();
            _rankComparer = rankGroups.Select(o => o.First().Rank).ToArray();
            
            if (rankGroupCount == 2 && largestGroupSize == 4)
            {
                Rank = HandRank.Quads;
                return;
            }
            
            if (rankGroupCount == 2 && largestGroupSize == 3)
            {
                Rank = HandRank.Boat;
                return;
            }

            if (rankGroupCount == 3 && largestGroupSize == 3)
            {
                Rank = HandRank.Trips;
                return;
            }

            if (rankGroupCount == 3 && largestGroupSize == 2)
            {
                Rank = HandRank.TwoPair;
                return;
            }

            if (rankGroupCount == 4 && largestGroupSize == 2)
            {
                Rank = HandRank.OnePair;
                return;
            }
            
            var suitGroups = cards.GroupBy(o => o.Suit);
            var isFlush = suitGroups.Count() == 1;
            var isStr8 = IsStr8(cards);
            
            if (isStr8 && isFlush)
            {
                Rank = HandRank.Str8Flush;
                return;
            }
            
            if (isFlush)
            {
                Rank = HandRank.Flush;
                return;
            }

            if (isStr8)
            {
                Rank = HandRank.Str8;
                return;
            }

            Rank = HandRank.HighCard;
        }
    }
}