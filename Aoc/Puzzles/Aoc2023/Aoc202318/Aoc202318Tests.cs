using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202318;

public class Aoc202318Tests
{
    [Test]
    public void LavaPoolPart1()
    {
        const string input = """
                             R 6 (#70c710)
                             D 5 (#0dc571)
                             L 2 (#5713f0)
                             D 2 (#d2c081)
                             R 2 (#59c680)
                             D 2 (#411b91)
                             L 5 (#8ceee2)
                             U 2 (#caa173)
                             L 1 (#1b58a2)
                             U 2 (#caa171)
                             R 2 (#7807d2)
                             U 3 (#a77fa3)
                             L 2 (#015232)
                             U 2 (#7a21e3)
                             """;

        var result = Aoc202318.DigPoolPart1(input);

        result.Should().Be(62);
    }

    [Test]
    public void LavaPoolPart2()
    {
        const string input = """
                             R 6 (#70c710)
                             D 5 (#0dc571)
                             L 2 (#5713f0)
                             D 2 (#d2c081)
                             R 2 (#59c680)
                             D 2 (#411b91)
                             L 5 (#8ceee2)
                             U 2 (#caa173)
                             L 1 (#1b58a2)
                             U 2 (#caa171)
                             R 2 (#7807d2)
                             U 3 (#a77fa3)
                             L 2 (#015232)
                             U 2 (#7a21e3)
                             """;

        var result = Aoc202318.DigPoolPart2(input);

        result.Should().Be(952408144115);
    }

    [TestCase("70c71", 461937)]
    [TestCase("0dc57", 56407)]
    [TestCase("5713f", 356671)]
    [TestCase("d2c08", 863240)]
    [TestCase("59c68", 367720)]
    [TestCase("411b9", 266681)]
    [TestCase("8ceee", 577262)]
    [TestCase("caa17", 829975)]
    [TestCase("1b58a", 112010)]
    [TestCase("caa17", 829975)]
    [TestCase("7807d", 491645)]
    [TestCase("a77fa", 686074)]
    [TestCase("01523", 5411)]
    [TestCase("7a21e", 500254)]
    public void ParseHex(string input, int expected)
    {
        var result = Aoc202318.ParseHex(input);

        result.Should().Be(expected);
    }
}