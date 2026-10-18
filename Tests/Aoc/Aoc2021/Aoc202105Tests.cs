using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202105Tests : PuzzleTest<Aoc202105>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(5);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(12);

    private const string Input = """
                                 0,9 -> 5,9
                                 8,0 -> 0,8
                                 9,4 -> 3,4
                                 2,2 -> 2,1
                                 7,0 -> 7,4
                                 6,4 -> 2,0
                                 0,9 -> 2,9
                                 3,4 -> 1,4
                                 0,0 -> 8,8
                                 5,5 -> 8,2
                                 """;
}