using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202224;

public class Aoc202224Tests
{
    [Test]
    public void Part1()
    {
        var blizzardNavigation = new BlizzardNavigation(Input);
        var result = blizzardNavigation.Part1();

        result.Should().Be(18);
    }

    [Test]
    public void Part2()
    {
        var blizzardNavigation = new BlizzardNavigation(Input);
        var result = blizzardNavigation.Part2();

        result.Should().Be(54);
    }

    private const string Input = """
                                 #.######
                                 #>>.<^<#
                                 #.<..<<#
                                 #>v.><>#
                                 #<^v^^>#
                                 ######.#
                                 """;
}