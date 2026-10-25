using Pzl.Common;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Numbers;

namespace Pzl.Aquaq.Puzzles;

[Name("Veni Vidi Vitavi")]
public class Aquaq22 : AquaqPuzzle
{
    [Puzzle("7d8d3bfb160f0e65ad6f9266e5174745")]
    public int Solve(string input) => ToCaesarCipherSum(string.Concat(Numbers.IntsFromString(input).Select(Conversion.ToRoman)));

    public int ToCaesarCipherSum(string input) => input.ToCharArray().Select(CaesarCipher.Encrypt).Sum();
}