namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202505;

public class FlipFlop202505Tests
{
    private const string Input = "ABccksiPiBAksP";

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("38");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("Bc");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("-6");

    private static FlipFlop202505 Sut => new();
}