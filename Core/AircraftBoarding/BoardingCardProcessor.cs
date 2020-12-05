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
            _boardingCards = PuzzleInputReader.Read(input).Select(o => new BoardingCard(o));
        }
    }
}