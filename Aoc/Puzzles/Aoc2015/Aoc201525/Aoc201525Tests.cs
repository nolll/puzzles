using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201525;

public class Aoc201525Tests
{
    [Test]
    public void FindsCode3_3()
    {
        const int targetX = 3;
        const int targetY = 3;

        var codeFinder = new WeatherMachineCodeFinder();
        var code = codeFinder.FindCodeAt(targetX, targetY);

        code.Should().Be(1601130);
    }

    [Test]
    public void FindsCode6_4()
    {
        const int targetX = 6;
        const int targetY = 4;

        var codeFinder = new WeatherMachineCodeFinder();
        var code = codeFinder.FindCodeAt(targetX, targetY);

        code.Should().Be(31527494);
    }
}