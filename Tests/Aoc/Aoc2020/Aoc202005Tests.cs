using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202005Tests : PuzzleTest<Aoc202005>
{
    [Theory]
    [InlineData("FBFBBFFRLR", 44, 5, 357)]
    [InlineData("BFFFBBFRRR", 70, 7, 567)]
    [InlineData("FFFBBBFRRR", 14, 7, 119)]
    [InlineData("BBFFBBFRLL", 102, 4, 820)]
    public void ParseBoardingCard(string boardingCard, int row, int col, int id)
    {
        var processor = Aoc202005.BoardingCard.Parse(boardingCard);

        processor.Row.Should().Be(row);
        processor.Column.Should().Be(col);
        processor.Id.Should().Be(id);
    }

    [Fact]
    public void FindBoardingCardWithHighestId()
    {
        const string input = """
                             FBFBBFFRLR
                             BFFFBBFRRR
                             FFFBBBFRRR
                             BBFFBBFRLL
                             """;

        var processor = new Aoc202005.BoardingCardProcessor(input);

        processor.HighestId.Should().Be(820);
    }
}