namespace Pzl.Euler.Puzzles.Euler019;

public class Euler019Tests
{

    [Fact]
    public void Test()
    {
        var startDate = DateTime.Parse("2020-01-01");
        var endDate = DateTime.Parse("2020-12-31");

        var puzzle = new Euler019();
        var result = puzzle.Run(startDate, endDate);

        result.Should().Be(2);
    }
}