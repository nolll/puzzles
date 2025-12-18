namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202501;

public class FlipFlop202501Tests
{
    private const string Input = """
                                 banana
                                 banenanana
                                 bananana
                                 bananananana
                                 bananananana
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("24");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("16");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("19");

    private static FlipFlop202501 Sut => new();
}