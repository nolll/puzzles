using Pzl.Aoc.Puzzles.Aoc2022;

namespace Tests.Aoc.Aoc2022;

public class Aoc202220Tests : PuzzleTest<Aoc202220>
{
    [Fact]
    public void Part1()
    {
        var result = Aoc202220.Solve(Input, 1, 1);

        result.Should().Be(3);
    }

    [Fact]
    public void Part2()
    {
        var result = Aoc202220.Solve(Input, 811_589_153, 10);

        result.Should().Be(1623178306);
    }

    private const string Input = """
                                 1
                                 2
                                 -3
                                 3
                                 -2
                                 0
                                 4
                                 """;
}