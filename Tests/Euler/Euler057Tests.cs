using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler057Tests : PuzzleTest<Euler057>
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

}