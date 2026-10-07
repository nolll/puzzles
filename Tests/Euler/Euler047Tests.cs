using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler047Tests : PuzzleTest<Euler047>
{
    [Fact]
    public void Find2() => Sut.FindSeries(2).Should().Be(14);
    
    [Fact]
    public void Find3() => Sut.FindSeries(3).Should().Be(644);

}