using System.Text.RegularExpressions;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201803;

public static partial class ClaimListReader
{
    public static List<Claim> Read(string str) => str.Split(LineBreaks.Single).Select(ConvertToClaim).ToList();

    private static Claim ConvertToClaim(string str)
    {
        var regex = ClaimRegex();
        var match = regex.Match(str);
        var id = GetGroupValue(match.Groups[1]);
        var left = GetGroupValue(match.Groups[2]);
        var top = GetGroupValue(match.Groups[3]);
        var width = GetGroupValue(match.Groups[4]);
        var height = GetGroupValue(match.Groups[5]);
        return new Claim(id, left, top, width, height);
    }

    private static int GetGroupValue(Group matchGroup) => int.Parse(matchGroup.Value);

    [GeneratedRegex(@"^#(\d+) @ (\d+),(\d+): (\d+)x(\d+)$")]
    private static partial Regex ClaimRegex();
}