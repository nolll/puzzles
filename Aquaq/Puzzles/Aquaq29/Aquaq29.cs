using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq29;

[IsSlow]
[Name("On the up and up")]
public class Aquaq29 : AquaqPuzzle
{
    public PuzzleResult Run(string input)
    {
        var count = 0;
        for (var i = 0; i <= 520185742; i++)
        {
            if(IsGoodNumber(i))
                count++;
        }
        
        return new PuzzleResult(count, "f29bbf87cdece98ecf1360bce7e5a63e");
    }

    public static int CountGoodNumbers(IEnumerable<int> input) => input.Count(IsGoodNumber);

    private static bool IsGoodNumber(int n)
    {
        var s = n.ToString();

        for (var i = 0; i < s.Length - 1; i++)
        {
            if (s[i] > s[i + 1])
                return false;
        }

        return true;
    }
}