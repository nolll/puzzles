namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202410;

public class Aoc202410Tests
{
    private const string Input = """
                                 89010123
                                 78121874
                                 87430965
                                 96549874
                                 45678903
                                 32019012
                                 01329801
                                 10456732
                                 """;

    [Fact]
    public void Part1()
    {
        Sut.Part1(Input).Answer.Should().Be("36");
    }

    [Fact]
    public void Part2()
    {
        Sut.Part2(Input).Answer.Should().Be("81");
    }

    private static Aoc202410 Sut => new();
}