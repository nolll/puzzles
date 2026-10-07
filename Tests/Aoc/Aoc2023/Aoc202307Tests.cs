using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202307Tests : PuzzleTest<Aoc202307>
{
    private const string Input = """
                                 32T3K 765
                                 T55J5 684
                                 KK677 28
                                 KTJJT 220
                                 QQQJA 483
                                 """;

    [Theory]
    [InlineData("AAAAA", Aoc202307.HandRank.FiveOfAKind)]
    [InlineData("AA8AA", Aoc202307.HandRank.FourOfAKind)]
    [InlineData("23332", Aoc202307.HandRank.FullHouse)]
    [InlineData("TTT98", Aoc202307.HandRank.ThreeOfAKind)]
    [InlineData("23432", Aoc202307.HandRank.TwoPair)]
    [InlineData("A23A4", Aoc202307.HandRank.OnePair)]
    [InlineData("23456", Aoc202307.HandRank.HighCard)]
    public void GetHandRankPart1(string input, Aoc202307.HandRank expected) => Aoc202307.PokerHand.GetPart1Rank(input).Should().Be(expected);

    [Theory]
    [InlineData("JJJJJ", Aoc202307.HandRank.FiveOfAKind)]
    [InlineData("JJJJ2", Aoc202307.HandRank.FiveOfAKind)]
    [InlineData("JJJ22", Aoc202307.HandRank.FiveOfAKind)]
    [InlineData("JJ222", Aoc202307.HandRank.FiveOfAKind)]
    [InlineData("J2222", Aoc202307.HandRank.FiveOfAKind)]
    [InlineData("JT555", Aoc202307.HandRank.FourOfAKind)]
    [InlineData("JJKTT", Aoc202307.HandRank.FourOfAKind)]
    [InlineData("JJKTQ", Aoc202307.HandRank.ThreeOfAKind)]
    [InlineData("JQQQA", Aoc202307.HandRank.FourOfAKind)]
    [InlineData("JQQ22", Aoc202307.HandRank.FullHouse)]
    [InlineData("JQQ2A", Aoc202307.HandRank.ThreeOfAKind)]
    [InlineData("JQ32A", Aoc202307.HandRank.OnePair)]
    public void GetHandRankPart2(string input, Aoc202307.HandRank expected) => Aoc202307.PokerHand.GetPart2Rank(input).Should().Be(expected);

    [Fact]
    public void PokerPart1() => Sut.Part1(Input).Should().Be(6440);

    [Fact]
    public void PokerPart2() => Sut.Part2(Input).Should().Be(5905);
}