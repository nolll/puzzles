using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq29;

public class Aquaq29 : AquaqPuzzle
{
    public override string Name => "On the up and up";
    public override bool IsSlow => true;

    protected override PuzzleResult Run()
    {
        var count = 0;
        for (var i = 0; i <= 520185742; i++)
        {
            if(IsGoodNumber(i))
                count++;
        }
        
        return new PuzzleResult(count, "c478e9df2470b2ed3fde4e7cabdfc697");
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