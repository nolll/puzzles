using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202418;

public class Aoc202418Tests
{
    private const string Input = """
                                 5,4
                                 4,2
                                 4,5
                                 3,0
                                 2,1
                                 6,3
                                 2,4
                                 1,5
                                 0,6
                                 3,3
                                 2,6
                                 5,1
                                 1,2
                                 5,5
                                 2,5
                                 6,5
                                 1,4
                                 0,4
                                 6,4
                                 1,1
                                 6,1
                                 1,0
                                 0,5
                                 1,6
                                 2,0
                                 """;

    [Test]
    public void Part1()
    {
        Sut.Part1(Input, 12, 7, 7).Should().Be(22);
    }

    [Test]
    public void Part2()
    {
        Sut.Part2(Input, 7, 7).Should().Be("6,1");
    }

    private static Aoc202418 Sut => new();
}