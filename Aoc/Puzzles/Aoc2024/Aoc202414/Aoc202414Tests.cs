using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202414;

public class Aoc202414Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             p=0,4 v=3,-3
                             p=6,3 v=-1,-3
                             p=10,3 v=-1,2
                             p=2,0 v=2,-1
                             p=0,0 v=1,3
                             p=3,0 v=-2,-2
                             p=7,6 v=-1,-3
                             p=3,0 v=-1,-2
                             p=9,3 v=2,3
                             p=7,3 v=-1,2
                             p=2,4 v=2,-3
                             p=9,5 v=-3,-3
                             """;

        Sut.Part1(input, 11, 7).Should().Be(12);
    }

    [Test]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    private static Aoc202414 Sut => new();
}