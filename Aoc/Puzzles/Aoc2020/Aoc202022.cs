using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Crab Combat")]
public class Aoc202022 : AocPuzzle
{
    [Puzzle("1ab0c908e993eb4c76057e745326c12d")]
    public long Part1(string input)
    {
        var groups = Parse(input);
        var players = CreatePlayers(groups);

        while (players.All(o => o.Count > 0))
        {
            var card1 = players[0].First();
            var card2 = players[1].First();

            var roundWinner = card1 > card2
                ? 0
                : 1;

            var cards = new List<int> { card1, card2 }.OrderByDescending(o => o).ToList();

            players[0].RemoveAt(0);
            players[1].RemoveAt(0);

            players[roundWinner].AddRange(cards);
        }

        var winningPlayer = players.First(o => o.Any());
        return CalculateScore(winningPlayer);
    }

    [Puzzle("f1c4ea36b08889edb687d00e9dacffcf")]
    public long Part2(string input)
    {
        var groups = Parse(input);
        var players = CreatePlayers(groups);
        var winningPlayer = PlayRecursive(players);
        return CalculateScore(players[winningPlayer]);
    }

    private static int PlayRecursive(List<List<int>> players)
    {
        var cache = new HashSet<string>();

        while (players.All(o => o.Count > 0))
        {
            var cacheKey = CreateCacheKey(players);

            if (!cache.Add(cacheKey))
                return 0;

            var card1 = players[0].First();
            var card2 = players[1].First();

            var shouldPlayRecursive = card1 <= players[0].Count - 1 && card2 <= players[1].Count - 1;
            var roundWinner = card1 > card2
                ? 0
                : 1;

            if (shouldPlayRecursive)
            {
                var recursivePlayers = new List<List<int>>
                {
                    players[0].Skip(1).Take(card1).ToList(),
                    players[1].Skip(1).Take(card2).ToList()
                };
                roundWinner = PlayRecursive(recursivePlayers);
            }

            var roundLoser = roundWinner == 0 ? 1 : 0;
            var winningCard = players[roundWinner][0];
            var losingCard = players[roundLoser][0];

            players[0].RemoveAt(0);
            players[1].RemoveAt(0);

            var cards = new List<int>
            {
                winningCard,
                losingCard
            };

            players[roundWinner].AddRange(cards);
        }

        for (var i = 0; i < players.Count; i++)
        {
            if (players[i].Any())
                return i;
        }

        return 0;
    }

    private static List<List<int>> CreatePlayers(List<string[]> groups) => [.. groups.Select(g => g.Skip(1).Select(int.Parse).ToList())];
    private static List<string[]> Parse(string input) => [.. input.Split(LineBreaks.Double).Select(o => o.Split(LineBreaks.Single))];

    private static string CreateCacheKey(List<List<int>> players)
    {
        var cards0 = string.Join(',', players[0]);
        var cards1 = string.Join(',', players[1]);
        return $"{cards0}-{cards1}";
    }

    private static long CalculateScore(List<int> winningPlayer)
    {
        winningPlayer.Reverse();
        long score = 0;
        var i = 1;
        foreach (var card in winningPlayer)
        {
            score += i * card;
            i++;
        }

        return score;
    }
}