using System;
using Aoc.Common.Hashing;

namespace Aoc.Puzzles.Year2015.Day04;

public class AdventCoinMiner
{
    public static int Mine(string key, int leadingZeros, int startIndex = 1)
    {
        var index = startIndex;
        var hashFactory = new Hashfactory();
        var isCoinFound = GetCompareFunc(leadingZeros);
        while (true)
        {
            var hashedBytes = hashFactory.ByteHashFromString($"{key}{index}");

            if (isCoinFound(hashedBytes))
                return index;

            index++;
        }
    }

    private static Func<byte[], bool> GetCompareFunc(int leadingZeros)
        => leadingZeros == 5 ? StartsWithFiveZeros : StartsWithSixZeros;

    private static bool StartsWithFiveZeros(byte[] bytes) 
        => bytes[0] == 0 && bytes[1] == 0 && bytes[2] < 10;

    private static bool StartsWithSixZeros(byte[] bytes) 
        => bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0;
}