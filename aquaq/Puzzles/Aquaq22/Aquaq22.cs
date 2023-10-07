using System.Text;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq22;

public class Aquaq22 : AquaqPuzzle
{
    private static readonly List<(string Letters, int Value)> Segments = new()
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

    public override string Name => "Veni Vidi Vitavi";

    protected override PuzzleResult Run()
    {
        var numbers = InputFile.Split(' ').Select(int.Parse);
        var romanNumbers = numbers.Select(ToRoman);
        var sum = ToCaesarCipher(string.Join("", romanNumbers));

        return new PuzzleResult(sum, 43103);
    }

    public static string ToRoman(int input)
    {
        var roman = new StringBuilder();
        while (input > 0)
        {
            foreach (var segment in Segments)
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

    public static int ToCaesarCipher(string input)
        => input.ToCharArray().Select(o => o - 'A' + 1).Sum();
}