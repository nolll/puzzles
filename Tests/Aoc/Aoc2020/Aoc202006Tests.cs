using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202006Tests : PuzzleTest<Aoc202006>
{
    [Fact]
    public void SumOfAtLeastYesAnswerCounts()
    {
        Sut.Part1(Input).Should().Be(11);
    }

    [Fact]
    public void SumOfAllAnswerCounts()
    {
        Sut.Part2(Input).Should().Be(6);
    }

    private const string Input = """
                                 abc

                                 a
                                 b
                                 c

                                 ab
                                 ac

                                 a
                                 a
                                 a
                                 a

                                 b
                                 """;
}