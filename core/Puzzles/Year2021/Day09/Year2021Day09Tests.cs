using NUnit.Framework;

namespace Core.Puzzles.Year2021.Day09;

public class Year2021Day09Tests
{
    [Test]
    public void Part1()
    {
        var heightMap = new HeightMap();

        var result = heightMap.FindLowPointSum(Input.Trim());

        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void Part2()
    {
        var heightMap = new HeightMap();
        var result = heightMap.FindBasinSizes(Input.Trim());

        Assert.That(result, Is.EqualTo(1134));
    }

    private const string Input = """
2199943210
3987894921
9856789892
8767896789
9899965678
""";
}