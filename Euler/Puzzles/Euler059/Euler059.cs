using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler059;

[Name("XOR Decryption")]
public class Euler059 : EulerPuzzle
{
    private const string Chars = "abcdefghijklmnopqrstuvwxyz";
    
    public PuzzleResult Run(string input)
    {
        var keys = GenerateKeys();
        var encryptedText = ParseEncryptedText(input);
        var decryptedText = BruteForceDecrypt(keys, encryptedText);
        var asciiSum = decryptedText.Select(o => (int)o).Sum();
        
        return new PuzzleResult(asciiSum, "d9dbe56c9710bdd032f5e12c46940879");
    }

    private static string ParseEncryptedText(string input) => string.Join("", input.Split(",")
        .Select(int.Parse)
        .Select(o => (char)o));

    private static string[] GenerateKeys() => PermutationGenerator.GetPermutations(Chars.ToCharArray(), 3)
        .Select(o => string.Join("", o))
        .ToArray();

    private static string BruteForceDecrypt(string[] keys, string inputText)
    {
        foreach (var chars in keys)
        {
            var str = Decrypt(chars, inputText);
            if (str.Contains("circle"))
                return str;
        }

        throw new Exception("Decryption failed.");
    }

    private static string Decrypt(string key, string inputText)
    {
        var pos = 0;
        var current = new List<char>();

        foreach (var c in inputText)
        {
            current.Add((char)Decrypt(key[pos % 3], c));
            pos++;
        }

        return string.Join("", current);
    }

    public static int Decrypt(int key, int s) => s ^ key;
}