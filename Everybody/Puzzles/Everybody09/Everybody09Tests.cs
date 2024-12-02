using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody09;

public class Everybody09Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             2
                             4
                             7
                             16
                             """;
        
        var result = Sut.RunPart1(input);
        result.Answer.Should().Be("10");
    }
    
    [Test]
    public void Part2()
    {
        const string input = """
                             33
                             41
                             55
                             99
                             """;
        
        var result = Sut.RunPart2(input);
        result.Answer.Should().Be("10");
    }
    
    [Test]
    public void Part3()
    {
        const string input = """
                             156488
                             352486
                             546212
                             """;
        
        var result = Sut.RunPart3(input);
        result.Answer.Should().Be("10449");
    }
    
    private static Everybody09 Sut => new();
}