using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Matchsticks")]
public class Aoc201508 : AocPuzzle
{
    [Puzzle("d1ca0ea6d28dd7f5e3d1551600b6b2c5")]
    public int Part1(string input)
    {
        var digitalList = new DigitalList(input);
        return digitalList.CodeMinusMemoryDiff;
    }

    [Puzzle("6ea0bb2ac1526f96307f0eeb8c4d25b7")]
    public int Part2(string input)
    {
        var digitalList = new DigitalList(input);
        return digitalList.EncodedMinusCodeDiff;
    }
    
    public class DigitalList
    {
        public int CodeMinusMemoryDiff { get; }
        public int EncodedMinusCodeDiff { get; }

        public DigitalList(string input)
        {
            var strings = input.Split(LineBreaks.Single);
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
}