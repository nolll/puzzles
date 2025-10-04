namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

public class Aoc202202Tests
{
    [Fact]
    public void Part1()
    {
        var game = new RockPaperScissors();
        var result = game.Part1(Input);

        result.Should().Be(15);
    }

    [Fact]
    public void Part2()
    {
        var game = new RockPaperScissors();
        var result = game.Part2(Input);

        result.Should().Be(12);
    }

    private const string Input = """
                                 A Y
                                 B X
                                 C Z
                                 """;
}