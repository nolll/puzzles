using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody01;

public class Everybody01Tests
{
    [Test]
    public void OneCreature()
    {
        const string input = "ABBAC";
        var count = Everybody01.CountPotionsForOneCreature(input);

        count.Should().Be(5);
    }
    
    [Test]
    public void TwoCreatures()
    {
        const string input = "AxBCDDCAxD";
        var count = Everybody01.CountPotionsForTwoCreatures(input);

        count.Should().Be(28);
    }
    
    [Test]
    public void ThreeCreatures()
    {
        const string input = "xBxAAABCDxCC";
        var count = Everybody01.CountPotionsForThreeCreatures(input);

        count.Should().Be(30);
    }
}