using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aquaq.Puzzles.Aquaq19;

public class Aquaq19Tests
{
    [Test]
    public void GameOfLife() => Aquaq19.RunGame("350 6 2 2 2 3", false)
        .Should().Be(8);

    [Test]
    public void GameOfLifeLarge() => Aquaq19.RunGame("8487 101 0 0", false)
        .Should().Be(224);
}