using System;
using System.Linq;
using Core.Eggnog;

namespace ConsoleApp.Years.Year2015.Days
{
    public class Day17 : Day2015
    {
        public Day17() : base(17)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var container = new EggnogContainers(Input);
            var combinations1 = container.GetCombinations(150);
            Console.WriteLine($"Combinations: {combinations1.Count}");

            WritePartTitle();
            var combinations2 = container.GetCombinationsWithLeastContainers(150);
            var containerCount = combinations2.First().Count;
            Console.WriteLine($"Combinations with {containerCount} containers: {combinations2.Count}");
        }

        protected override string Input => @"
33
14
18
20
45
35
16
35
1
13
18
13
50
44
48
6
24
41
30
42";
    }
}