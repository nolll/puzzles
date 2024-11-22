using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq18;

[Name("Emit time")]
public class Aquaq18(string input) : AquaqPuzzle
{
    protected override PuzzleResult Run()
    {
        var sum = StringReader.ReadLines(input)
            .Select(o => DateTime.Parse($"2020-02-02 {o}"))
            .Select(StepsToPalindrome)
            .Sum();

        return new PuzzleResult(sum, "9730fe5001e883b1b33acd8c976dd938");
    }

    public static bool IsPalindromeTime(DateTime dateTime)
        => dateTime.ToString("HH:mm:ss").IsPalindrome();

    public static int StepsToPalindrome(DateTime dateTime)
    {
        var stepCount = 0;
        while (true)
        {
            if (IsPalindromeTime(dateTime.AddSeconds(stepCount)) || IsPalindromeTime(dateTime.AddSeconds(-stepCount)))
                return stepCount;

            stepCount++;
        }
    }
}