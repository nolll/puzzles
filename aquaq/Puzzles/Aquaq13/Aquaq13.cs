using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq13;

public class Aquaq13 : AquaqPuzzle
{
    public override string Name => "O RLE?";

    protected override PuzzleResult Run()
    {
        var lines = InputFile.Split(Environment.NewLine);
        var sum = 0;
        foreach (var line in lines)
        {
            sum += FindMaxRepeats(line);
        }

        return new PuzzleResult(sum);
    }

    public static int FindMaxRepeats(string s)
    {
        var tokens = FindTokens(s);
        var maxCount = 0;
        var maxToken = "";

        foreach (var token in tokens)
        {
            var length = s.Split(token).Length;
            if (length > maxCount)
            {
                maxCount = length;
                maxToken = token;
            }
        }

        var otherTokens = s.Replace(maxToken, "|").Split('|').Where(o => o != "");
        foreach (var otherToken in otherTokens)
        {
            s = s.Replace(otherToken, "");
        }

        return s.Split(maxToken).Length - 1;
    }

    private static IEnumerable<string> FindTokens(string s)
    {
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = i; j < s.Length - i; j++)
            {
                yield return s.Substring(i, j);
            }
        }
    }
}