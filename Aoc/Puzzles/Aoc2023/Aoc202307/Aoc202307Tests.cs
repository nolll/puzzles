using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202307;

public class Aoc202307Tests
{
    [TestCase("AAAAA", HandRank.FiveOfAKind)]
    [TestCase("AA8AA", HandRank.FourOfAKind)]
    [TestCase("23332", HandRank.FullHouse)]
    [TestCase("TTT98", HandRank.ThreeOfAKind)]
    [TestCase("23432", HandRank.TwoPair)]
    [TestCase("A23A4", HandRank.OnePair)]
    [TestCase("23456", HandRank.HighCard)]
    public void GetHandRankPart1(string input, HandRank expected)
    {
        var result = PokerHand.GetPart1Rank(input);

        result.Should().Be(expected);
    }

    [TestCase("JJJJJ", HandRank.FiveOfAKind)] // 5
    [TestCase("JJJJ2", HandRank.FiveOfAKind)] // 4
    [TestCase("JJJ22", HandRank.FiveOfAKind)] // 3
    [TestCase("JJ222", HandRank.FiveOfAKind)] // 22
    [TestCase("J2222", HandRank.FiveOfAKind)] // 1
    [TestCase("JT555", HandRank.FourOfAKind)] // 1
    [TestCase("JJKTT", HandRank.FourOfAKind)] // 2
    [TestCase("JJKTQ", HandRank.ThreeOfAKind)] // 2
    [TestCase("JQQQA", HandRank.FourOfAKind)] // 1
    [TestCase("JQQ22", HandRank.FullHouse)] // 1
    [TestCase("JQQ2A", HandRank.ThreeOfAKind)] // 1
    [TestCase("JQ32A", HandRank.OnePair)] // 1
    public void GetHandRankPart2(string input, HandRank expected)
    {
        var result = PokerHand.GetPart2Rank(input);

        result.Should().Be(expected);
    }

    [Test]
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

    [Test]
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