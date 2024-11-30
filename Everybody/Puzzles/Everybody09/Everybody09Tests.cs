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
        
        var result = Everybody09.Part1(input);
        result.Should().Be(10);
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
        
        var result = Everybody09.Part2(input);
        result.Should().Be(10);
    }
}