using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202412;

public class Aoc202412Tests
{
    [Test]
    public void Part1_1()
    {
        const string input = """
                             AAAA
                             BBCD
                             BBCC
                             EEEC
                             """;

        Sut.Part1(input).Answer.Should().Be("140");
    }

    [Test]
    public void Part1_2()
    {
        const string input = """
                             RRRRIICCFF
                             RRRRIICCCF
                             VVRRRCCFFF
                             VVRCCCJFFF
                             VVVVCJJCFE
                             VVIVCCJJEE
                             VVIIICJJEE
                             MIIIIIJJEE
                             MIIISIJEEE
                             MMMISSJEEE
                             """;

        Sut.Part1(input).Answer.Should().Be("1930");
    }
    
    [Test]
    public void Part2_1()
    {
        const string input = """
                             AAAA
                             BBCD
                             BBCC
                             EEEC
                             """;

        Sut.Part2(input).Answer.Should().Be("80");
    }
    
    [Test]
    public void Part2_2()
    {
        const string input = """
                             RRRRIICCFF
                             RRRRIICCCF
                             VVRRRCCFFF
                             VVRCCCJFFF
                             VVVVCJJCFE
                             VVIVCCJJEE
                             VVIIICJJEE
                             MIIIIIJJEE
                             MIIISIJEEE
                             MMMISSJEEE
                             """;

        Sut.Part2(input).Answer.Should().Be("1206");
    }
    
    [Test]
    public void Part2_3()
    {
        const string input = """
                             EEEEE
                             EXXXX
                             EEEEE
                             EXXXX
                             EEEEE
                             """;

        Sut.Part2(input).Answer.Should().Be("236");
    }
    
    [Test]
    public void Part2_4()
    {
        const string input = """
                             AAAAAA
                             AAABBA
                             AAABBA
                             ABBAAA
                             ABBAAA
                             AAAAAA
                             """;

        Sut.Part2(input).Answer.Should().Be("368");
    }

    private static Aoc202412 Sut => new();
}