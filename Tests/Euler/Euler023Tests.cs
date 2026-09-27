namespace Tests.Euler;

public class Euler023Tests
{
    [Fact]
    public void Test()
    {
        var result = Pzl.Euler.Puzzles.Euler023.Euler023.FindAbundantNumbers(13);

        result.Count().Should().Be(1);
    }
}