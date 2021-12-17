using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace App.Puzzles.Year2021.Day17;

public class Year2021Day17Tests
{
    [Test]
    public void Part1()
    {
        var target = new TrickshotTarget(20, 30, -10, -5);

        var trickshot = new TrickShot();
        var result = trickshot.Shoot(target);

        Assert.That(result.MaxHeight, Is.EqualTo(45));
    }

    [Test]
    public void SingleMaxHeight()
    {
        var target = new TrickshotTarget(20, 30, -10, -5);

        var trickshot = new TrickShot();
        var result = trickshot.GetMaxHeight(target, 6, 9);

        Assert.That(result, Is.EqualTo(45));
    }

    [Test]
    public void SingleVelocityCount()
    {
        var target = new TrickshotTarget(20, 30, -10, -5);

        var trickshot = new TrickShot();
        var result = trickshot.Shoot(target);

        Assert.That(result.HitCount, Is.EqualTo(112));
    }

    private const string Input = @"
";
}