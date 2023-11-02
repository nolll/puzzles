using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Aoc201825;

public class Aoc201825Tests
{
    [Test]
    public void FindsConstellations1()
    {
        const string input = """
 0,0,0,0
 3,0,0,0
 0,3,0,0
 0,0,3,0
 0,0,0,3
 0,0,0,6
 9,0,0,0
12,0,0,0
""";

        var finder = new ConstellationFinder(input.Trim());
        var constellationCount = finder.Find();

        constellationCount.Should().Be(2);
    }

    [Test]
    public void FindsConstellations2()
    {
        const string input = """
-1,2,2,0
0,0,2,-2
0,0,0,-2
-1,2,0,0
-2,-2,-2,2
3,0,2,-1
-1,3,2,2
-1,0,-1,0
0,2,1,-2
3,0,0,0
""";

        var finder = new ConstellationFinder(input.Trim());
        var constellationCount = finder.Find();

        constellationCount.Should().Be(4);
    }

    [Test]
    public void FindsConstellations3()
    {
        const string input = """
1,-1,0,1
2,0,-1,0
3,2,-1,0
0,0,3,1
0,0,-1,-1
2,3,-2,0
-2,2,0,0
2,-2,0,-1
1,-1,0,-1
3,2,0,2
""";

        var finder = new ConstellationFinder(input.Trim());
        var constellationCount = finder.Find();

        constellationCount.Should().Be(3);
    }

    [Test]
    public void FindsConstellations4()
    {
        const string input = """
1,-1,-1,-2
-2,-2,0,1
0,2,1,3
-2,3,-2,1
0,2,3,-2
-1,-1,1,-2
0,-2,-1,0
-2,2,3,-1
1,2,2,0
-1,-2,0,-2
""";

        var finder = new ConstellationFinder(input.Trim());
        var constellationCount = finder.Find();

        constellationCount.Should().Be(8);
    }
}