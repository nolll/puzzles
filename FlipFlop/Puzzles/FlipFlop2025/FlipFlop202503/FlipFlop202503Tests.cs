namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202503;

public class FlipFlop202503Tests
{
    private const string Input = """
                                 10,20,30
                                 20,10,30
                                 30,20,10
                                 10,50,10
                                 50,10,50
                                 10,20,30
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("10,20,30");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("0");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("37");

    private static FlipFlop202503 Sut => new();
}