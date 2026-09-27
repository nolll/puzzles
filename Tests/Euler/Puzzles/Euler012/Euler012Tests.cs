namespace Tests.Euler.Puzzles.Euler012;

public class Euler012Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler012.Euler012();
        var result = puzzle.Solve(5);

        result.Should().Be(28);
    }
}