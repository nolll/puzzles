using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Day15;

public class Year2015Day15Tests
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

        Assert.That(score, Is.EqualTo(62842880));
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

        Assert.That(score, Is.EqualTo(57600000));
    }
}