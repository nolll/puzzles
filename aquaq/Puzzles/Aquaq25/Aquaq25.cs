using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq25;

public class Aquaq25 : AquaqPuzzle
{
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

    public override string Name => "S'morse";

    protected override PuzzleResult Run()
    {
        var morse = ClicksToMorse(InputFile);
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

        var joinedResult = string.Join("", parsedResult);

        return new PuzzleResult(joinedResult, "paris");
    }

    public static string EncodeMorse(string input)
    {
        var words = input.Split(' ');
        var encodedWords = words.Select(EncodeMorseWord);
        return string.Join("   ", encodedWords);
    }

    private static string EncodeMorseWord(string input)
    {
        var encodedLetters = input.Select(o => CharToMorse[o]);
        return string.Join(" ", encodedLetters);
    }

    public static string DecodeMorse(string input)
    {
        var words = input.Split("   ");
        var decodedWords = words.Select(DecodeMorseWord);
        return string.Join(" ", decodedWords);
    }

    private static string DecodeMorseWord(string input)
    {
        var decodedLetters = input.Split(' ').Select(GetChar);
        return string.Join("", decodedLetters);
    }

    private static string GetChar(string morse)
    {
        if (MorseToChar.TryGetValue(morse, out var c))
            return c.ToString();
        return "";
    }

    public static string ClicksToMorse(string input)
    {
        var timeStamps = input.Split(Environment.NewLine)
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
}