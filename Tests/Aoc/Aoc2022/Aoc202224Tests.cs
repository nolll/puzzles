using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202224Tests : PuzzleTest<Aoc202224>
{
    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(18);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(54);

    private const string Input = """
                                 #.######
                                 #>>.<^<#
                                 #.<..<<#
                                 #>v.><>#
                                 #<^v^^>#
                                 ######.#
                                 """;
}