using Puzzles.common.Puzzles;
using Puzzles.common.Strings;

namespace Puzzles.aquaq.Puzzles.Aquaq18;

public class Aquaq18 : AquaqPuzzle
{
    public override string Name => "Emit time";

    protected override PuzzleResult Run()
    {
        var sum = InputFile.Split(Environment.NewLine)
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