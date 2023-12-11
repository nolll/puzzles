using Pzl.Common;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Numbers;

namespace Pzl.Aquaq.Puzzles.Aquaq22;

[Name("Veni Vidi Vitavi")]
public class Aquaq22(string input) : AquaqPuzzle(input)
{
    protected override PuzzleResult Run()
    {
        var numbers = Input.Split(' ').Select(int.Parse);
        var romanNumbers = numbers.Select(Conversion.ToRoman);
        var sum = ToCaesarCipherSum(string.Join("", romanNumbers));

        return new PuzzleResult(sum, "7d8d3bfb160f0e65ad6f9266e5174745");
    }

    public static int ToCaesarCipherSum(string input)
        => input.ToCharArray().Select(CaesarCipher.Encrypt).Sum();
}