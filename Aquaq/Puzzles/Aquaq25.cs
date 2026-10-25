using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("S'morse")]
public class Aquaq25 : AquaqPuzzle
{
    [Puzzle("f00ce886bf2534f2f98813743c48cb6e")]
    public string Solve(string input)
    {
        var morse = ClicksToMorse(input);
        var result = DecodeMorse(morse);
        var resultParts = result.Split(' ');

        var parsedResult = new[]
        {
            resultParts[7],
            resultParts[32],
            resultParts[25],
            resultParts[36],
            ((char)(resultParts[49].First() + 1)).ToString()
        };

        return string.Concat(parsedResult);
    }

    public string EncodeMorse(string input) => string.Join("   ", input.Split(' ').Select(EncodeMorseWord));
    private static string EncodeMorseWord(string input) => string.Join(" ", input.Select(o => CharToMorse[o]));
    public string DecodeMorse(string input) => string.Join(" ", input.Split("   ").Select(DecodeMorseWord));
    private static string DecodeMorseWord(string input) => string.Concat(input.Split(' ').Select(GetChar));
    private static string GetChar(string morse) => MorseToChar.TryGetValue(morse, out var c) ? c.ToString() : "";

    public string ClicksToMorse(string input)
    {
        var timeStamps = input.Split(LineBreaks.Single)
            .Select(o => o.Trim())
            .Where(o => o.Length > 0)
            .Select(o => DateTime.Parse($"2020-02-02 {o}"))
            .ToArray();

        return TimeStampsToMorse(timeStamps);
    }

    private static string TimeStampsToMorse(IReadOnlyList<DateTime> timeStamps)
    {
        var timeSpans = new List<TimeSpan>();
        for (var i = 1; i < timeStamps.Count; i++)
        {
            timeSpans.Add(timeStamps[i] - timeStamps[i - 1]);
        }

        return TimeSpansToMorse(timeSpans);
    }

    private static string TimeSpansToMorse(IReadOnlyList<TimeSpan> timeSpans)
    {
        var interval = (int)timeSpans.Min().TotalMilliseconds;
        var morse = "";
        for (var i = 0; i < timeSpans.Count; i++)
        {
            var millis = (int)timeSpans[i].TotalMilliseconds;
            if (i % 2 == 0)
                morse += MillisToOnMorse(interval, millis);
            else
                morse += MillisToOffMorse(interval, millis);
        }

        return morse;
    }

    private static string MillisToOnMorse(int interval, int millis) => millis == interval ? "." : "-";

    private static string MillisToOffMorse(int interval, int millis)
    {
        if (millis == interval)
            return "";
        if (millis == interval * 3)
            return " ";
        return "   ";
    }
    
    private static readonly Dictionary<char, string> CharToMorse = new()
    {
        { 'a', ".-" },
        { 'b', "-..." },
        { 'c', "-.-." },
        { 'd', "-.." },
        { 'e', "." },
        { 'f', "..-." },
        { 'g', "--." },
        { 'h', "...." },
        { 'i', ".." },
        { 'j', ".---" },
        { 'k', "-.-" },
        { 'l', ".-.." },
        { 'm', "--" },
        { 'n', "-." },
        { 'o', "---" },
        { 'p', ".--." },
        { 'q', "--.-" },
        { 'r', ".-." },
        { 's', "..." },
        { 't', "-" },
        { 'u', "..-" },
        { 'v', "...-" },
        { 'w', ".--" },
        { 'x', "-..-" },
        { 'y', "-.--" },
        { 'z', "--.." }
    };

    private static readonly Dictionary<string, char> MorseToChar = CharToMorse.ToDictionary(k => k.Value, v => v.Key);
}