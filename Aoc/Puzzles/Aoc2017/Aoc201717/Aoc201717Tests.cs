using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201717;

public class Aoc201717Tests
{
    [Test]
    public void NextValueIsCorrect()
    {
        const int input = 3;
        var runner = new SpinlockRunnerPart1(input);
        runner.Run(2017);

        runner.NextValue.Should().Be(638);
        runner.SecondValue.Should().Be(1226);
    }

    [Test]
    public void SecondValueIsCorrect()
    {
        const int input = 3;
        var runner = new SpinlockRunnerPart2(input);
        runner.Run(2017);

        runner.SecondValue.Should().Be(1226);
    }
}