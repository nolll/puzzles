namespace Tests.Euler.Puzzles.Euler057;

public class Euler057Tests
{
    [Theory]
    [InlineData(1, false)]
    [InlineData(2, false)]
    [InlineData(3, false)]
    [InlineData(4, false)]
    [InlineData(5, false)]
    [InlineData(6, false)]
    [InlineData(7, false)]
    [InlineData(8, true)]
    public void Solve(int levels, bool expected) => Sut.HasLongerNumerator(levels).Should().Be(expected);

    private static Pzl.Euler.Puzzles.Euler057.Euler057 Sut => new();
}