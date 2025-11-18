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
    public void Part3_1()
    {
        const string input = """
                             SSS
                             ..#
                             #.#
                             #D.
                             """;

        Sut.Part3(input).Answer.Should().Be("15");
    }
    
    [Fact]
    public void Part3_2()
    {
        const string input = """
                             SSS
                             ..#
                             ..#
                             .##
                             .D#
                             """;

        Sut.Part3(input).Answer.Should().Be("8");
    }
    
    [Fact]
    public void Part3_3()
    {
        const string input = """
                             ..S..
                             .....
                             ..#..
                             .....
                             ..D..
                             """;

        Sut.Part3(input).Answer.Should().Be("44");
    }
    
    [Fact]
    public void Part3_4()
    {
        const string input = """
                             .SS.S
                             #...#
                             ...#.
                             ##..#
                             .####
                             ##D.#
                             """;

        Sut.Part3(input).Answer.Should().Be("4406");
    }
    
    [Fact]
    public void Part3_5()
    {
        const string input = """
                             SSS.S
                             .....
                             #.#.#
                             .#.#.
                             #.D.#
                             """;

        Sut.Part3(input).Answer.Should().Be("13033988838");
    }

    private static Ece202510 Sut => new();
}