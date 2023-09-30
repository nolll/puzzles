using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq13;

public class Aquaq13 : AquaqPuzzle
{
    public override string Name => "O RLE?";

    protected override PuzzleResult Run()
    {
        var lines = InputFile.Split(Environment.NewLine);
        var sum = lines.Sum(FindMaxRepeats);

        return new PuzzleResult(sum, 1462);
    }

    public static int FindMaxRepeats(string s)
    {
        var tokens = FindTokens(s);
        var maxCount = 0;

        foreach (var token in tokens)
        {
            var count = 1;
            var repeated = token;
            while (true)
            {
                repeated += token;
                if (s.Contains(repeated))
                    count++;
                else
                    break;
            }

            maxCount = Math.Max(count, maxCount);
        }

        return maxCount;
    }

    private static IEnumerable<string> FindTokens(string s)
    {
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = 1; j < s.Length - i; j++)
            {
                yield return s.Substring(i, j);
            }
        }
    }
}