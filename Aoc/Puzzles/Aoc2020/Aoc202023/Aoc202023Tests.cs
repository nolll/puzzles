namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202023;

public class Aoc202023Tests
{
    private const int Input = 389_125_467;

    [Fact]
    public void ResultAfter10MovesIsCorrect()
    {
        var game = new CrabCupsGame(Input);
        game.Play(10);

        game.ResultString.Should().Be("92658374");
    }

    [Fact]
    public void ExtendedResultAfter10MillionMovesIsCorrect()
    {
        var game = new CrabCupsGame(Input, true);
        game.Play(10_000_000);

        game.ResultProduct.Should().Be(149_245_887_792);
    }
}