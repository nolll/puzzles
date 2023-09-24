using System;
using System.Collections.Generic;
using System.Linq;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2020.Aoc202022;

public class CardCombatGame
{
    private readonly IList<IList<string>> _groups;

    public CardCombatGame(string input)
    {
        _groups = PuzzleInputReader.ReadLineGroups(input);
    }

    public List<List<int>> CreatePlayers()
    {
        var players = new List<List<int>>();
        foreach (var g in _groups)
        {
            players.Add(g.Skip(1).Select(int.Parse).ToList());
        }

        return players;
    }

    public long Play()
    {
        var players = CreatePlayers();
        var p0 = players[0];
        var p1 = players[1];

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

    public long PlayRecursive()
    {
        var players = CreatePlayers();

        try
        {
            var winningPlayer = PlayRecursive(players, 0);
            return CalculateScore(players[winningPlayer]);
        }
        catch (RecursiveException )
        {
            return CalculateScore(players[0]);
        }
    }

    private int PlayRecursive(List<List<int>> players, int level)
    {
        var cache = new HashSet<string>();

        while (players.All(o => o.Count > 0))
        {
            var cacheKey = CreateCacheKey(players);

            if (cache.Contains(cacheKey))
                return 0;

            cache.Add(cacheKey);

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
                roundWinner = PlayRecursive(recursivePlayers, level + 1);
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

    private class RecursiveException : Exception
    {
    }

    private string CreateCacheKey(List<List<int>> players)
    {
        //var cards0 = string.Join(',', players[0]);
        //return $"{cards0}";
        var cards0 = string.Join(',', players[0]);
        var cards1 = string.Join(',', players[1]);
        return $"{cards0}-{cards1}";
    }

    private long CalculateScore(List<int> winningPlayer)
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