namespace Pzl.Euler.Puzzles.Euler003;

public class Euler003Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler003();
        var result = puzzle.Run(13195);

        result.Should().Be(29);
    }
}