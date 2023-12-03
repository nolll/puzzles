using Puzzles.Common.Puzzles;
using Puzzles.Common.Strings;

namespace Puzzles.Euler.Puzzles.Euler017;

public class Euler017 : EulerPuzzle
{
    public override string Name => "Number letter counts";

    protected override PuzzleResult Run()
    {
        var result = Run(1000);
        return new PuzzleResult(result, "96bf6c43cf870a65a7526b18a8d55292");
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