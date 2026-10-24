using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023;

[Name("Camel Cards")]
public class Aoc202307 : AocPuzzle
{
    [Puzzle("eb6c5937d75bbb79d79d7e01895aacd4")]
    public long Part1(string input) => Solve(input, CreatePart1PokerHand);

    [Puzzle("dd9dfa02733e4b1eec0869e16d5b27ff")]
    public long Part2(string input) => Solve(input, CreatePart2PokerHand);

    private static long Solve(string input, Func<string, int, PokerHand> createHand) => GetWinnings(ParseHands(input, createHand).Order());

    private static PokerHand CreatePart1PokerHand(string hand, int bid) => new PokerHand(hand, bid);
    private static PokerHand CreatePart2PokerHand(string hand, int bid) => new Part2PokerHand(hand, bid);

    public record PokerHand(string Hand, int Bid) : IComparable<PokerHand>
    {
        private HandRank? _rank;
        public HandRank Rank => GetRank(Hand);
        protected virtual int JackValue => 11;

        protected virtual HandRank GetRank(string hand)
        {
            if(_rank is not null)
                return _rank.Value;
            
            var d = hand.GroupBy(o => o).ToDictionary(k => k.Key, v => v.Count());

            _rank = d.Keys.Count switch
            {
                1 => HandRank.FiveOfAKind,
                2 => d.Values.Max() == 4 ? HandRank.FourOfAKind : HandRank.FullHouse,
                3 => d.Values.Max() == 3 ? HandRank.ThreeOfAKind : HandRank.TwoPair,
                4 => HandRank.OnePair,
                _ => HandRank.HighCard
            };
            
            return _rank.Value;
        }

        private int GetCharValue(char c) => c switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => JackValue,
            'T' => 10,
            '9' => 9,
            '8' => 8,
            '7' => 7,
            '6' => 6,
            '5' => 5,
            '4' => 4,
            '3' => 3,
            _ => 2
        };

        public int CompareTo(PokerHand? b)
        {
            if (b is null)
                return 0;

            if (Rank != b.Rank)
                return Rank.CompareTo(b.Rank);

            return Compare(Hand, b.Hand);
        }

        private int Compare(string a, string b)
        {
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return GetCharValue(a[i]).CompareTo(GetCharValue(b[i]));
            }

            return 0;
        }
    }

    public record Part2PokerHand(string Hand, int Bid) : PokerHand(Hand, Bid)
    {
        protected override int JackValue => 1;
        
        protected override HandRank GetRank(string hand)
        {
            var jackCount = hand.ToCharArray().Count(o => o == 'J');

            if (jackCount is 0 or 5)
                return base.GetRank(hand);

            var mostCommonCard = hand.Replace("J", "")
                .GroupBy(o => o)
                .ToDictionary(k => k.Key, v => v.Count())
                .MaxBy(o => o.Value).Key;

            return base.GetRank(hand.Replace('J', mostCommonCard));
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

    private static int GetWinnings(IOrderedEnumerable<PokerHand> orderedHands) =>
        orderedHands.Select((o, index) => o.Bid * (index + 1)).Sum();

    private static IEnumerable<PokerHand> ParseHands(string input, Func<string, int, PokerHand> createHand) => input.Split(LineBreaks.Single)
        .Select(o => o.Split())
        .Select(o => createHand(o.First(), int.Parse(o.Last())));
}