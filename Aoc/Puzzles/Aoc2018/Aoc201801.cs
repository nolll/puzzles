using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Chronal Calibration")]
public class Aoc201801 : AocPuzzle
{
    [Puzzle("6161dde7fc767cd20548aa2a500b6af4")]
    public int Part1(string input) => new FrequencyPuzzle(input).ResultingFrequency;

    [Puzzle("fba794668dca2e1a271d8ead203f36d2")]
    public int Part2(string input) => new FrequencyRepeatPuzzle(input).FirstRepeatedFrequency ?? 0;
    
    public static class FrequencyChangeListReader
    {
        public static List<int> Read(string str) => IntListReader.Read(RemovePlusSigns(str)).ToList();
        private static string RemovePlusSigns(string input) => input.Replace("+", "");
    }
    
    public class FrequencyPuzzle
    {
        public int ResultingFrequency { get; }

        public FrequencyPuzzle(string input)
        {
            var changes = FrequencyChangeListReader.Read(input);
            ResultingFrequency = changes.Sum();
        }
    }
    
    public class FrequencyRepeatPuzzle
    {
        public int? FirstRepeatedFrequency { get; }

        public FrequencyRepeatPuzzle(string input)
        {
            var changes = FrequencyChangeListReader.Read(input);
            FirstRepeatedFrequency = GetFirstRepeat(changes);
        }

        private static int? GetFirstRepeat(List<int> changes)
        {
            var sum = 0;
            var uniqueResults = new List<int> { sum };
            int? firstRepeat = null;
            while (firstRepeat == null)
            {
                foreach (var change in changes)
                {
                    sum += change;
                    if (uniqueResults.Contains(sum))
                    {
                        firstRepeat = sum;
                        break;
                    }
                    uniqueResults.Add(sum);
                }
            }
            return firstRepeat;
        }
    }
    
    public static class IntListReader
    {
        public static List<int> Read(string str) => str.Split(LineBreaks.Single).Select(ConvertToInt).ToList();
        private static int ConvertToInt(string str) => int.Parse(str);
    }
}