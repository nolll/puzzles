using Puzzles.common.Puzzles;

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
        var values = FindCalibrationValuesPart1(InputFile);
        var result = values.Sum();

        return new PuzzleResult(result, "93e7c44a86bd9d03f7156e6fc3ed61c8");
    }

    protected override PuzzleResult RunPart2()
    {
        var values = FindCalibrationValuesPart2(InputFile);
        var result = values.Sum();

        return new PuzzleResult(result, "1a8775b7ae93118b31708e052207307d");
    }

    public static List<int> FindCalibrationValuesPart1(string input)
    {
        return input.Split(Environment.NewLine).Select(FindCalibrationNumberPart1).ToList();
    }

    public static List<int> FindCalibrationValuesPart2(string input)
    {
        return input.Split(Environment.NewLine).Select(FindCalibrationNumberPart2).ToList();
    }

    public static int FindCalibrationNumberPart1(string input)
    {
        var indices = FindCalibrationDigitIndices(input);

        var firstNumber = input[indices.firstIndex];
        var lastNumber = input[indices.lastIndex];

        return int.Parse($"{firstNumber}{lastNumber}");
    }

    public static int FindCalibrationNumberPart2(string input)
    {
        var preparedInput = ReplaceStringDigits(input);
        var calibrationNumber = FindCalibrationNumberPart1(preparedInput);
        return calibrationNumber;
    }

    public static string ReplaceStringDigits(string input)
    {
        var hasWord = Words.Any(o => input.IndexOf(o, StringComparison.Ordinal) > -1);
        if (!hasWord)
            return input;

        var result = $"{input}";

        string? firstWord = null;
        var firstWordIndex = int.MaxValue;
        for (var i = 0; i < Words.Count; i++)
        {
            var word = Words[i];
            var index = result.IndexOf(word, StringComparison.Ordinal);
            if (index != -1 && index < firstWordIndex)
            {
                firstWordIndex = index;
                firstWord = word;
            }
        }

        if(firstWord is not null) 
            result = result.Replace(firstWord, (Words.IndexOf(firstWord) + 1) + firstWord);

        string? lastWord = null;
        var lastWordIndex = int.MinValue;
        for (var i = 0; i < Words.Count; i++)
        {
            var word = Words[i];
            var index = result.LastIndexOf(word, StringComparison.Ordinal);
            if (index != -1 && index > lastWordIndex)
            {
                lastWordIndex = index;
                lastWord = word;
            }
        }

        if (lastWord is not null) 
            result = result.Replace(lastWord, (Words.IndexOf(lastWord) + 1) + lastWord);

        return result;
    }

    private static (int firstIndex, int lastIndex) FindCalibrationDigitIndices(string input)
    {
        int? firstNumberIndex = null;
        int? lastNumberIndex = null;
        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (firstNumberIndex is null && int.TryParse(c.ToString(), out _)) 
                firstNumberIndex = i;

            if (int.TryParse(c.ToString(), out _)) 
                lastNumberIndex = i;
        }

        return (firstNumberIndex ?? 0, lastNumberIndex ?? 0);
    }
}