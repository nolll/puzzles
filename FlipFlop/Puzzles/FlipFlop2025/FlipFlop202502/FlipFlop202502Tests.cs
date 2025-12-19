namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202502;

public class FlipFlop202502Tests
{
    private const string Input = "^^^v^^^^vvvvvvv";

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("6");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("15");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("4");

    private static FlipFlop202502 Sut => new();
}