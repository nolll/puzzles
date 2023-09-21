using Euler.Common.Strings;
using Euler.Platform;

namespace Euler.Problems.Problem017;

public class Problem017 : Problem
{
    public override string Name => "Number letter counts";

    public override ProblemResult Run()
    {
        var result = Run(1000);
        return new ProblemResult(result, 21124);
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