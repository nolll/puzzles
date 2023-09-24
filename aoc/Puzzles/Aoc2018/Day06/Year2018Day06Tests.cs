using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Day06;

public class Year2018Day06Tests
{
    [Test]
    public void FindsLargestArea()
    {
        const string input = """
1, 1
1, 6
8, 3
3, 4
5, 5
8, 9
""";

        var finder = new LargestAreaFinder(input);
        var area = finder.GetSizeOfLargestArea();

        Assert.That(area, Is.EqualTo(17));
    }

    [Test]
    public void FindsAreaOfCentralArea()
    {
        const string input = """
1, 1
1, 6
8, 3
3, 4
5, 5
8, 9
""";

        var finder = new LargestAreaFinder(input);
        var area = finder.GetSizeOfCentralArea(32);

        Assert.That(area, Is.EqualTo(16));
    }
}