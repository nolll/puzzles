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
    public void Part2And3()
    {
        const string input = "L6,L3,L6,R3,L6,L3,L3,R6,L6,R6,L6,L6,R3,L3,L3,R3,R3,L6,L6,L3";

        Sut.Part2And3(input).Should().Be(16);
    }

    private static Ece202515 Sut => new();
}