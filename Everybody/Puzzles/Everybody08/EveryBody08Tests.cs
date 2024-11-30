using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody08;

public class EveryBody08Tests
{
    [Test]
    public void Part1()
    {
        var result = Everybody08.Part1("13");
        result.Should().Be(21);
    }
    
    [Test]
    public void Part2()
    {
        var result = Everybody08.Part2("3", 50, 5);
        result.Should().Be(27);
    }
    
    [Test]
    public void Part3()
    {
        var result = Everybody08.Part3("2", 160, 5);
        result.Should().Be(2);
    }
}