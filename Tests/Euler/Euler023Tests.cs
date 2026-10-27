using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler023Tests : PuzzleTest<Euler023>
{
    [Fact]
    public void Test() => Sut.FindAbundantNumbers(13).Count().Should().Be(1);
}