using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202220;

public class Aoc202220Tests
{
    [Test]
    public void Part1()
    {
        var result = Aoc202220.Run(Input, 1, 1);

        result.Should().Be(3);
    }

    [Test]
    public void Part2()
    {
        var result = Aoc202220.Run(Input, 811_589_153, 10);

        result.Should().Be(1623178306);
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