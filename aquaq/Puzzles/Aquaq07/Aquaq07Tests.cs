using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq07;

public class Aquaq07Tests
{
    [Test]
    public void ExpectedWinrate()
    {
        var result = Aquaq07.ExpectedWinrate(1400, 1200);

        Assert.That(result, Is.EqualTo(0.75974692664795784d));
    }

    [Test]
    public void WinningRatingChange()
    {
        var expectedWinrate = Aquaq07.ExpectedWinrate(1400, 1200);
        var result = Aquaq07.RatingChange(expectedWinrate);

        Assert.That(result, Is.EqualTo(4.8050614670408436d));
    }

    [Test]
    public void LosingRatingChange()
    {
        var expectedWinrate = Aquaq07.ExpectedWinrate(1200, 1400);
        var result = Aquaq07.RatingChange(expectedWinrate);

        Assert.That(result, Is.EqualTo(15.19493853295916d));
    }
}