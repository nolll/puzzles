using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq07Tests : PuzzleTest<Aquaq07>
{
    [Fact]
    public void ExpectedWinrate() => Aquaq07.ExpectedWinrate(1400, 1200).Should().Be(0.75974692664795784d);

    [Fact]
    public void WinningRatingChange() => Aquaq07.RatingChange(Aquaq07.ExpectedWinrate(1400, 1200)).Should().Be(4.8050614670408436d);

    [Fact]
    public void LosingRatingChange() => Aquaq07.RatingChange(Aquaq07.ExpectedWinrate(1200, 1400)).Should().Be(15.19493853295916d);
}