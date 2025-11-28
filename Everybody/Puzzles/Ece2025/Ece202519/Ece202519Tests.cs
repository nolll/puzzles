namespace Pzl.Everybody.Puzzles.Ece2025.Ece202519;

public class Ece202519Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             7,7,2
                             12,0,4
                             15,5,3
                             24,1,6
                             28,5,5
                             40,8,2
                             """;

        Sut.Part1(input).Answer.Should().Be("24");
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             7,7,2
                             7,1,3
                             12,0,4
                             15,5,3
                             24,1,6
                             28,5,5
                             40,3,3
                             40,8,2
                             """;

        Sut.Part2(input).Answer.Should().Be("22");
    }

    [Fact]
    public void Part3()
    {
        const string input = """
                             7,7,2
                             7,1,3
                             12,0,4
                             15,5,3
                             24,1,6
                             28,5,5
                             40,3,3
                             40,8,2
                             """;

        Sut.Part3(input).Answer.Should().Be("22");
    }

    private static Ece202519 Sut => new();
}