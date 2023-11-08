using Common.Puzzles;
using Common.Strings;

namespace Euler.Puzzles.Euler017;

public class Euler017 : EulerPuzzle
{
    public override string Name => "Number letter counts";

    protected override PuzzleResult Run()
    {
        var result = Run(1000);
        return new PuzzleResult(result, "6a979d4a9cf85135408529edc8a133d0");
    }

    public int Run(int target)
    {
        var strings = new List<string>();
        for (var i = 1; i <= target; i++)
        {
            var numberAsWords = new NumberAsString(i).ToString();
            strings.Add(numberAsWords);
        }

        return CountLetters(strings);
    }
        
    private static int CountLetters(IEnumerable<string> strings)
    {
        return strings.Select(CountLetters).Sum();
    }

    private static int CountLetters(string s)
    {
        return s.Replace(" ", "").Length;
    }
}