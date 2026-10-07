using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202109Tests : PuzzleTest<Aoc202109>
{
    [Fact]
    public void Part1()
    {
        var heightMap = new Aoc202109.HeightMap();

        var result = heightMap.FindLowPointSum(Input);

        result.Should().Be(15);
    }

    [Fact]
    public void Part2()
    {
        var heightMap = new Aoc202109.HeightMap();
        var result = heightMap.FindBasinSizes(Input);

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