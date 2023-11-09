using System.Text.RegularExpressions;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq01;

public class Aquaq01 : AquaqPuzzle
{
    private static readonly Regex HexRegex = new("[^0123456789abcdef]");
    public override string Name => "Rose by any other name";

    private const string Input = "do you think that maybe like, 1 in 10 people could be actually robots?";

    protected override PuzzleResult Run()
    {
        var result = GetHexString(Input);

        return new PuzzleResult(result, "8ee5a43d96dd610ecf1d39eccfddf218");
    }

    public static string GetHexString(string input)
    {
        var s = HexRegex.Replace(input.ToLower(), "0");

        var length = s.Length % 3 == 0 
            ? s.Length 
            : s.Length + 3 - s.Length % 3;
        
        s = s.PadRight(length, '0');
        var segmentLength = length / 3;
        var result = "";
        for (var i = 0; i < 3; i++)
        {
            result += s.Substring(segmentLength * i, 2);
        }

        return result;
    }
}