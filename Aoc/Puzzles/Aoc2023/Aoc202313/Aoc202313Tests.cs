using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202313;

public class Aoc202313Tests
{
    [Test]
    public void Mirrors()
    {
        const string input = """
                             #.##..##.
                             ..#.##.#.
                             ##......#
                             ##......#
                             ..#.##.#.
                             ..##..##.
                             #.#.##.#.
                             """;

        var result = Aoc202313.CountReflections(input);

        result.Should().Be(5);
    }

    [Test]
    public void SmudgedMirrors()
    {
        const string input = """
                             #.##..##.
                             ..#.##.#.
                             ##......#
                             ##......#
                             ..#.##.#.
                             ..##..##.
                             #.#.##.#.
                             """;

        var result = Aoc202313.CountSmudgedReflections(input);

        result.Should().Be(300);
    }

    [Test]
    public void SmudgedMirrors2()
    {
        const string input = """
                             #...##..#
                             #....#..#
                             ..##..###
                             #####.##.
                             #####.##.
                             ..##..###
                             #....#..#
                             """;

        var result = Aoc202313.CountSmudgedReflections(input);

        result.Should().Be(100);
    }

    [Test]
    public void Part1()
    {
        const string input = """
                             #.##..##.
                             ..#.##.#.
                             ##......#
                             ##......#
                             ..#.##.#.
                             ..##..##.
                             #.#.##.#.
                             
                             #...##..#
                             #....#..#
                             ..##..###
                             #####.##.
                             #####.##.
                             ..##..###
                             #....#..#
                             """;

        var result = new Aoc202313(input).RunFunctions.First()();

        result.Answer.Should().Be("405");
    }

    [Test]
    public void Part2()
    {
        const string input = """
                             #.##..##.
                             ..#.##.#.
                             ##......#
                             ##......#
                             ..#.##.#.
                             ..##..##.
                             #.#.##.#.

                             #...##..#
                             #....#..#
                             ..##..###
                             #####.##.
                             #####.##.
                             ..##..###
                             #....#..#
                             """;

        var result = new Aoc202313(input).RunFunctions.Last()();

        result.Answer.Should().Be("400");
    }
}