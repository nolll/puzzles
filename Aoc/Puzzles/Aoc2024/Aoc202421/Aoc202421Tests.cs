namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202421;

public class Aoc202421Tests
{
    [Fact]
    public void Part1()
    {
        const string input = "029A";

        Sut.Solve(input, 2).Should().Be(68);
    }
    
    [Fact]
    public void Part1_All()
    {
        const string input = """
                             029A
                             980A
                             179A
                             456A
                             379A
                             """;

        Sut.Part1(input).Answer.Should().Be("126384");
    }

    private static Aoc202421 Sut => new();
}