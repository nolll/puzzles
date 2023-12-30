using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202301;

[Name("Trebuchet?!")]
public class Aoc202301(string input) : AocPuzzle
{
    private static readonly List<string> Words =
        ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    protected override PuzzleResult RunPart1()
    {
        var values = FindCalibrationNumberPart1(input);
        var result = values.Sum();

        return new PuzzleResult(result, "93e7c44a86bd9d03f7156e6fc3ed61c8");
    }

    protected override PuzzleResult RunPart2()
    {
        var values = FindCalibrationNumberPart2(input);
        var result = values.Sum();

        return new PuzzleResult(result, "1a8775b7ae93118b31708e052207307d");
    }

    public static List<int> FindCalibrationNumberPart1(string input)
        => StringReader.ReadLines(input)
            .Select(FindCalibrationNumber)
            .ToList();

    public static List<int> FindCalibrationNumberPart2(string input) 
        => StringReader.ReadLines(input)
            .Select(ReplaceStringDigits)
            .Select(FindCalibrationNumber)
            .ToList();

    private static int FindCalibrationNumber(string input)
    {
        var firstNumber = FindFirstDigit(input);
        var lastNumber = FindLastDigit(input);

        return int.Parse($"{firstNumber}{lastNumber}");
    }

    private static string ReplaceStringDigits(string s)
    {
        for (var i = 0; i < Words.Count; i++)
        {
            s = ReplaceWord(s, i + 1);
        }

        return s;
    }

    private static string ReplaceWord(string s, int digit)
    {
        var word = Words[digit - 1];
        return s.Replace(word, $"{word}{digit}{word}");
    }

    private static int FindFirstDigit(string input) => int.Parse(input.ToCharArray().First(IsDigit).ToString());
    private static int FindLastDigit(string input) => int.Parse(input.ToCharArray().Last(IsDigit).ToString());
    private static bool IsDigit(char c) => int.TryParse(c.ToString(), out _);
}