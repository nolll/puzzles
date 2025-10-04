namespace Pzl.Euler.Puzzles.Euler005;

public class Euler005Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler005();
        var result = puzzle.Run(10);

        result.Should().Be(2520);
    }
}