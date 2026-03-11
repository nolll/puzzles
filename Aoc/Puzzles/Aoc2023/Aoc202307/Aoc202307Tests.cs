namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202307;

public class Aoc202307Tests
{
    private const string Input = """
                                 32T3K 765
                                 T55J5 684
                                 KK677 28
                                 KTJJT 220
                                 QQQJA 483
                                 """;

    [Theory]
    [InlineData("AAAAA", HandRank.FiveOfAKind)]
    [InlineData("AA8AA", HandRank.FourOfAKind)]
    [InlineData("23332", HandRank.FullHouse)]
    [InlineData("TTT98", HandRank.ThreeOfAKind)]
    [InlineData("23432", HandRank.TwoPair)]
    [InlineData("A23A4", HandRank.OnePair)]
    [InlineData("23456", HandRank.HighCard)]
    public void GetHandRankPart1(string input, HandRank expected) => PokerHand.GetPart1Rank(input).Should().Be(expected);

    [Theory]
    [InlineData("JJJJJ", HandRank.FiveOfAKind)]
    [InlineData("JJJJ2", HandRank.FiveOfAKind)]
    [InlineData("JJJ22", HandRank.FiveOfAKind)]
    [InlineData("JJ222", HandRank.FiveOfAKind)]
    [InlineData("J2222", HandRank.FiveOfAKind)]
    [InlineData("JT555", HandRank.FourOfAKind)]
    [InlineData("JJKTT", HandRank.FourOfAKind)]
    [InlineData("JJKTQ", HandRank.ThreeOfAKind)]
    [InlineData("JQQQA", HandRank.FourOfAKind)]
    [InlineData("JQQ22", HandRank.FullHouse)]
    [InlineData("JQQ2A", HandRank.ThreeOfAKind)]
    [InlineData("JQ32A", HandRank.OnePair)]
    public void GetHandRankPart2(string input, HandRank expected) => PokerHand.GetPart2Rank(input).Should().Be(expected);

    [Fact]
    public void PokerPart1() => Sut.Part1(Input).Should().Be(6440);

    [Fact]
    public void PokerPart2() => Sut.Part2(Input).Should().Be(5905);

    private static Aoc202307 Sut => new();
}