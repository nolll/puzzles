using Pzl.FlipFlop.Puzzles.FlipFlop2025;

namespace Tests.FlipFlop.FlipFlop2025;

public class FlipFlop202502Tests : PuzzleTest<FlipFlop202502>
{
    private const string Input = "^^^v^^^^vvvvvvv";

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(6);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(15);

    [Fact]
    public void Part3() => Sut.Part3(Input).Should().Be(4);

}