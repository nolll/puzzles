namespace Pzl.Everybody.Puzzles.Ece2025.Ece202503;

public class Ece202503Tests
{
    [Fact]
    public void Part1()
    {
        const string input = "10,5,1,10,3,8,5,2,2";

        Sut.Part1(input).Answer.Should().Be("29");
    }

    [Fact]
    public void Part2()
    {
        const string input = "4,51,13,64,57,51,82,57,16,88,89,48,32,49,49,2,84,65,49,43,9,13,2,3,75,72,63,48,61,14,40,77";

        Sut.Part2(input).Answer.Should().Be("781");
    }

    [Fact]
    public void Part3()
    {
        const string input = "4,51,13,64,57,51,82,57,16,88,89,48,32,49,49,2,84,65,49,43,9,13,2,3,75,72,63,48,61,14,40,77";

        Sut.Part3(input).Answer.Should().Be("3");
    }

    private static Ece202503 Sut => new();
}