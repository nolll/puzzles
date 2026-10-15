using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202005Tests : PuzzleTest<Aoc202005>
{
    [Theory]
    [InlineData("FBFBBFFRLR", 44, 5, 357)]
    [InlineData("BFFFBBFRRR", 70, 7, 567)]
    [InlineData("FFFBBBFRRR", 14, 7, 119)]
    [InlineData("BBFFBBFRLL", 102, 4, 820)]
    public void ParseBoardingCard(string input, int row, int col, int id)
    {
        var boardingCard = Aoc202005.BoardingCard.Parse(input);

        boardingCard.Row.Should().Be(row);
        boardingCard.Column.Should().Be(col);
        boardingCard.Id.Should().Be(id);
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

        Sut.Part1(input).Should().Be(820);
    }
}