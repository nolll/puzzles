using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202408;

public class EveryBody08Tests
{
    [Test]
    public void Part1()
    {
        var result = Sut.RunPart1("13");
        result.Answer.Should().Be("21");
    }
    
    [Test]
    public void Part2()
    {
        var result = Sut.RunPart2("3", 50, 5);
        result.Should().Be(27);
    }
    
    [Test]
    public void Part3()
    {
        var result = Sut.RunPart3("2", 160, 5);
        result.Should().Be(2);
    }
    
    private static Ece202408 Sut => new();
}