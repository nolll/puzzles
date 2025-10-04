namespace Pzl.Euler.Puzzles.Euler030;

public class Euler030Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler030();
        var result = puzzle.Run(4);

        result.Should().Be(19316);
    }
}
