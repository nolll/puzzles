using Core.Puzzles.Year2020.Day05;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2020Tests
{
    public class Year2020Day05Tests
    {
        [TestCase("FBFBBFFRLR", 44, 5, 357)]
        [TestCase("BFFFBBFRRR", 70, 7, 567)]
        [TestCase("FFFBBBFRRR", 14, 7, 119)]
        [TestCase("BBFFBBFRLL", 102, 4, 820)]
        public void ParseBoardingCard(string boardingCard, int row, int col, int id)
        {
            var processor = BoardingCard.Parse(boardingCard);

            Assert.That(processor.Row, Is.EqualTo(row));
            Assert.That(processor.Column, Is.EqualTo(col));
            Assert.That(processor.Id, Is.EqualTo(id));
        }

        [Test]
        public void FindBoardingCardWithHighestId()
        {
            const string input = @"
FBFBBFFRLR
BFFFBBFRRR
FFFBBBFRRR
BBFFBBFRLL";

            var processor = new BoardingCardProcessor(input);

            Assert.That(processor.HighestId, Is.EqualTo(820));
        }
    }
}