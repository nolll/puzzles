using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202204;

public class Aoc202204Tests
{
    [Test]
    public void Part1()
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part1(Input);

        result.Should().Be(2);
    }

    [Test]
    public void Part2()
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part2(Input);

        result.Should().Be(4);
    }

    private const string Input = """
                                 2-4,6-8
                                 2-3,4-5
                                 5-7,7-9
                                 2-8,3-7
                                 6-6,4-6
                                 2-6,4-8
                                 """;
}