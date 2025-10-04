namespace Pzl.Euler.Puzzles.Euler007;

public class Euler007Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler007();
        var result = puzzle.Run(6);

        result.Should().Be(13);
    }
}