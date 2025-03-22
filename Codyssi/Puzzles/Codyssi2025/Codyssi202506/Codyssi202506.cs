using Pzl.Common;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202506;

[Name("Lotus Scramble")]
public class Codyssi202506 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var count = input.Select(IsAlphabetical).Select(isLetter => isLetter ? 1 : 0).Sum();
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
        var mod = prevScore * 2 - 5;
        
        while (mod < 1)
            mod += 52;
        
        while (mod > 52)
            mod -= 52;
        
        return mod;
    }

    private static bool IsAlphabetical(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

    private static int GetScore(char c) => c switch
    {
        >= 'a' and <= 'z' => c - 'a' + 1,
        >= 'A' and <= 'Z' => c - 'A' + 27,
        _ => 0
    };
}