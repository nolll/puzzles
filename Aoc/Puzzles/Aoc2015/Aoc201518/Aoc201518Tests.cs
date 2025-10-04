namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201518;

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

    [Fact]
    public void LightCountAfterOneStep()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(1);

        gif.LightCount.Should().Be(11);
    }

    [Fact]
    public void LightCountAfterTwoSteps()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(2);

        gif.LightCount.Should().Be(8);
    }

    [Fact]
    public void LightCountAfterThreeSteps()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(3);

        gif.LightCount.Should().Be(4);
    }

    [Fact]
    public void LightCountAfterFourSteps()
    {
        var gif = new AnimatedGif(Input);
        gif.RunAnimation(4);

        gif.LightCount.Should().Be(4);
    }

    [Fact]
    public void LightCountAfterOneStepWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(1);

        gif.LightCount.Should().Be(18);
    }

    [Fact]
    public void LightCountAfterTwoStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(2);

        gif.LightCount.Should().Be(18);
    }

    [Fact]
    public void LightCountAfterThreeStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(3);

        gif.LightCount.Should().Be(18);
    }

    [Fact]
    public void LightCountAfterFourStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(4);

        gif.LightCount.Should().Be(14);
    }

    [Fact]
    public void LightCountAfterFiveStepsWithLitCorners()
    {
        var gif = new AnimatedGif(Input, true);
        gif.RunAnimation(5);

        gif.LightCount.Should().Be(17);
    }
}