namespace Pzl.Euler.Puzzles.Euler047;

public class Euler047Tests
{
    [Fact]
    public void Find2() => Sut.FindSeries(2).Should().Be(14);
    
    [Fact]
    public void Find3() => Sut.FindSeries(3).Should().Be(644);

    private static Euler047 Sut => new();
}