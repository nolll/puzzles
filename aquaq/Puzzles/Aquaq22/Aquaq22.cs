using Puzzles.common.Cryptography;
using Puzzles.common.Numbers;
using Puzzles.common.Puzzles;

namespace Puzzles.aquaq.Puzzles.Aquaq22;

public class Aquaq22 : AquaqPuzzle
{
    public override string Name => "Veni Vidi Vitavi";

    protected override PuzzleResult Run()
    {
        var numbers = InputFile.Split(' ').Select(int.Parse);
        var romanNumbers = numbers.Select(Conversion.ToRoman);
        var sum = ToCaesarCipherSum(string.Join("", romanNumbers));

        return new PuzzleResult(sum, "7d8d3bfb160f0e65ad6f9266e5174745");
    }

    public static int ToCaesarCipherSum(string input)
        => input.ToCharArray().Select(CaesarCipher.Encrypt).Sum();
}