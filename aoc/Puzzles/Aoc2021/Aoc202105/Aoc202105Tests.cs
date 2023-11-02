using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2021.Aoc202105;

public class Aoc202105Tests
{
    [Test]
    public void Part1()
    {
        var game = new VentsMap();
        var result = game.Run(Input.Trim(), true);

        result.Should().Be(5);
    }

    [Test]
    public void Part2()
    {
        var game = new VentsMap();
        var result = game.Run(Input.Trim(), false);

        result.Should().Be(12);
    }

    private const string Input = """
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2
""";
}