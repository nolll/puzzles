using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202006Tests : PuzzleTest<Aoc202006>
{
    [Fact]
    public void SumOfAtLeastYesAnswerCounts()
    {
        var reader = new Aoc202006.DeclarationFormReader(Input);
        var sum = reader.SumOfAtLeastOneYes;

        sum.Should().Be(11);
    }

    [Fact]
    public void SumOfAllAnswerCounts()
    {
        var reader = new Aoc202006.DeclarationFormReader(Input);
        var sum = reader.SumOfAllYes;

        sum.Should().Be(6);
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