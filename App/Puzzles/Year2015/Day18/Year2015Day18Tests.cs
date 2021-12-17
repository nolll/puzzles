using NUnit.Framework;

namespace App.Puzzles.Year2015.Day18;

public class Year2015Day18Tests
{
    private const string Input = @"
.#.#.#
...##.
#....#
..#...
#.#..#
####..";

    [Test]
    public void LightCountAfterOneStep()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(1);

        Assert.That(gif.LightCount, Is.EqualTo(11));
    }

    [Test]
    public void LightCountAfterTwoSteps()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(2);

        Assert.That(gif.LightCount, Is.EqualTo(8));
    }

    [Test]
    public void LightCountAfterThreeSteps()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(3);

        Assert.That(gif.LightCount, Is.EqualTo(4));
    }

    [Test]
    public void LightCountAfterFourSteps()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(4);

        Assert.That(gif.LightCount, Is.EqualTo(4));
    }

    [Test]
    public void LightCountAfterOneStepWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(1);

        Assert.That(gif.LightCount, Is.EqualTo(18));
    }

    [Test]
    public void LightCountAfterTwoStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(2);

        Assert.That(gif.LightCount, Is.EqualTo(18));
    }

    [Test]
    public void LightCountAfterThreeStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(3);

        Assert.That(gif.LightCount, Is.EqualTo(18));
    }

    [Test]
    public void LightCountAfterFourStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(4);

        Assert.That(gif.LightCount, Is.EqualTo(14));
    }

    [Test]
    public void LightCountAfterFiveStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(5);

        Assert.That(gif.LightCount, Is.EqualTo(17));
    }
}