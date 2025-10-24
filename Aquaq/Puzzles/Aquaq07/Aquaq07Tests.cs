using AwesomeAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq07;

public class Aquaq07Tests
{
    [Fact]
    public void ExpectedWinrate()
    {
        var result = Aquaq07.ExpectedWinrate(1400, 1200);

        result.Should().Be(0.75974692664795784d);
    }

    [Fact]
    public void WinningRatingChange()
    {
        var expectedWinrate = Aquaq07.ExpectedWinrate(1400, 1200);
        var result = Aquaq07.RatingChange(expectedWinrate);

        result.Should().Be(4.8050614670408436d);
    }

    [Fact]
    public void LosingRatingChange()
    {
        var expectedWinrate = Aquaq07.ExpectedWinrate(1200, 1400);
        var result = Aquaq07.RatingChange(expectedWinrate);

        result.Should().Be(15.19493853295916d);
    }
}