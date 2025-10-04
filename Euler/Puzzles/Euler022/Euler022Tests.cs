namespace Pzl.Euler.Puzzles.Euler022;

public class Euler022Tests
{
    [Fact]
    public void Test()
    {
        var puzzle = new Euler022();
        var result = puzzle.GetNameScore("COLIN");

        result.Should().Be(49714);
    }
}