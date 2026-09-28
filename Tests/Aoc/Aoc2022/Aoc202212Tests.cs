using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202212Tests
{
    [Fact]
    public void Part1()
    {
        var hillClimbing = new Aoc202212.HillClimbing();
        var result = hillClimbing.Part1(Input);

        result.Should().Be(31);
    }

    [Fact]
    public void Part2()
    {
        var hillClimbing = new Aoc202212.HillClimbing();
        var result = hillClimbing.Part2(Input);

        result.Should().Be(29);
    }

    private const string Input = """
                                 Sabqponm
                                 abcryxxl
                                 accszExk
                                 acctuvwj
                                 abdefghi
                                 """;
}