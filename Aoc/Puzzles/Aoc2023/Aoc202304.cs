using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023;

[Name("Scratchcards")]
public class Aoc202304 : AocPuzzle
{
    [Puzzle("5e02a1c34982f7f74973f0d751dd71da")]
    public int Part1(string input) => FlipThroughCards(input).Score;

    [Puzzle("283e4ad08baa8b2611e44898628a8363")]
    public int Part2(string input) => FlipThroughCards(input).CardCount;

    private static (int Score, int CardCount) FlipThroughCards(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var totalScore = 0;
        var cards = new Dictionary<int, int>();
        var index = 1;
        foreach (var line in lines)
        {
            var parts = line.Split(':', '|');
            var winning = Numbers.IntsFromString(parts[1]);
            var mine = Numbers.IntsFromString(parts[2]);

            var myCards = mine.ToHashSet();
            var score = 0;
            var matchCount = 0;
            foreach (var winningCard in winning)
            {
                if (!myCards.Contains(winningCard))
                    continue;
                
                matchCount++;
                score = score == 0 ? 1 : score * 2;
            }

            totalScore += score;
            cards.Add(index, matchCount);
            index++;
        }

        return (totalScore, cards.Keys.Sum(key => GetScore(cards, key)));
    }

    private static int GetScore(Dictionary<int, int> cards, int cardKey) => 
        Enumerable.Range(0, cards[cardKey]).Sum(i => GetScore(cards, cardKey + i + 1)) + 1;
}