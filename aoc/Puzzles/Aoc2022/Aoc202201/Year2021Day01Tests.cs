using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2022.Aoc202201;

public class Year2022Day01Tests
{
    [Test]
    public void Part1()
    {
        var calorieCounts = new CalorieCounts(Input);
        var result = calorieCounts.TopSum;

        Assert.That(result, Is.EqualTo(24000));
    }

    [Test]
    public void Part2()
    {
        var calorieCounts = new CalorieCounts(Input);
        var result = calorieCounts.Top3Sum;

        Assert.That(result, Is.EqualTo(45000));
    }

    private const string Input = """
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000
""";
}