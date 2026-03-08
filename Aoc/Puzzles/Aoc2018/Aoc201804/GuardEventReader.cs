using System.Text.RegularExpressions;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201804;

public static partial class GuardEventReader
{
    public static List<GuardEvent> Read(string str) => 
        str.Split(LineBreaks.Single).Select(ConvertToGuardEvent).OrderBy(o => o.Timestamp).ToList();

    private static GuardEvent ConvertToGuardEvent(string str)
    {
        var regex = GuardEventRegex();
        var match = regex.Match(str);
        var timestamp = GetTimeValue(match.Groups[1]);
        var action = match.Groups[2].Value;
        return new GuardEvent(timestamp, action);
    }

    private static DateTime GetTimeValue(Group matchGroup) => DateTime.Parse(matchGroup.Value);
    
    [GeneratedRegex(@"^\[(.+)\] (.+)$")]
    private static partial Regex GuardEventRegex();
}