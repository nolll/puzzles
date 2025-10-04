namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202006;

public class Aoc202006Tests
{
    [Fact]
    public void SumOfAtLeastYesAnswerCounts()
    {
        var reader = new DeclarationFormReader(Input);
        var sum = reader.SumOfAtLeastOneYes;

        sum.Should().Be(11);
    }

    [Fact]
    public void SumOfAllAnswerCounts()
    {
        var reader = new DeclarationFormReader(Input);
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