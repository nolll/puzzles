using System.Collections.Generic;
using System.Linq;

namespace Core.MarbleMania
{
    public class MarbleGame
    {
        public int WinnerScore { get; }

        public MarbleGame(int playerCount, int lastMarbleValue)
        {
            var playerScores = new int[playerCount];
            var circle = new List<int> {0};
            var currentMarble = 0;
            var currentPlayer = 0;
            var marbleValue = 0;
            while (marbleValue < lastMarbleValue)
            {
                marbleValue++;
                if (marbleValue % 23 == 0)
                {
                    currentMarble -= 7;
                    while (currentMarble < 0)
                        currentMarble += circle.Count;
                    var value = circle[currentMarble];
                    playerScores[currentPlayer] += marbleValue + value;
                    circle.RemoveAt(currentMarble);
                    while (currentMarble > circle.Count - 1)
                        currentMarble = 0;
                }
                else
                {
                    currentMarble += 2;
                    while (currentMarble > circle.Count - 1)
                        currentMarble -= circle.Count;
                    circle.Insert(currentMarble, marbleValue);
                }

                currentPlayer++;
                if (currentPlayer >= playerScores.Length)
                    currentPlayer = 0;
            }

            WinnerScore = playerScores.Max();
        }
    }
}