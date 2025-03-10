using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201508;

public class DigitalList
{
    public int CodeMinusMemoryDiff { get; }
    public int EncodedMinusCodeDiff { get; }

    public DigitalList(string input)
    {
        var strings = StringReader.ReadLines(input);
        var codeCount = strings.Sum(CountCode);
        var memoryCount = strings.Sum(CountMemory);
        var encodedCount = strings.Sum(CountEncoded);
        CodeMinusMemoryDiff = codeCount - memoryCount;
        EncodedMinusCodeDiff = encodedCount - codeCount;
    }

    private static int CountCode(string s) => s.Length;

    private static int CountMemory(string s)
    {
        s = s.Remove(0, 1);
        s = s.Remove(s.Length - 1);

        while (s.Contains("\\"))
        {
            var backslashIndex = s.IndexOf("\\", StringComparison.InvariantCulture);
            var nextChar = s[backslashIndex + 1];
            var charactersToRemove = nextChar == '\"' || nextChar == '\\' ? 2 : 4;
            s = s.Remove(backslashIndex, charactersToRemove);
            s = s.Insert(backslashIndex, "-");
        }

        return s.Length;
    }

    private static int CountEncoded(string s)
    {
        s = s.Replace("\\", "\\\\");
        s = s.Replace("\"", "\\\"");
        return s.Length + 2;
    }
}