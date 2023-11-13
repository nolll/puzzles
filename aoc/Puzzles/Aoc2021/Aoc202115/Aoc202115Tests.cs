using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202115;

public class Aoc202115Tests
{
    [Test]
    public void Part1()
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForSmallCave(Input);

        result.Should().Be(40);
    }

    [Test]
    public void Part2()
    {
        var chitonRisk = new ChitonRisk();
        var result = chitonRisk.FindRiskLevelForLargeCave(Input);

        result.Should().Be(315);
    }

    private const string Input = """
1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581
""";
}