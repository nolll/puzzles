namespace Pzl.Euler.Puzzles.Euler017;

public class Euler017Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler017();
        var result = puzzle.Run(5);

        result.Should().Be(19);
    }
}