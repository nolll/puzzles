namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202307;

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