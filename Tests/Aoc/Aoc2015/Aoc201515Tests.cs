using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201515Tests : PuzzleTest<Aoc201515>
{
    private const string Input = """
                                 Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
                                 Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3
                                 """;

    [Fact]
    public void FindsHighestCookieScore() => Sut.Part1(Input).Should().Be(62842880);

    [Fact]
    public void FindsHighestCookieScoreWith500Calories() => Sut.Part2(Input).Should().Be(57600000);
}