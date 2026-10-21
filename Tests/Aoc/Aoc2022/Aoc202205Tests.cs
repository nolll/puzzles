using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202205Tests : PuzzleTest<Aoc202205>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be("CMZ");

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be("MCD");

    private const string Input = """
                                     [D]
                                 [N] [C]
                                 [Z] [M] [P]
                                  1   2   3

                                 move 1 from 2 to 1
                                 move 3 from 1 to 3
                                 move 2 from 2 to 1
                                 move 1 from 1 to 2
                                 """;
}