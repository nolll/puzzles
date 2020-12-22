using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.CardCombat
{
    public class CardCombatGame
    {
        private readonly List<List<int>> _players;

        public long WinningPlayerScore;

        public CardCombatGame(string input)
        {
            var groups = PuzzleInputReader.ReadLineGroups(input);
            _players = new List<List<int>>();
            foreach (var g in groups)
            {
                _players.Add(g.Skip(1).Select(int.Parse).ToList());
            }
        }

        public int Play()
        {
            var p0 = _players[0];
            var p1 = _players[1];

            while (_players.All(o => o.Count > 0))
            {
                var card1 = _players[0].First();
                var card2 = _players[1].First();

                var roundWinner = card1 > card2
                    ? 0
                    : 1;

                var cards = new List<int> {card1, card2}.OrderByDescending(o => o).ToList();

                _players[0].RemoveAt(0);
                _players[1].RemoveAt(0);

                _players[roundWinner].AddRange(cards);
            }

            var winningPlayer = _players.First(o => o.Any());
            winningPlayer.Reverse();
            var score = 0;
            var i = 1;
            foreach (var card in winningPlayer)
            {
                score += i * card;
                i++;
            }

            return score;
        }
    }
}