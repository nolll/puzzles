using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody03;

public class Everybody03Tests
{
    private const string Input = """
                                 ..........
                                 ..###.##..
                                 ...####...
                                 ..######..
                                 ..######..
                                 ...####...
                                 ..........
                                 """;

    [Test]
    public void Part1And2()
    {
        var result = Everybody03.Run(Input);
        result.Should().Be(35);
    }
    
    [Test]
    public void Part3()
    {
        var result = Everybody03.Run(Input, true);
        result.Should().Be(29);
    }
}