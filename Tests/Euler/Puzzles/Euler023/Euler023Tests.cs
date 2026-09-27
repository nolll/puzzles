namespace Tests.Euler.Puzzles.Euler023;

public class Euler023Tests
{
    [Fact]
    public void Test()
    {
        var result = Pzl.Euler.Puzzles.Euler023.Euler023.FindAbundantNumbers(13);

        result.Count().Should().Be(1);
    }
}