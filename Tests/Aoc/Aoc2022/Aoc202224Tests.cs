using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202224Tests : PuzzleTest<Aoc202224>
{
    [Fact]
    public void Part1()
    {
        var blizzardNavigation = new Aoc202224.BlizzardNavigation(Input);
        var result = blizzardNavigation.Part1();

        result.Should().Be(18);
    }

    [Fact]
    public void Part2()
    {
        var blizzardNavigation = new Aoc202224.BlizzardNavigation(Input);
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