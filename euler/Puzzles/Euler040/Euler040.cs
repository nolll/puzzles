using System.Text;
using Common.Puzzles;

namespace Euler.Puzzles.Euler040;

public class Euler040 : EulerPuzzle
{
    private const int Initial = 1;
    private const int Max = 1_000_000;
    private const int StepMultiplier = 10;

    public override string Name => "Champernowne's Constant";

    protected override PuzzleResult Run()
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

        return new PuzzleResult(product, "6f3ef77ac0e3619e98159e9b6febf557");
    }
}