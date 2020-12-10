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

        protected override void RunDay()
        {
            WritePartTitle();
            var chain = new PowerAdapterChain(FileInput);
            Console.WriteLine($"The product is: {chain.DifferenceProduct}");

            WritePartTitle();
            var combinations = chain.GetTotalNumberOfCombinations();
            Console.WriteLine($"Total number of combinations: {combinations}");
        }
    }
}