namespace Pzl.Euler.Puzzles.Euler031;

public class Euler031Tests
{
    [Fact]
    public void TwoDenominations()
    {
        var puzzle = new Euler031();
        var result = puzzle.Run(new List<int> { 1, 2 }, 2);

        result.Should().Be(2);
    }

    [Fact]
    public void ThreeDenominations()
    {
        var puzzle = new Euler031();
        var result = puzzle.Run(new List<int> { 1, 2, 5 }, 5);

        result.Should().Be(4);
    }

    [Fact]
    public void FourDenominations()
    {
        var puzzle = new Euler031();
        var result = puzzle.Run(new List<int> { 1, 2, 5, 10 }, 10);

        result.Should().Be(11);
    }
}