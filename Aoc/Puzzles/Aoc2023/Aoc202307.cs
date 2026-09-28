using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023;

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
    
    public record PokerHand(string Hand, int Bid)
    {
        public HandRank Part1Rank => GetPart1Rank(Hand);
        public HandRank Part2Rank => GetPart2Rank(Hand);

        public static HandRank GetPart1Rank(string hand)
        {
            var d = hand.GroupBy(o => o).ToDictionary(k => k.Key, v => v.Count());

            return d.Keys.Count switch
            {
                1 => HandRank.FiveOfAKind,
                2 => d.Values.Max() == 4 ? HandRank.FourOfAKind : HandRank.FullHouse,
                3 => d.Values.Max() == 3 ? HandRank.ThreeOfAKind : HandRank.TwoPair,
                4 => HandRank.OnePair,
                _ => HandRank.HighCard
            };
        }

        public static HandRank GetPart2Rank(string hand)
        {
            var jackCount = hand.ToCharArray().Count(o => o == 'J');

            if (jackCount is 0 or 5)
                return GetPart1Rank(hand);

            var mostCommonCard = hand.Replace("J", "")
                .GroupBy(o => o)
                .ToDictionary(k => k.Key, v => v.Count())
                .MaxBy(o => o.Value).Key;

            return GetPart1Rank(hand.Replace('J', mostCommonCard));
        }
    }
    
    public enum HandRank
    {
        FiveOfAKind = 6,
        FourOfAKind = 5,
        FullHouse = 4,
        ThreeOfAKind = 3,
        TwoPair = 2,
        OnePair = 1,
        HighCard = 0
    }
    
    public class Part1PokerHandComparer() : PokerHandComparer(11)
    {
        public override int Compare(PokerHand? a, PokerHand? b)
        {
            if (a is null || b is null)
                return 0;

            if (a.Part1Rank != b.Part1Rank)
                return a.Part1Rank.CompareTo(b.Part1Rank);

            return Compare(a.Hand, b.Hand);
        }
    }
    
    public class Part2PokerHandComparer() : PokerHandComparer(1)
    {
        public override int Compare(PokerHand? a, PokerHand? b)
        {
            if (a is null || b is null)
                return 0;

            if (a.Part2Rank != b.Part2Rank)
                return a.Part2Rank.CompareTo(b.Part2Rank);

            return Compare(a.Hand, b.Hand);
        }
    }
    
    public abstract class PokerHandComparer(int jackValue) : IComparer<PokerHand>
    {
        private readonly Dictionary<char, int> _charValues = new()
        {
            { 'A', 14 },
            { 'K', 13 },
            { 'Q', 12 },
            { 'J', jackValue },
            { 'T', 10 },
            { '9', 9 },
            { '8', 8 },
            { '7', 7 },
            { '6', 6 },
            { '5', 5 },
            { '4', 4 },
            { '3', 3 },
            { '2', 2 },
        };

        protected int Compare(string a, string b)
        {
            var aArray = a.ToCharArray();
            var bArray = b.ToCharArray();

            for (var i = 0; i < a.Length; i++)
            {
                if (aArray[i] != bArray[i])
                    return _charValues[aArray[i]].CompareTo(_charValues[bArray[i]]);
            }

            return 0;
        }

        public abstract int Compare(PokerHand? x, PokerHand? y);
    }
}