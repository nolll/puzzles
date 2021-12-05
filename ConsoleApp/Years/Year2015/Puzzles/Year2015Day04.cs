using System;
using Core.Tools;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Year2015Day04 : Year2015Day
    {
        private int _index;
        public override int Day => 4;

        public override PuzzleResult RunPart1()
        {
            var miner = new AdventCoinMiner();
            var coin = miner.Mine(Input, 5);
            _index = coin;
            return new PuzzleResult(coin, 346_386);
        }

        public override PuzzleResult RunPart2()
        {
            var miner = new AdventCoinMiner();
            var coin = miner.Mine(Input, 6, _index);
            return new PuzzleResult(coin, 9_958_218);
        }

        private const string Input = "iwrupvqb";
    }

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