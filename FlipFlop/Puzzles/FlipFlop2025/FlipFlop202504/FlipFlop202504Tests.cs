namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202504;

public class FlipFlop202504Tests
{
    private const string Input = """
                                 3,3
                                 9,9
                                 6,6
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("24");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("12");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("9");

    private static FlipFlop202504 Sut => new();
}