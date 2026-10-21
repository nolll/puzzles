using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202212Tests : PuzzleTest<Aoc202212>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(31);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(29);

    private const string Input = """
                                 Sabqponm
                                 abcryxxl
                                 accszExk
                                 acctuvwj
                                 abdefghi
                                 """;
}