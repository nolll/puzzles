using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201717Tests
{
    [Fact]
    public void NextValueIsCorrect()
    {
        const int input = 3;
        var runner = new Aoc201717.SpinlockRunnerPart1(input);
        runner.Run(2017);

        runner.NextValue.Should().Be(638);
        runner.SecondValue.Should().Be(1226);
    }

    [Fact]
    public void SecondValueIsCorrect()
    {
        const int input = 3;
        var runner = new Aoc201717.SpinlockRunnerPart2(input);
        runner.Run(2017);

        runner.SecondValue.Should().Be(1226);
    }
}