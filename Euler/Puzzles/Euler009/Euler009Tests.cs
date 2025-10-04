namespace Pzl.Euler.Puzzles.Euler009;

public class Euler009Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler009();
        var result = puzzle.Run(12);

        result.Should().Be(60);
    }
}