using Pzl.Common;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Numbers;

namespace Pzl.Aquaq.Puzzles.Aquaq22;

[Name("Veni Vidi Vitavi")]
public class Aquaq22 : AquaqPuzzle
{
    [Puzzle("7d8d3bfb160f0e65ad6f9266e5174745")]
    public int Solve(string input)
    {
        var numbers = input.Split(' ').Select(int.Parse);
        var romanNumbers = numbers.Select(Conversion.ToRoman);
        return ToCaesarCipherSum(string.Join("", romanNumbers));
    }

    public static int ToCaesarCipherSum(string input) => input.ToCharArray().Select(CaesarCipher.Encrypt).Sum();
}