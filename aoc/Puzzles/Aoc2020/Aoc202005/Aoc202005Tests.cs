using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202005;

public class Aoc202005Tests
{
    [TestCase("FBFBBFFRLR", 44, 5, 357)]
    [TestCase("BFFFBBFRRR", 70, 7, 567)]
    [TestCase("FFFBBBFRRR", 14, 7, 119)]
    [TestCase("BBFFBBFRLL", 102, 4, 820)]
    public void ParseBoardingCard(string boardingCard, int row, int col, int id)
    {
        var processor = BoardingCard.Parse(boardingCard);

        processor.Row.Should().Be(row);
        processor.Column.Should().Be(col);
        processor.Id.Should().Be(id);
    }

    [Test]
    public void FindBoardingCardWithHighestId()
    {
        const string input = """
FBFBBFFRLR
BFFFBBFRRR
FFFBBBFRRR
BBFFBBFRLL
""";

        var processor = new BoardingCardProcessor(input.Trim());

        processor.HighestId.Should().Be(820);
    }
}