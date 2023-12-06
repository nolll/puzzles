using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201515;

public class Aoc201515Tests
{
    [Test]
    public void FindsHighestCookieScore()
    {
        const string input = """
Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
""";

        var baker = new CookieBakery(input.Trim());
        var score = baker.HighestScore;

        score.Should().Be(62842880);
    }

    [Test]
    public void FindsHighestCookieScoreWith500Calories()
    {
        const string input = """
Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
""";

        var baker = new CookieBakery(input.Trim());
        var score = baker.HighestScoreWith500Calories;

        score.Should().Be(57600000);
    }
}