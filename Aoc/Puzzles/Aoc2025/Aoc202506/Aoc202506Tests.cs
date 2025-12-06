namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202506;

public class Aoc202506Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             123 328  51 64 
                              45 64  387 23 
                               6 98  215 314
                             *   +   *   +  
                             """;

        Sut.Part1(input).Answer.Should().Be("4277556");
    }

    [Fact]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Answer.Should().Be("0");
    }

    private static Aoc202506 Sut => new();
}