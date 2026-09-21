using Pzl.Common;
using Pzl.Tools.Maths;

namespace Pzl.Euler.Puzzles.Euler057;

[Name("Square Root Convergents")]
public class Euler057 : EulerPuzzle
{
    private readonly int[] _sequence = [2];
    private const int Start = 1;
    
    [Puzzle("a108ed87069fbb10b6d6595e8795dc16")]
    public int Solve()
    {
        var n = 1;
        var count = 0;
        while (n <= 1000)
        {
            if (HasLongerNumerator(n))
                count++;
            
            n++;
        }
        
        return count;
    }

    public bool HasLongerNumerator(int levels)
    {
        var result = MathTools.ContinuedFraction(Start, _sequence, levels);
        return result.Numerator.ToString().Length > result.Denominator.ToString().Length;
    }
}