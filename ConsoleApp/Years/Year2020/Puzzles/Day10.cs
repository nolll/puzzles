using System;
using System.Threading;
using Core.PowerAdapters;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day10 : Day2020
    {
        public Day10() : base(10)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var chain = new PowerAdapterChain(FileInput);
            return new PuzzleResult($"The product is: {chain.DifferenceProduct}");
        }

        public override PuzzleResult RunPart2()
        {
            var chain = new PowerAdapterChain(FileInput);
            var combinations = chain.GetTotalNumberOfCombinations();
            return new PuzzleResult($"Total number of combinations: {combinations}");
        }
    }
}