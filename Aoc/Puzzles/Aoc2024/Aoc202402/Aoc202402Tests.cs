using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202402;

public class Aoc202402Tests
{
    private const string Input = """
                                 7 6 4 2 1
                                 1 2 7 8 9
                                 9 7 6 2 1
                                 1 3 2 4 5
                                 8 6 4 4 1
                                 1 3 6 7 9
                                 """;

    [Test]
    public void Part1()
    {
        var result = Sut.Part1(Input);
        result.Answer.Should().Be("2");
    }
    
    [Test]
    public void Part2()
    {
        var result = Sut.Part2(Input);
        result.Answer.Should().Be("4");
    }

    private static Aoc202402 Sut => new();
}