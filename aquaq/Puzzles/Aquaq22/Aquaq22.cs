using Common.Cryptography;
using Common.Numbers;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq22;

public class Aquaq22 : AquaqPuzzle
{
    public override string Name => "Veni Vidi Vitavi";

    protected override PuzzleResult Run()
    {
        var numbers = InputFile.Split(' ').Select(int.Parse);
        var romanNumbers = numbers.Select(Conversion.ToRoman);
        var sum = ToCaesarCipherSum(string.Join("", romanNumbers));

        return new PuzzleResult(sum, "f07ca4fff2262325714456751a804932");
    }

    public static int ToCaesarCipherSum(string input)
        => input.ToCharArray().Select(CaesarCipher.Encrypt).Sum();
}