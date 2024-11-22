using System.Text.RegularExpressions;
using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq01;

[Name("Rose by any other name")]
public class Aquaq01(string input) : AquaqPuzzle
{
    private static readonly Regex HexRegex = new("[^0123456789abcdef]");

    protected override PuzzleResult Run()
    {
        var result = GetHexString(input);

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