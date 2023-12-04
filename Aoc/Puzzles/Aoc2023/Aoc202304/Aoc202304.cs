﻿using Puzzles.Common.Puzzles;
using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2023.Aoc202304;

public class Aoc202304 : AocPuzzle
{
    public override string Name => "Scratchcards";

    protected override PuzzleResult RunPart1()
    {
        var result = GetScore(InputFile);

        return new PuzzleResult(result.Part1, "5e02a1c34982f7f74973f0d751dd71da");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = GetScore(InputFile);

        return new PuzzleResult(result.Part2, "283e4ad08baa8b2611e44898628a8363");
    }

    public static (int Part1, int Part2) GetScore(string input)
    {
        var lines = StringReader.ReadLines(input);
        var p1 = 0;
        var cards = new Dictionary<int, int>();
        var index = 1;
        foreach (var line in lines)
        {
            var parts = line.Replace("  ", " ").Split(new[] { ':', '|' });
            var mine = parts[1].Trim().Split(' ').Select(o => int.Parse(o.Trim()));
            var winning = parts[2].Trim().Split(' ').Select(o => int.Parse(o.Trim()));

            var myCards = mine.ToHashSet();
            var score = 0;
            var matchCount = 0;
            foreach (var winningCard in winning)
            {
                if (myCards.Contains(winningCard))
                {
                    matchCount++;
                    if (score == 0)
                        score = 1;
                    else
                        score *= 2;
                }
            }

            p1 += score;
            cards.Add(index, matchCount);
            index++;
        }

        var p2 = 0;
        foreach (var key in cards.Keys)
        {
            p2 += GetScore(cards, key);
        }

        return (p1, p2);
    }

    private static int GetScore(Dictionary<int, int> cards, int cardKey)
    {
        var wins = cards[cardKey];
        var cardCount = 1;
        for (var i = 0; i < wins; i++)
        {
            var nextKey = cardKey + i + 1;
            cardCount += GetScore(cards, nextKey);
        }

        return cardCount;
    }
}