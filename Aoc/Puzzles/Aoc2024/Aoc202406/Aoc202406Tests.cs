using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202406;

public class Aoc202406Tests
{
    private const string Input = """
                                 ....#.....
                                 .........#
                                 ..........
                                 ..#.......
                                 .......#..
                                 ..........
                                 .#..^.....
                                 ........#.
                                 #.........
                                 ......#...
                                 """;

    [Test]
    public void Part1()
    {
        Sut.Part1(Input).Answer.Should().Be("41");
    }

    [Test]
    public void Part2()
    {
        Sut.Part2(Input).Answer.Should().Be("6");
    }

    private static Aoc202406 Sut => new();
}