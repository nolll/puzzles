using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler054;

public class Euler054Tests
{
    [TestCase("AH KH QH JH TH", Euler054.HandRank.Str8Flush)]
    [TestCase("AH 2H 3H 4H 5H", Euler054.HandRank.Str8Flush)]
    [TestCase("AH AS AD AC KS", Euler054.HandRank.Quads)]
    [TestCase("AH AS AD KC KS", Euler054.HandRank.Boat)]
    [TestCase("AH KC QS JD TH", Euler054.HandRank.Str8)]
    [TestCase("AH 2C 3S 4D 5H", Euler054.HandRank.Str8)]
    [TestCase("AH AS AD KC QS", Euler054.HandRank.Trips)]
    [TestCase("AH AS KD KC QS", Euler054.HandRank.TwoPair)]
    [TestCase("AH AS KD QC JS", Euler054.HandRank.OnePair)]
    [TestCase("AH KS QD JC 9S", Euler054.HandRank.HighCard)]
    public void IsParsedCorrect(string hand, Euler054.HandRank expected) => new Euler054.Hand(hand).Rank.Should().Be(expected);
    
    [TestCase("AH KH QH JH TH", "2H 3H 4H 5H 6H")]
    [TestCase("AH AS AD AC KS", "AH AS AD AC QS")]
    [TestCase("AH AS AD AC KS", "KH KS KD KC AS")]
    [TestCase("AH AS AD KC KS", "AH AS AD QC QS")]
    [TestCase("KH KS KD KC KS", "AH AS AD QC QS")]
    [TestCase("3S 4D 5H 6C 7D", "2S 3D 4H 5C 6D")]
    [TestCase("AH AS AD QC JS", "KH KS KD QC JS")]
    [TestCase("AH AS AD KC QS", "AH AS AD KC JS")]
    [TestCase("AH AS KD KC QS", "AH AS QD QC JS")]
    [TestCase("AH AS KD KC QS", "AH AS KD KC JS")]
    [TestCase("AH AS QD JC 9S", "AH AS QD JC 8S")]
    [TestCase("AH AS QD JC 9S", "KH KS QD JC 9S")]
    [TestCase("AH KS QD JC 9S", "AH KS QD JC 8S")]
    public void CompareHands_HandOneWins(string h1, string h2) => new Euler054.Hand(h1).CompareTo(new Euler054.Hand(h2)).Should().Be(1);
}