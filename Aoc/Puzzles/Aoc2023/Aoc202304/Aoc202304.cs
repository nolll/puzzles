using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202304;

[Name("Scratchcards")]
public class Aoc202304 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = FlipThroughCards(input);

        return new PuzzleResult(result.Score, "5e02a1c34982f7f74973f0d751dd71da");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = FlipThroughCards(input);

        return new PuzzleResult(result.CardCount, "283e4ad08baa8b2611e44898628a8363");
    }

    public static (int Score, int CardCount) FlipThroughCards(string input)
    {
        var lines = StringReader.ReadLines(input);
        var totalScore = 0;
        var cards = new Dictionary<int, int>();
        var index = 1;
        foreach (var line in lines)
        {
            var parts = line.Replace("  ", " ").Split(new[] { ':', '|' });
            var winning = ParseCards(parts[1]);
            var mine = ParseCards(parts[2]);

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

            totalScore += score;
            cards.Add(index, matchCount);
            index++;
        }

        var cardCount = cards.Keys.Sum(key => GetScore(cards, key));

        return (totalScore, cardCount);
    }

    private static IEnumerable<int> ParseCards(string s)
        => s.Trim().Split(' ').Select(o => int.Parse(o.Trim()));

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