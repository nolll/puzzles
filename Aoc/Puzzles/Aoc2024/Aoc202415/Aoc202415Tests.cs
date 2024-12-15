using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202415;

public class Aoc202415Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             ########
                             #..O.O.#
                             ##@.O..#
                             #...O..#
                             #.#.O..#
                             #...O..#
                             #......#
                             ########
                             
                             <^^>>>vv<v>>v<<
                             """;

        Sut.Part1(input).Answer.Should().Be("2028");
    }

    [Test]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    private static Aoc202415 Sut => new();
}