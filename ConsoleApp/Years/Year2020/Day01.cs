using System;
using System.Linq;
using Core.ModuleMass;

namespace ConsoleApp.Years.Year2020
{
    public class Day01 : Day2020
    {
        public Day01() : base(1)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var sumFinder = new SumFinder(Input);
            var numbers1 = sumFinder.FindNumbersThatAddUpTo(Target, 2);
            var product1 = numbers1.Aggregate(1, (a, b) => a * b);
            Console.WriteLine($"Product of numbers that add up to {Target}: {product1}");

            WritePartTitle();
            var numbers2 = sumFinder.FindNumbersThatAddUpTo(Target, 3);
            var product2 = numbers2.Aggregate(1, (a, b) => a * b);
            Console.WriteLine($"Product of numbers that add up to {Target}: {product2}");
        }

        private const int Target = 2020;
    }
}