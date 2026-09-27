using Pzl.Common;
using Pzl.Tools.Cryptography;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201504;

[Name("The Ideal Stocking Stuffer")]
public class Aoc201504 : AocPuzzle
{
    [Puzzle("e89372908b5202e6ce4d69a8b3538295")]
    public int Part1(string input) => Mine(input, 5);

    [Puzzle("9eb348bda7d61e7026099765b89a55fa")]
    public int Part2(string input) => Mine(input, 6);

    private static int Mine(string key, int leadingZeros)
    {
        var index = 1;
        var hashFactory = new HashFactory();
        var isCoinFound = GetCompareFunc(leadingZeros);
        while (true)
        {
            var hashedBytes = hashFactory.ByteHash($"{key}{index}");

            if (isCoinFound(hashedBytes))
                return index;

            index++;
        }
    }

    private static Func<byte[], bool> GetCompareFunc(int leadingZeros) => leadingZeros == 5 
        ? StartsWithFiveZeros 
        : StartsWithSixZeros;

    private static bool StartsWithFiveZeros(byte[] bytes) => 
        bytes[0] == 0 && bytes[1] == 0 && bytes[2] < 10;

    private static bool StartsWithSixZeros(byte[] bytes) => 
        bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0;
}