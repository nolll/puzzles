using Pzl.Common;
using Pzl.Tools.Chars;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202506;

[Name("Lotus Scramble")]
public class Codyssi202506 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var count = input.Select(Chars.IsAlphabetic).Select(isLetter => isLetter ? 1 : 0).Sum();
        return new PuzzleResult(count, "fdcf01fc54fbd900671723d23cced1f2");
    }

    public PuzzleResult Part2(string input)
    {
        var score = input.Sum(GetScore);
        return new PuzzleResult(score, "88ffc67653d041684f125e23ab4c8764");
    }

    public PuzzleResult Part3(string input)
    {
        var scores = input.Select(GetScore).ToArray();
        for (var i = 0; i < input.ToCharArray().Length; i++)
        {
            if(scores[i] > 0)
                continue;

            scores[i] = CalculateScoreFromPrevious(scores[i - 1]);
        }
        return new PuzzleResult(scores.Sum(), "31fa3178274e6a4bb86259563a07d7d0");
    }

    private static int CalculateScoreFromPrevious(int prevScore)
    {
        const int limit = 52;
        var mod = prevScore * 2 - 5;
        
        while (mod < 1)
            mod += limit;
        
        while (mod > limit)
            mod -= limit;
        
        return mod;
    }

    private static int GetScore(char c)
    {
        if (Chars.IsAlphabeticLower(c))
            return c - 'a' + 1;
        if (Chars.IsAlphabeticUpper(c))
            return c - 'A' + 27;
        return 0;
    }
}