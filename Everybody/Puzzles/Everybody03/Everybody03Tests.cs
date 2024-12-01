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
        var result = Sut.RunPart1(Input);
        result.Answer.Should().Be("35");
    }
    
    [Test]
    public void Part3()
    {
        var result = Sut.RunPart3(Input);
        result.Answer.Should().Be("29");
    }

    private static Everybody03 Sut => new();
}