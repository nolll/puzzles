using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler017;

[Name("Number letter counts")]
public class Euler017 : EulerPuzzle
{
    public PuzzleResult Run(string input)
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