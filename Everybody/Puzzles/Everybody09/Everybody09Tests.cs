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
}