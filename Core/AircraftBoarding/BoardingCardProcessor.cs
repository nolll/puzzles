using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.AircraftBoarding
{
    public class BoardingCardProcessor
    {
        private readonly IEnumerable<BoardingCard> _boardingCards;

        public int HighestId => _boardingCards.Max(o => o.Id);

        public BoardingCardProcessor(string input)
        {
            _boardingCards = PuzzleInputReader.ReadLines(input).Select(BoardingCard.Parse);
        }

        public BoardingCard FindMySeat()
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
}