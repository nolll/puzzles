using Puzzles.common.Puzzles;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2023.Aoc202301;

public class Aoc202301 : AocPuzzle
{
    public override string Name => "Trebuchet?!";

    private static readonly List<string> Words = new()
    {
        "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
    };

    protected override PuzzleResult RunPart1()
    {
        var values = FindCalibrationNumberPart1(InputFile);
        var result = values.Sum();

        return new PuzzleResult(result, "93e7c44a86bd9d03f7156e6fc3ed61c8");
    }

    protected override PuzzleResult RunPart2()
    {
        var values = FindCalibrationNumberPart2(InputFile);
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

    public static string ReplaceStringDigits(string s)
    {
        for (var i = 0; i < Words.Count; i++)
        {
            var word = Words[i];
            var digit = i + 1;
            s = s.Replace(word, $"{word}{digit}{word}");
        }

        return s;
    }

    private static int FindFirstDigit(string input) => int.Parse(input.ToCharArray().First(IsDigit).ToString());
    private static int FindLastDigit(string input) => int.Parse(input.ToCharArray().Last(IsDigit).ToString());
    private static bool IsDigit(char c) => int.TryParse(c.ToString(), out _);
}