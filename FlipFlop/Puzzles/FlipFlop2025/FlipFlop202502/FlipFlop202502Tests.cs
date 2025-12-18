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
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 5)]
    [InlineData(6, 8)]
    public void Fibonacci(int input, int expected) => FlipFlop202502.Fibonacci(input).Should().Be(expected);

    private static FlipFlop202502 Sut => new();
}