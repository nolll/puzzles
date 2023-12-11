using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq13;

[Name("O RLE?")]
public class Aquaq13(string input) : AquaqPuzzle(input)
{
    protected override PuzzleResult Run()
    {
        var lines = StringReader.ReadLines(Input);
        var sum = lines.Sum(FindMaxRepeats);

        return new PuzzleResult(sum, "86680930d41e9acceb49215121585640");
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