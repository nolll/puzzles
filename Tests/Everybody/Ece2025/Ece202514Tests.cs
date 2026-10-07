using Pzl.Everybody.Puzzles.Ece2025;

namespace Tests.Everybody.Ece2025;

public class Ece202514Tests : PuzzleTest<Ece202514>
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

        Sut.Part1(input).Should().Be(200);
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

        Sut.Part3(input).Should().Be(278388552);
    }

}