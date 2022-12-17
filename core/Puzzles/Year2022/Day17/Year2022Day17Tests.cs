using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day17;

public class Year2022Day17Tests
{
    [Test]
    public void Part1()
    {
        var tetris = new Tetris();
        var result = tetris.Run(Input, 2022);

        Assert.That(result, Is.EqualTo(3068));
    }

    [Test]
    public void Part2()
    {
        var tetris = new Tetris();
        var result = tetris.Run(Input, 1_000_000_000_000);

        Assert.That(result, Is.EqualTo(1_514_285_714_288));
    }

    private const string Input = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";
}