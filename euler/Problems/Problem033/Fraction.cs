namespace Euler.Problems.Problem033;

public class Fraction
{
    public int Numerator { get; }
    public int Denominator { get; }
    public int ReducedNumerator { get; set; }
    public int ReducedDenominator { get; set; }
    public bool CanBeReduced { get; }

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
        CanBeReduced = GetCanBeReduced();
    }

    public double Result => (double)Numerator / Denominator;
    public double ReducedResult => ReducedDenominator > 0
        ? (double)ReducedNumerator / ReducedDenominator
        : 0;

    private bool GetCanBeReduced()
    {
        var numeratorString = Numerator.ToString();
        var denominatorString = Denominator.ToString();

        var numeratorChars = numeratorString.ToCharArray();
        var denominatorChars = denominatorString.ToCharArray();

        if (numeratorChars.First() == numeratorChars.Last())
            return false;

        if (denominatorChars.First() == denominatorChars.Last())
            return false;

        if (numeratorChars.Last() == '0' && denominatorChars.Last() == '0')
            return false;

        var commonChar = numeratorChars.FirstOrDefault(o => denominatorChars.Contains(o));

        ReducedNumerator = int.Parse(numeratorString.Replace(commonChar.ToString(), ""));
        ReducedDenominator = int.Parse(denominatorString.Replace(commonChar.ToString(), ""));

        return commonChar != default;
    }

    public string Print()
    {
        return $"{Numerator} / {Denominator} => {Result}";
    }
}