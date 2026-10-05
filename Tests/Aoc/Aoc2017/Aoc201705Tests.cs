using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201705Tests : PuzzleTest<Aoc201705>
{
    private const string Input = """
                                 0
                                 3
                                 0
                                 1
                                 -3
                                 """;

    [Fact]
    public void Part1_StepsUntilExit() => Sut.Part1(Input).Should().Be(5);

    [Fact]
    public void Part2_StepsUntilExit() => Sut.Part2(Input).Should().Be(10);
}