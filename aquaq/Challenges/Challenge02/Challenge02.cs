using System.Text.RegularExpressions;
using AquaQ.Platform;

namespace AquaQ.Challenges.Challenge02;

public class Challenge02 : Challenge
{
    private static readonly Regex HexRegex = new("[^0123456789abcdef]");
    public override string Name => "Rose by any other name";

    private const string Input = "do you think that maybe like, 1 in 10 people could be actually robots?";

    public override ChallengeResult Run()
    {
        var result = GetHexString(Input);

        return new ChallengeResult(result, "d0000d");
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