namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202401;

public class Aoc202401Tests
{
    private const string Input = """
                                 3   4
                                 4   3
                                 2   5
                                 1   3
                                 3   9
                                 3   3
                                 """;

    [Fact]
    public void Part1()
    {
        var result = Aoc202401.Part1(Input);
        result.Should().Be(11);
    }
    
    [Fact]
    public void Part2()
    {
        var result = Aoc202401.Part2(Input);
        result.Should().Be(31);
    }
}