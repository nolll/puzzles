namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202404;

public class Aoc202404Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
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
        
        Sut.Part1(input).Answer.Should().Be("18");
    }
    
    [Fact]
    public void Part2()
    {
        const string input = """
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
        
        Sut.Part2(input).Answer.Should().Be("9");
    }

    private Aoc202404 Sut => new();
}