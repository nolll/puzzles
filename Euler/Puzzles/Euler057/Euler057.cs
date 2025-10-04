using System.Diagnostics;
using System.Numerics;
using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler057;

[Name("Square Root Convergents")]
public class Euler057 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        var n = 1;
        var count = 0;
        while (n <= 1000)
        {
            var result = Solve(n);
            if (result.Numerator.ToString().Length > result.Denominator.ToString().Length)
                count++;
            
            n++;
        }
        
        return new PuzzleResult(count, "a108ed87069fbb10b6d6595e8795dc16");
    }

    public static Fraction Solve(int levels)
    {
        var result = SolveRecursive(levels);
        return new Fraction(result.Numerator + result.Denominator, result.Numerator);
    }
    
    private static Fraction SolveRecursive(int level)
    {
        if (level == 1)
            return new Fraction(2, 1);
        
        var result = SolveRecursive(level - 1);
        return new Fraction(2 * result.Numerator + result.Denominator, result.Numerator);
    }

    [DebuggerDisplay("{Numerator}/{Denominator}")]
    public record Fraction(BigInteger Numerator, BigInteger Denominator);
}