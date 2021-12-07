using Core.Puzzles.Year2020.Day23;
using NUnit.Framework;

namespace Tests
{
    public class Year2020Day23Tests
    {
        private const int Input = 389_125_467;

        [Test]
        public void ResultAfter10MovesIsCorrect()
        {
            var game = new CrabCupsGame(Input);
            game.Play(10);

            Assert.That(game.ResultString, Is.EqualTo("92658374"));
        }

        [Test]
        public void ExtendedResultAfter10MillionMovesIsCorrect()
        {
            var game = new CrabCupsGame(Input, true);
            game.Play(10_000_000);

            Assert.That(game.ResultProduct, Is.EqualTo(149_245_887_792));
        }
    }
}