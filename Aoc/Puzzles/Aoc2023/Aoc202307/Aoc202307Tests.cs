namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202307;

public class Aoc202307Tests
{
    [Theory]
    [InlineData("AAAAA", HandRank.FiveOfAKind)]
    [InlineData("AA8AA", HandRank.FourOfAKind)]
    [InlineData("23332", HandRank.FullHouse)]
    [InlineData("TTT98", HandRank.ThreeOfAKind)]
    [InlineData("23432", HandRank.TwoPair)]
    [InlineData("A23A4", HandRank.OnePair)]
    [InlineData("23456", HandRank.HighCard)]
    public void GetHandRankPart1(string input, HandRank expected)
    {
        var result = PokerHand.GetPart1Rank(input);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("JJJJJ", HandRank.FiveOfAKind)] // 5
    [InlineData("JJJJ2", HandRank.FiveOfAKind)] // 4
    [InlineData("JJJ22", HandRank.FiveOfAKind)] // 3
    [InlineData("JJ222", HandRank.FiveOfAKind)] // 22
    [InlineData("J2222", HandRank.FiveOfAKind)] // 1
    [InlineData("JT555", HandRank.FourOfAKind)] // 1
    [InlineData("JJKTT", HandRank.FourOfAKind)] // 2
    [InlineData("JJKTQ", HandRank.ThreeOfAKind)] // 2
    [InlineData("JQQQA", HandRank.FourOfAKind)] // 1
    [InlineData("JQQ22", HandRank.FullHouse)] // 1
    [InlineData("JQQ2A", HandRank.ThreeOfAKind)] // 1
    [InlineData("JQ32A", HandRank.OnePair)] // 1
    public void GetHandRankPart2(string input, HandRank expected)
    {
        var result = PokerHand.GetPart2Rank(input);

        result.Should().Be(expected);
    }

    [Fact]
    public void PokerPart1()
    {
        const string input = """
                             32T3K 765
                             T55J5 684
                             KK677 28
                             KTJJT 220
                             QQQJA 483
                             """;

        var result = Aoc202307.PokerPart1(input);

        result.Should().Be(6440);
    }

    [Fact]
    public void PokerPart2()
    {
        const string input = """
                             32T3K 765
                             T55J5 684
                             KK677 28
                             KTJJT 220
                             QQQJA 483
                             """;

        var result = Aoc202307.PokerPart2(input);

        result.Should().Be(5905);
    }
}