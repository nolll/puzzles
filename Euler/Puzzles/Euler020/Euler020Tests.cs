namespace Pzl.Euler.Puzzles.Euler020;

public class Euler020Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler020();
        var result = puzzle.Run(10);

        result.Should().Be(27);
    }
}