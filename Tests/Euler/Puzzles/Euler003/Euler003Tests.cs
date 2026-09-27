namespace Tests.Euler.Puzzles.Euler003;

public class Euler003Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Pzl.Euler.Puzzles.Euler003.Euler003();
        var result = puzzle.Solve(13195);

        result.Should().Be(29);
    }
}