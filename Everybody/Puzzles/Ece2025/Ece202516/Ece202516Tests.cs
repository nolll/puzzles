namespace Pzl.Everybody.Puzzles.Ece2025.Ece202516;

public class Ece202516Tests
{
    [Fact]
    public void Part1()
    {
        const string input = "1,2,3,5,9";

        Sut.Part1(input).Answer.Should().Be("193");
    }

    [Fact]
    public void Part2()
    {
        const string input = "1,2,2,2,2,3,1,2,3,3,1,3,1,2,3,2,1,4,1,3,2,2,1,3,2,2";

        Sut.Part2(input).Answer.Should().Be("270");
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Ece202516 Sut => new();
}