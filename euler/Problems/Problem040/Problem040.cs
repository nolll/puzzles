using System.Text;
using Euler.Platform;

namespace Euler.Problems.Problem040;

public class Problem040 : EulerPuzzle
{
    private const int Initial = 1;
    private const int Max = 1_000_000;
    private const int StepMultiplier = 10;

    public override string Name => "Champernowne's Constant";

    public override ProblemResult Run()
    {
        var sb = new StringBuilder();
        var i = Initial;

        while (sb.Length < Max)
        {
            sb.Append(i.ToString());
            i++;
        }

        var s = sb.ToString();
        var numbers = new List<int>();
        for (var j = Initial; j < Max; j *= StepMultiplier)
        {
            numbers.Add(int.Parse(s[j - 1].ToString()));
        }

        var product = numbers.Aggregate(1, (a, b) => a * b);

        return new ProblemResult(product, 210);
    }
}