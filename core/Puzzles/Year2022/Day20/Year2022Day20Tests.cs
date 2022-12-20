using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day20;

public class Year2022Day20Tests
{
    [Test]
    public void Part1()
    {
        var puzzle = new Year2022Day20();
        var result = Year2022Day20.Run(Input, 1, 1);

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Part2()
    {
        var puzzle = new Year2022Day20();
        var result = Year2022Day20.Run(Input, 811_589_153, 10);

        Assert.That(result, Is.EqualTo(1623178306));
    }

    private const string Input = """
1
2
-3
3
-2
0
4
""";
}