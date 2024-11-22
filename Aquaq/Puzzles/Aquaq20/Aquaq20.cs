using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq20;

[Name("Blackjack")]
public class Aquaq20(string input) : AquaqPuzzle
{
    protected override PuzzleResult Run()
    {
        return new PuzzleResult(PlayBlackjack(input), "112a5875109cbca20cbe3dd1d02fe9fd");
    }

    public static int PlayBlackjack(string input)
    {
        var deck = input.Split(' ').ToArray();
        var winCount = 0;

        var currentGame = new List<int>();
        foreach (var card in deck)
        {
            var value = GetCardValue(card);
            currentGame.Add(value);
            var aceCount = currentGame.Count(o => o == 11);
            var maxSum = currentGame.Sum();
            var sums = Enumerable.Range(0, aceCount + 1).Select(o => maxSum - 10 * o).ToList();
            if (sums.Any(o => o == 21))
            {
                winCount++;
                currentGame.Clear();
                continue;
            }

            if (sums.Any(o => o < 21))
                continue;

            currentGame.Clear();
        }

        return winCount;
    }

    private static int GetCardValue(string card)
    {
        return card switch
        {
            "A" => 11,
            "K" or "Q" or "J" or "10" => 10,
            _ => int.Parse(card)
        };
    }
}