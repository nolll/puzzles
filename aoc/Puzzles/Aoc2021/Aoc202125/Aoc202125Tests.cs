using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2021.Aoc202125;

public class Aoc202125Tests
{
    [Test]
    public void Part1()
    {
        var herd = new HerdOfSeaCucumbers(Input);
        var result = herd.MoveUntilStop();

        Assert.That(result, Is.EqualTo(58));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
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