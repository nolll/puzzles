using NUnit.Framework;

namespace Core.Puzzles.Year2021.Day05;

public class Year2021Day05Tests
{
    [Test]
    public void Part1()
    {
        var game = new VentsMap();
        var result = game.Run(Input, true);

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Part2()
    {
        var game = new VentsMap();
        var result = game.Run(Input, false);

        Assert.That(result, Is.EqualTo(12));
    }

    private const string Input = @"
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";
}