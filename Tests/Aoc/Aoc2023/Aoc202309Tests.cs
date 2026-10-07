using Pzl.Aoc.Puzzles.Aoc2023;

namespace Tests.Aoc.Aoc2023;

public class Aoc202309Tests : PuzzleTest<Aoc202309>
{
    private const string Input = """
                                 0 3 6 9 12 15
                                 1 3 6 10 15 21
                                 10 13 16 21 30 45
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(114);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(2);
}