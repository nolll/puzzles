using System.Text;
using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler040;

public class Euler040 : EulerPuzzle
{
    private const int Initial = 1;
    private const int MaxLength = 1_000_000;
    private const int StepMultiplier = 10;

    public override string Name => "Champernowne's Constant";

    protected override PuzzleResult Run()
    {
        var sb = new StringBuilder();
        var i = Initial;

        while (sb.Length < MaxLength)
        {
            sb.Append(i);
            i++;
        }

        var s = sb.ToString();
        var numbers = new List<int>();
        for (var j = Initial; j < MaxLength; j *= StepMultiplier)
        {
            numbers.Add(int.Parse(s[j - 1].ToString()));
        }

        var product = numbers.Aggregate(1, (a, b) => a * b);

        return new PuzzleResult(product, "1e10a803d525ec160795a9bed9161106");
    }
}