using System.Text;

namespace Pzl.Tools.Numbers;

public static class Conversion
{
    private static readonly List<(string Letters, int Value)> RomanNumberSegments =
    [
        ("M", 1000),
        ("CM", 900),
        ("D", 500),
        ("CD", 400),
        ("C", 100),
        ("XC", 90),
        ("L", 50),
        ("XL", 40),
        ("X", 10),
        ("IX", 9),
        ("V", 5),
        ("IV", 4),
        ("I", 1)
    ];

    public static string ToBinary(int n) => Convert.ToString(n, 2);

    public static string ToRoman(int input)
    {
        var roman = new StringBuilder();
        while (input > 0)
        {
            foreach (var (letters, value) in RomanNumberSegments)
            {
                if (input >= value)
                {
                    roman.Append(letters);
                    input -= value;
                    break;
                }
            }
        }

        return roman.ToString();
    }
    
    public static string ToBaseX(long v, int radix, string digits)
    {
        const int bitsInLong = 64;
        
        if (radix < 2 || radix > digits.Length)
            throw new ArgumentException("The radix must be >= 2 and <= " + digits.Length);

        if (v == 0)
            return "0";

        var index = bitsInLong - 1;
        var currentNumber = Math.Abs(v);
        var charArray = new char[bitsInLong];

        while (currentNumber != 0)
        {
            var remainder = (int)(currentNumber % radix);
            charArray[index--] = digits[remainder];
            currentNumber /= radix;
        }

        var result = new string(charArray, index + 1, bitsInLong - index - 1);
        if (v < 0) 
            result = "-" + result;

        return result;
    }
}
