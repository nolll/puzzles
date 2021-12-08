using System;
using App.Common.Hashing;

namespace App.Puzzles.Year2015.Day04
{
    public class AdventCoinMiner
    {
        public int Mine(string key, int leadingZeros, int startIndex = 1)
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

        private Func<byte[], bool> GetCompareFunc(int leadingZeros)
        {
            if (leadingZeros == 5)
                return StartsWithFiveZeros;
            return StartsWithSixZeros;
        }

        private static bool StartsWithFiveZeros(byte[] bytes)
        {
            return bytes[0] == 0 && bytes[1] == 0 && bytes[2] < 10;
        }

        private static bool StartsWithSixZeros(byte[] bytes)
        {
            return bytes[0] == 0 && bytes[1] == 0 && bytes[2] == 0;
        }
    }
}