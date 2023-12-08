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
}
