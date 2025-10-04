namespace Pzl.Euler.Puzzles.Euler004;

public class Euler004Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler004();
        var result = puzzle.Run(10, 99);

        result.Should().Be(9009);
    }
}