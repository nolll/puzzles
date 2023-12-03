using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202022;

public class Aoc202022Tests
{
    [Test]
    public void NormalGame_WinningScoreIs306()
    {
        var game = new CardCombatGame(Input);
        var score = game.Play();

        score.Should().Be(306);
    }

    [Test]
    public void InfiniteGame_Ends()
    {
        const string input = """
Player 1:
43
19

Player 2:
2
29
14
""";

        var game = new CardCombatGame(input);
        game.PlayRecursive();
        const bool ended = true;

        ended.Should().BeTrue();
    }

    [Test]
    public void RecursiveGame_WinningScoreIs306()
    {
        var game = new CardCombatGame(Input);
        var score = game.PlayRecursive();

        score.Should().Be(291);
    }

    private const string Input = """
Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10
""";
}