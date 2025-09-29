using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler054;

public class Euler054Tests
{
    [TestCase("AH KH QH JH TH", true)]
    [TestCase("AH 2H 3H 4H 5H", true)]
    public void IsStr8Flush(string hand, bool expected)
    {
        new Euler054.Hand(hand).IsStr8Flush.Should().Be(expected);
    }
    
    [Test]
    public void IsQuads()
    {
        var hand = new Euler054.Hand("AH AS AD AC KS");
        hand.IsQuads.Should().BeTrue();
    }
    
    [Test]
    public void IsBoat()
    {
        var hand = new Euler054.Hand("AH AS AD KC KS");
        hand.IsBoat.Should().BeTrue();
    }
    
    [TestCase("AH KC QS JD TH", true)]
    [TestCase("AH 2C 3S 4D 5H", true)]
    public void IsStr8(string hand, bool expected)
    {
        new Euler054.Hand(hand).IsStr8.Should().Be(expected);
    }
    
    [Test]
    public void IsTrips()
    {
        var hand = new Euler054.Hand("AH AS AD KC QS");
        hand.IsTrips.Should().BeTrue();
    }
    
    [Test]
    public void Is2Pair()
    {
        var hand = new Euler054.Hand("AH AS KD KC QS");
        hand.Is2Pair.Should().BeTrue();
    }
    
    [Test]
    public void IsPair()
    {
        var hand = new Euler054.Hand("AH AS KD QC JS");
        hand.IsPair.Should().BeTrue();
    }
}