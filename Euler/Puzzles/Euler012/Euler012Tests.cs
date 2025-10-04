namespace Pzl.Euler.Puzzles.Euler012;

public class Euler012Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler012();
        var result = puzzle.Run(5);

        result.Should().Be(28);
    }
}