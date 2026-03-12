namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202404;

public class Aoc202404Tests
{
    private const string Input = """
                                 MMMSXXMASM
                                 MSAMXMSMSA
                                 AMXSXMAAMM
                                 MSAMASMSMX
                                 XMASAMXAMM
                                 XXAMMXXAMA
                                 SMSMSASXSS
                                 SAXAMASAAA
                                 MAMMMXMMMM
                                 MXMXAXMASX
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(18);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(9);

    private static Aoc202404 Sut => new();
}