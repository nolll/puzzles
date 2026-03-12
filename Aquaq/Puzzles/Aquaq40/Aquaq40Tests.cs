namespace Pzl.Aquaq.Puzzles.Aquaq40;

public class Aquaq40Tests
{
    private const string Input = "0 1 2 4 6 8 9 8 6 4 2 3 5 6 5 4 5 7 8 6 4 2 1 0";

    [Fact]
    public void FindPeaks() => Sut.FindPeakIndices(Input).Should().BeEquivalentTo([6, 13, 18]);

    [Fact]
    public void Sum() => Sut.Solve(Input).Should().Be(17);

    private static Aquaq40 Sut => new();
}