namespace Pzl.Euler.Puzzles.Euler028;

public class Euler028Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler028();
        var result = puzzle.Run(5);

        result.Should().Be(101);
    }
}