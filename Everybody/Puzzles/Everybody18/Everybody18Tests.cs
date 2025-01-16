using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody18;

public class Everybody18Tests
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
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Everybody18 Sut => new();
}