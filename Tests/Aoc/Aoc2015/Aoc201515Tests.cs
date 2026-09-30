using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201515Tests : PuzzleTest<Aoc201515>
{
    private const string Input = """
                                 Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
                                 Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
                                 """;

    [Fact]
    public void FindsHighestCookieScore()
    {
        var baker = new Aoc201515.CookieBakery(Input);
        var score = baker.HighestScore;

        score.Should().Be(62842880);
    }

    [Fact]
    public void FindsHighestCookieScoreWith500Calories()
    {
        var baker = new Aoc201515.CookieBakery(Input);
        var score = baker.HighestScoreWith500Calories;

        score.Should().Be(57600000);
    }
}