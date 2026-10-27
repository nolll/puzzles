using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler019Tests : PuzzleTest<Euler019>
{
    [Fact]
    public void Test() => Sut.Solve(DateTime.Parse("2020-01-01"), DateTime.Parse("2020-12-31")).Should().Be(2);
}