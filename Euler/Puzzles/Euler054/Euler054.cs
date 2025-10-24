using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler054;

[Name("Poker Hands")]
public class Euler054 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var p1WinCount = 0;
        foreach (var line in lines)
        {
            var cards = line.Split();
            var h1 = new Hand(cards.Take(5));
            var h2 = new Hand(cards.Skip(5));

            var comparison = h1.CompareTo(h2);
            if (comparison > 0)
                p1WinCount++;
        }

        return new PuzzleResult(p1WinCount, "8d522a87a80f6f36a9599b3158b73a2b");
    }

    private class Card(char suit, char value)
    {
        public char Suit { get; } = suit;
        public char Value { get; } = value;
        public int Rank { get; } = GetRank(value);

        public Card(string id) : this(id[1], id[0]) {}

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

        private Hand(Card[] cards)
        {
            EvaluateHand(cards);
        }
        
        public Hand(string cards) : this(cards.Split()) {}
        
        public Hand(IEnumerable<string> cards) : this(cards.Select(o => new Card(o)).ToArray()) {}

        public int CompareTo(Hand other)
        {
            if (other.Rank > Rank)
                return -1;
            if (other.Rank < Rank)
                return 1;

            for (var i = 0; i < _rankComparer.Length; i++)
            {
                if (other._rankComparer[i] > _rankComparer[i])
                    return -1;
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
            
            switch (rankGroupCount)
            {
                case 2 when largestGroupSize == 4:
                    Rank = HandRank.Quads;
                    return;
                case 2 when largestGroupSize == 3:
                    Rank = HandRank.Boat;
                    return;
                case 3 when largestGroupSize == 3:
                    Rank = HandRank.Trips;
                    return;
                case 3 when largestGroupSize == 2:
                    Rank = HandRank.TwoPair;
                    return;
                case 4 when largestGroupSize == 2:
                    Rank = HandRank.OnePair;
                    return;
            }

            var suitGroups = cards.GroupBy(o => o.Suit);
            var isFlush = suitGroups.Count() == 1;
            
            var sorted = cards.OrderByDescending(o => o.Rank).ToArray();

            var isWheel = sorted[0].Rank == 14 &&
                          sorted[1].Rank == 5 &&
                          sorted[2].Rank == 4 &&
                          sorted[3].Rank == 3 &&
                          sorted[4].Rank == 2;
            
            var isStr8 = isWheel || 
                         sorted[0].Rank - 1 == sorted[1].Rank &&
                         sorted[1].Rank - 1 == sorted[2].Rank &&
                         sorted[2].Rank - 1 == sorted[3].Rank &&
                         sorted[3].Rank - 1 == sorted[4].Rank;
                          
            if (isWheel)
                _rankComparer = [5, 4, 3, 2, 1];
            
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