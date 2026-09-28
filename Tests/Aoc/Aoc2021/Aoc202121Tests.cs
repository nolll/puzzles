using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202121Tests
{
    [Fact]
    public void Part1()
    {
        var game = new Aoc202121.DiracDiceGame();
        var result = game.Play(4, 8);

        result.Result.Should().Be(739785);
    }
    
    [Fact]
    public void Part2()
    {
        var game = new Aoc202121.RealDiracDiceGame();
        var result = game.Play(4, 8);

        result.Should().Be(444356092776315);
    }
}
