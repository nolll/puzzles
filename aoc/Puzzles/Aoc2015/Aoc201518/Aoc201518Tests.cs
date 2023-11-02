using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201518;

public class Aoc201518Tests
{
    private const string Input = """
.#.#.#
...##.
#....#
..#...
#.#..#
####..
""";

    [Test]
    public void LightCountAfterOneStep()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(1);

        gif.LightCount.Should().Be(11);
    }

    [Test]
    public void LightCountAfterTwoSteps()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(2);

        gif.LightCount.Should().Be(8);
    }

    [Test]
    public void LightCountAfterThreeSteps()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(3);

        gif.LightCount.Should().Be(4);
    }

    [Test]
    public void LightCountAfterFourSteps()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(4);

        gif.LightCount.Should().Be(4);
    }

    [Test]
    public void LightCountAfterOneStepWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(1);

        gif.LightCount.Should().Be(18);
    }

    [Test]
    public void LightCountAfterTwoStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(2);

        gif.LightCount.Should().Be(18);
    }

    [Test]
    public void LightCountAfterThreeStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(3);

        gif.LightCount.Should().Be(18);
    }

    [Test]
    public void LightCountAfterFourStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(4);

        gif.LightCount.Should().Be(14);
    }

    [Test]
    public void LightCountAfterFiveStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(5);

        gif.LightCount.Should().Be(17);
    }
}