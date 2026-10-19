using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202112Tests : PuzzleTest<Aoc202112>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(10);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(36);

    private const string Input = """
                                 start-A
                                 start-b
                                 A-c
                                 A-b
                                 b-d
                                 A-end
                                 b-end
                                 """;
}