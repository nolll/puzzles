namespace Pzl.Everybody.Puzzles.Ece2025.Ece202510;

public class Ece202510Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             ...SSS.......
                             .S......S.SS.
                             ..S....S...S.
                             ..........SS.
                             ..SSSS...S...
                             .....SS..S..S
                             SS....D.S....
                             S.S..S..S....
                             ....S.......S
                             .SSS..SS.....
                             .........S...
                             .......S....S
                             SS.....S..S..
                             """;

        Sut.Part1(input, 3).Should().Be(27);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             ...SSS##.....
                             .S#.##..S#SS.
                             ..S.##.S#..S.
                             .#..#S##..SS.
                             ..SSSS.#.S.#.
                             .##..SS.#S.#S
                             SS##.#D.S.#..
                             S.S..S..S###.
                             .##.S#.#....S
                             .SSS.#SS..##.
                             ..#.##...S##.
                             .#...#.S#...S
                             SS...#.S.#S..
                             """;

        Sut.Part2(input, 3).Should().Be(27);
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Answer.Should().Be("0");
    }

    private static Ece202510 Sut => new();
}