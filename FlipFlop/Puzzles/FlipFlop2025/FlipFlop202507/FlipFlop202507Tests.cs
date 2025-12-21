namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202507;

public class FlipFlop202507Tests
{
    private const string Input = """
                                 2 2
                                 3 3
                                 2 3
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Answer.Should().Be("11");

    [Fact]
    public void Part2() => Sut.Part2(Input).Answer.Should().Be("108");

    [Fact]
    public void Part3() => Sut.Part3(Input).Answer.Should().Be("98");

    [Theory]
    [InlineData(2, 2, 2)]
    [InlineData(3, 3, 6)]
    [InlineData(2, 3, 3)]
    public void CountWays2d(int width, int height, int expected) => Sut.CountWays(width, height).Should().Be(expected);
    
    [Fact]
    public void CountWays() => Sut.CountWays(3, 3, 3, 3).Should().Be(2520);

    [Theory]
    [InlineData(2, 2, 2, 6)]
    [InlineData(3, 3, 3, 90)]
    [InlineData(2, 3, 2, 12)]
    public void CountWays3d(int width, int height, int depth, int expected) => Sut.CountWays(width, height, depth).Should().Be(expected);

    private static FlipFlop202507 Sut => new();
}