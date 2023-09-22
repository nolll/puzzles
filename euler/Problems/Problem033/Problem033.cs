using common.Puzzles;
using Euler.Platform;

namespace Euler.Problems.Problem033;

public class Problem033 : EulerPuzzle
{
    public override string Name => "Digit Cancelling Fraction";

    public override PuzzleResult Run()
    {
        var fractions = new List<Fraction>();

        for (var numerator = 10; numerator < 100; numerator++)
        {
            for (var denominator = 10; denominator < 100; denominator++)
            {
                var fraction = new Fraction(numerator, denominator);
                if(Math.Abs(fraction.Result - 1) > 0)
                    fractions.Add(new Fraction(numerator, denominator));
            }
        }

        fractions = fractions.Where(o => o.CanBeReduced && o.Result < 1 && o.Result == o.ReducedResult).ToList();
        
        var combinedNumerator = fractions.Select(o => o.Numerator).Aggregate(1, (a, b) => a * b);
        var combinedDenominator = fractions.Select(o => o.Denominator).Aggregate(1, (a, b) => a * b);
        
        // Found by inspecting the numbers. The denominator is the numerator * 100
        var resultDenominator = combinedDenominator / combinedNumerator;

        return new PuzzleResult(resultDenominator, 100);
    }
}