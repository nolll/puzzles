using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023;

[Name("Trebuchet?!")]
public class Aoc202301 : AocPuzzle
{
    private static readonly List<string> Words = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    [Puzzle("93e7c44a86bd9d03f7156e6fc3ed61c8")]
    public int Part1(string input) => input.Split(LineBreaks.Single)
        .Select(FindCalibrationNumber)
        .Sum();

    [Puzzle("1a8775b7ae93118b31708e052207307d")]
    public int Part2(string input) => input.Split(LineBreaks.Single)
        .Select(ReplaceStringDigits)
        .Select(FindCalibrationNumber)
        .Sum();
    
    private static int FindCalibrationNumber(string input) => int.Parse(string.Concat(FindFirstDigit(input), FindLastDigit(input)));

    private static string ReplaceStringDigits(string s) => 
        Enumerable.Range(0, Words.Count).Aggregate(s, (current, i) => ReplaceWord(current, i + 1));

    private static string ReplaceWord(string s, int digit)
    {
        var word = Words[digit - 1];
        return s.Replace(word, $"{word}{digit}{word}");
    }

    private static int FindFirstDigit(string input) => int.Parse(input.First(char.IsDigit).ToString());
    private static int FindLastDigit(string input) => int.Parse(input.Last(char.IsDigit).ToString());
}