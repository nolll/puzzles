using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202109;

public class Aoc202109Tests
{
    [Test]
    public void Part1()
    {
        var heightMap = new HeightMap();

        var result = heightMap.FindLowPointSum(Input.Trim());

        result.Should().Be(15);
    }

    [Test]
    public void Part2()
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindBasinSizes(Input.Trim());

        result.Should().Be(1134);
    }

    private const string Input = """
2199943210
3987894921
9856789892
8767896789
9899965678
""";
}