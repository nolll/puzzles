using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201814;

public class Aoc201814Tests
{
    [TestCase(5, "0124515891")]
    [TestCase(9, "5158916779")]
    [TestCase(18, "9251071085")]
    [TestCase(2018, "5941429882")]
    public void FindRecipeScores(int input, string expected)
    {
        var generator = new RecipeGenerator();
        var scores = generator.ScoresAfter(input);

        scores.Should().Be(expected);
    }

    [TestCase("01245", 5)]
    [TestCase("51589", 9)]
    [TestCase("92510", 18)]
    [TestCase("59414", 2018)]
    public void FindRecipeScores(string input, int expected)
    {
        var generator = new RecipeGenerator();
        var count = generator.RecipeCountBefore(input);

        count.Should().Be(expected);
    }
}