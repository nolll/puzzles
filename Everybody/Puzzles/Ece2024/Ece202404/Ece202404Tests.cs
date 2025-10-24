namespace Pzl.Everybody.Puzzles.Ece2024.Ece202404;

public class Ece202404Tests
{
    [Fact]
    public void Part1And2()
    {
        const string input = """
                             3
                             4
                             7
                             8
                             """;

        Sut.RunPart1(input).Answer.Should().Be("10");
    }
    
    [Fact]
    public void Part3()
    {
        const string input = """
                             2
                             4
                             5
                             6
                             8
                             """;

        Sut.RunPart3(input).Answer.Should().Be("8");
    }

    private static Ece202404 Sut => new();
}