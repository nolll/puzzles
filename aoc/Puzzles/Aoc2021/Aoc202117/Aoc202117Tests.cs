using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202117;

public class Aoc202117Tests
{
    [Test]
    public void Part1()
    {
        var target = new TrickshotTarget(20, 30, -10, -5);

        var trickshot = new TrickShot();
        var result = trickshot.Shoot(target);

        result.MaxHeight.Should().Be(45);
    }

    [Test]
    public void SingleMaxHeight()
    {
        var target = new TrickshotTarget(20, 30, -10, -5);

        var trickshot = new TrickShot();
        var result = trickshot.GetMaxHeight(target, 6, 9);

        result.Should().Be(45);
    }

    [Test]
    public void SingleVelocityCount()
    {
        var target = new TrickshotTarget(20, 30, -10, -5);

        var trickshot = new TrickShot();
        var result = trickshot.Shoot(target);

        result.HitCount.Should().Be(112);
    }
}