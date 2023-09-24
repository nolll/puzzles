using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2022.Aoc202224;

public class Year2022Day24Tests
{
    [Test]
    public void Part1()
    {
        var blizzardNavigation = new BlizzardNavigation(Input);
        var result = blizzardNavigation.Part1();

        Assert.That(result, Is.EqualTo(18));
    }

    [Test]
    public void Part2()
    {
        var blizzardNavigation = new BlizzardNavigation(Input);
        var result = blizzardNavigation.Part2();

        Assert.That(result, Is.EqualTo(54));
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