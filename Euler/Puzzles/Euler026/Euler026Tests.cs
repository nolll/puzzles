namespace Pzl.Euler.Puzzles.Euler026;

public class Euler026Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler026();
        var result = puzzle.Solve(10);

        result.Should().Be(7);
    }
}