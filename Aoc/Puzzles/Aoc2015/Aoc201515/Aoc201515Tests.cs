using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201515;

public class Aoc201515Tests
{
    private const string Input = """
                                 Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
                                 Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
                                 """;

    [Test]
    public void FindsHighestCookieScore()
    {
        var baker = new CookieBakery(Input);
        var score = baker.HighestScore;

        score.Should().Be(62842880);
    }

    [Test]
    public void FindsHighestCookieScoreWith500Calories()
    {
        var baker = new CookieBakery(Input);
        var score = baker.HighestScoreWith500Calories;

        score.Should().Be(57600000);
    }
}