using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Seven Segment Search")]
public class Aoc202108 : AocPuzzle
{
    [Puzzle("c5b4722b08a65550734c7c02f5531c8c")]
    public int Part1(string input) => input.Split(LineBreaks.Single).Select(GetEasyNumberCount).Sum();

    [Puzzle("95e5d901f00d91ced841dcf2c09f8fe9")]
    public int Part2(string input) => input.Split(LineBreaks.Single).Select(GetDecodedNumber).Sum();

    private static int GetEasyNumberCount(string line)
    {
        var (output, _) = ParseLine(line);

        var c = 0;
        foreach (var i in output)
        {
            var length = i.Length;
            if (length is 2 or 3 or 4 or 7)
                c++;
        }

        return c;
    }

    private int GetDecodedNumber(string line)
    {
        var (output, signals) = ParseLine(line);

        var s = new Dictionary<int, string?>
        {
            { 0, null },
            { 1, signals.Single(o => o.Length == 2) },
            { 2, null },
            { 3, null },
            { 4, signals.Single(o => o.Length == 4) },
            { 5, null },
            { 6, null },
            { 7, signals.Single(o => o.Length == 3) },
            { 8, signals.Single(o => o.Length == 7) },
            { 9, null },
        };

        var len6 = signals.Where(o => o.Length == 6).ToList();
        var len5 = signals.Where(o => o.Length == 5).ToList();

        s[3] = len5.Single(o => IsSubsetOf(s[1], o));
        len5.Remove(s[3]!);

        s[6] = len6.Single(o => !IsSubsetOf(s[1], o));
        len6.Remove(s[6]!);

        s[9] = len6.Single(o => IsSubsetOf(s[3], o));
        len6.Remove(s[9]!);

        s[0] = len6.Single();

        s[5] = len5.Single(o => IsSubsetOf(o, s[9]));
        len5.Remove(s[5]!);

        s[2] = len5.Single();

        var segmentToString = s.Keys.ToDictionary(key => s[key]!.ToString());

        return int.Parse(string.Concat(output.Select(o => segmentToString[o])));
    }

    private static (List<string> output, List<string> signals) ParseLine(string line)
    {
        var parts = line.Split(" | ");
        return (output: ParseStringList(parts[1]), signals: ParseStringList(parts[0]));
    }

    private static List<string> ParseStringList(string input) => [.. input.Split(' ').Select(o => string.Concat(o.OrderBy(c => c)))];

    public bool IsSubsetOf(string? sShort, string? sLong) =>
        sShort is not null &&
        sLong is not null &&
        sShort.All(sLong.Contains);
}