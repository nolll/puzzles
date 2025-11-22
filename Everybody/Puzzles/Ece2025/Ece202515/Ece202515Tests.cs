namespace Pzl.Everybody.Puzzles.Ece2025.Ece202515;

public class Ece202515Tests
{
    [Fact]
    public void Part1()
    {
        const string input = "L6,L3,L6,R3,L6,L3,L3,R6,L6,R6,L6,L6,R3,L3,L3,R3,R3,L6,L6,L3";

        Sut.Part1(input).Answer.Should().Be("16");
    }

    [Fact]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Ece202515 Sut => new();
}