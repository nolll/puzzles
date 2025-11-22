namespace Pzl.Everybody.Puzzles.Ece2025.Ece202514;

public class Ece202514Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             .#.##.
                             ##..#.
                             ..##.#
                             .#.##.
                             .###..
                             ###.##
                             """;

        Sut.Part1(input).Answer.Should().Be("200");
    }

    [Fact]
    public void Part3()
    {
        const string input = """
                             #......#
                             ..#..#..
                             .##..##.
                             ...##...
                             ...##...
                             .##..##.
                             ..#..#..
                             #......#
                             """;

        Sut.Part3(input).Answer.Should().Be("278388552");
    }

    private static Ece202514 Sut => new();
}