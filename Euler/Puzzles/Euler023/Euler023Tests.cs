namespace Pzl.Euler.Puzzles.Euler023;

public class Euler023Tests
{
    [Fact]
    public void Test()
    {
        var result = Euler023.FindAbundantNumbers(13);

        result.Count().Should().Be(1);
    }
}