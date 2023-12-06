using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202125;

public class Aoc202125Tests
{
    [Test]
    public void Part1()
    {
        var herd = new HerdOfSeaCucumbers(Input);
        var result = herd.MoveUntilStop();

        result.Should().Be(58);
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        result.Should().Be(0);
    }

    private const string Input = """
v...>>.vv>
.vv>>.vv..
>>.>v>...v
>>v>>.>.v.
v>v.vv.v..
>.>>..v...
.vv..>.>v.
v.v..>>v.v
....v..v.>
""";
}