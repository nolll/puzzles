using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Marble Mania")]
public class Aoc201809 : AocPuzzle
{
    [Puzzle("dab82e0990c953b88e3617b646bc089a")]
    public long Part1(string input) => Solve(input);

    [Puzzle("efdea08bc5ee63512ba8659f1d13e63c")]
    public long Part2(string input) => Solve(input, 100);

    private long Solve(string input, int multiplier = 1)
    {
        var (playerCount, lastMarbleValue) = Parse(input, multiplier);
        return Solve(playerCount, lastMarbleValue);
    }

    public long Solve(int playerCount, int lastMarbleValue)
    {
        var playerScores = new long[playerCount];
        var circle = new LinkedList<int>();
        var currentMarble = circle.AddFirst(0);
        var currentPlayer = 0;
        var marbleValue = 0;
            
        while (marbleValue < lastMarbleValue)
        {
            marbleValue++;
            if (marbleValue % 23 == 0)
            {
                var distance = 7;
                while (distance > 0)
                {
                    currentMarble = currentMarble.PreviousOrLast();
                    distance--;
                }
                playerScores[currentPlayer] += marbleValue + currentMarble.Value;
                var removeThis = currentMarble;
                currentMarble = currentMarble.NextOrFirst();
                circle.Remove(removeThis);
            }
            else
            {
                currentMarble = currentMarble.NextOrFirst();
                currentMarble = circle.AddAfter(currentMarble, marbleValue);
            }

            currentPlayer++;
            if (currentPlayer >= playerScores.Length)
                currentPlayer = 0;
        }

        return playerScores.Max();
    }

    private static (int, int) Parse(string input, int multiplier = 1)
    {
        var (playerCount, lastMarbleValue) = Numbers.IntsFromString(input);
        return (playerCount, lastMarbleValue * multiplier);
    }
}