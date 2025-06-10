using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202418;

public class Ece202418Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             ##########
                             ..#......#
                             #.P.####P#
                             #.#...P#.#
                             ##########
                             """;

        Sut.Part1(input).Answer.Should().Be("11");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             #######################
                             ...P..P...#P....#.....#
                             #.#######.#.#.#.#####.#
                             #.....#...#P#.#..P....#
                             #.#####.#####.#########
                             #...P....P.P.P.....P#.#
                             #.#######.#####.#.#.#.#
                             #...#.....#P...P#.#....
                             #######################
                             """;

        Sut.Part2(input).Answer.Should().Be("21");
    }

    [Test]
    public void Part3()
    {
        const string input = """
                             ##########
                             #.#......#
                             #.P.####P#
                             #.#...P#.#
                             ##########
                             """;

        Sut.Part3(input).Answer.Should().Be("12");
    }

    private static Ece202418 Sut => new();
}