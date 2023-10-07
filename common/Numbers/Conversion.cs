using Spectre.Console.Rendering;
using System.Text;

namespace Common.Numbers;

public static class Conversion
{
    private static readonly List<(string Letters, int Value)> RomanNumberSegments = new()
    {
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
    };

    public static string ToBinary(int n)
    {
        return Convert.ToString(n, 2);
    }

    public static string ToRoman(int input)
    {
        var roman = new StringBuilder();
        while (input > 0)
        {
            foreach (var segment in RomanNumberSegments)
            {
                if (input >= segment.Value)
                {
                    roman.Append(segment.Letters);
                    input -= segment.Value;
                    break;
                }
            }
        }

        return roman.ToString();
    }
}
