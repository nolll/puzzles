using System;
using Core.Eggnog;

namespace ConsoleApp.Years.Year2015
{
    public class Day17 : Day
    {
        public Day17() : base(17)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var container = new EggnogContainers(Input);
            var combinations = container.GetCombinations(150);
            Console.WriteLine($"Combination count: {combinations.Count}");
        }

        private const string Input = @"
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