using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

public class Year2022Day02Tests
{
    [Test]
    public void Part1()
    {
        var game = new RockPaperScissors();
        var result = game.Part1(Input);

        result.Should().Be(15);
    }

    [Test]
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