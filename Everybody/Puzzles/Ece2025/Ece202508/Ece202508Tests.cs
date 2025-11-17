namespace Pzl.Everybody.Puzzles.Ece2025.Ece202508;

public class Ece202508Tests
{
    [Fact]
    public void Part1()
    {
        const string input = "1,5,2,6,8,4,1,7,3";

        Sut.Part1(input, 8).Should().Be(4);
    }

    [Fact]
    public void Part2()
    {
        const string input = "1,5,2,6,8,4,1,7,3,5,7,8,2";

        Sut.Part2(input).Answer.Should().Be("21");
    }

    [Fact]
    public void Part3()
    {
        const string input = "1,5,2,6,8,4,1,7,3,6";

        Sut.Part3(input, 8).Should().Be(7);
    }

    private static Ece202508 Sut => new();
}