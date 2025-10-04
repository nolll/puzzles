namespace Pzl.Euler.Puzzles.Euler054;

public class Euler054Tests
{
    [Theory]
    [InlineData("AH KH QH JH TH", Euler054.HandRank.Str8Flush)]
    [InlineData("AH 2H 3H 4H 5H", Euler054.HandRank.Str8Flush)]
    [InlineData("AH AS AD AC KS", Euler054.HandRank.Quads)]
    [InlineData("AH AS AD KC KS", Euler054.HandRank.Boat)]
    [InlineData("AH KC QS JD TH", Euler054.HandRank.Str8)]
    [InlineData("AH 2C 3S 4D 5H", Euler054.HandRank.Str8)]
    [InlineData("AH AS AD KC QS", Euler054.HandRank.Trips)]
    [InlineData("AH AS KD KC QS", Euler054.HandRank.TwoPair)]
    [InlineData("AH AS KD QC JS", Euler054.HandRank.OnePair)]
    [InlineData("AH KS QD JC 9S", Euler054.HandRank.HighCard)]
    public void IsParsedCorrect(string hand, Euler054.HandRank expected) => new Euler054.Hand(hand).Rank.Should().Be(expected);
    
    [Theory]
    [InlineData("2H 3H 4H 5H 6H", "AH 2H 3H 4H 5H")]
    [InlineData("AH KH QH JH TH", "2H 3H 4H 5H 6H")]
    [InlineData("AH AS AD AC KS", "AH AS AD AC QS")]
    [InlineData("AH AS AD AC KS", "KH KS KD KC AS")]
    [InlineData("AH AS AD KC KS", "AH AS AD QC QS")]
    [InlineData("AH AS AD QC QS", "KH KS KD QC QS")]
    [InlineData("3S 4D 5H 6C 7D", "2S 3D 4H 5C 6D")]
    [InlineData("AH AS AD QC JS", "KH KS KD QC JS")]
    [InlineData("AH AS AD KC QS", "AH AS AD KC JS")]
    [InlineData("AH AS KD KC QS", "AH AS QD QC JS")]
    [InlineData("AH AS KD KC QS", "AH AS KD KC JS")]
    [InlineData("AH AS QD JC 9S", "AH AS QD JC 8S")]
    [InlineData("AH AS QD JC 9S", "KH KS QD JC 9S")]
    [InlineData("AH KS QD JC 9S", "AH KS QD JC 8S")]
    public void CompareHands_LeftHandWins(string left, string right) => new Euler054.Hand(left).CompareTo(new Euler054.Hand(right)).Should().Be(1);
}