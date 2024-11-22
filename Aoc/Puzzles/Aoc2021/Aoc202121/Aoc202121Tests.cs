using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202121;

public class Aoc202121Tests
{
    [Test]
    public void Part1()
    {
        var game = new DiracDiceGame();
        var result = game.Play(4, 8);

        result.Result.Should().Be(739785);
    }
    
    [Test]
    public void Part2()
    {
        var game = new RealDiracDiceGame();
        var result = game.Play(4, 8);

        result.Should().Be(444356092776315);
    }
}
