using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202117Tests : PuzzleTest<Aoc202117>
{
    [Fact]
    public void Part1()
    {
        var target = new Aoc202117.TrickshotTarget(20, 30, -10, -5);

        var trickshot = new Aoc202117.TrickShot();
        var result = trickshot.Shoot(target);

        result.MaxHeight.Should().Be(45);
    }

    [Fact]
    public void SingleMaxHeight()
    {
        var target = new Aoc202117.TrickshotTarget(20, 30, -10, -5);

        var trickshot = new Aoc202117.TrickShot();
        var result = trickshot.GetMaxHeight(target, 6, 9);

        result.Should().Be(45);
    }

    [Fact]
    public void SingleVelocityCount()
    {
        var target = new Aoc202117.TrickshotTarget(20, 30, -10, -5);

        var trickshot = new Aoc202117.TrickShot();
        var result = trickshot.Shoot(target);

        result.HitCount.Should().Be(112);
    }
}