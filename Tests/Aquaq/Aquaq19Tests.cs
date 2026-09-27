namespace Tests.Aquaq;

public class Aquaq19Tests
{
    [Fact]
    public void GameOfLife() => Pzl.Aquaq.Puzzles.Aquaq19.Aquaq19.RunGame("350 6 2 2 2 3", false)
        .Should().Be(8);

    [Fact]
    public void GameOfLifeLarge() => Pzl.Aquaq.Puzzles.Aquaq19.Aquaq19.RunGame("8487 101 0 0", false)
        .Should().Be(224);
}