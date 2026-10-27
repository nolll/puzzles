using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler031Tests : PuzzleTest<Euler031>
{
    [Fact]
    public void TwoDenominations() => Sut.Solve(new List<int> { 1, 2 }, 2).Should().Be(2);

    [Fact]
    public void ThreeDenominations() => Sut.Solve(new List<int> { 1, 2, 5 }, 5).Should().Be(4);

    [Fact]
    public void FourDenominations() => Sut.Solve(new List<int> { 1, 2, 5, 10 }, 10).Should().Be(11);
}