using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202005;

public class BoardingCardProcessor(string input)
{
    private readonly IEnumerable<BoardingCard> _boardingCards = input.Split(LineBreaks.Single).Select(BoardingCard.Parse);

    public int HighestId => _boardingCards.Max(o => o.Id);

    public BoardingCard? FindMySeat()
    {
        var myRow = _boardingCards
            .GroupBy(o => o.Row)
            .Where(o => o.Count() == 7)
            .OrderBy(o => o.Key)
            .First()
            .ToList();

        for (var col = 0; col < 8; col++)
        {
            if (myRow.All(o => o.Column != col))
            {
                return new BoardingCard(myRow[0].Row, col);
            }
        }

        return null;
    }
}