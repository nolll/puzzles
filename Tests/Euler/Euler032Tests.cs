using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler032Tests : PuzzleTest<Euler032>
{
    [Fact]
    public void IsPandigital() => Sut.IsPandigital(39, 186).Should().BeTrue();

    [Fact]
    public void IsNotPandigital() => Sut.IsPandigital(1, 2).Should().BeFalse();
}