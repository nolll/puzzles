using System;
using System.Linq;
using Core.TreeNavigation;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day03 : Day2020
    {
        public Day03() : base(3)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var navigator = new TreeNavigator(FileInput);
            var treeCount = navigator.GetSingleTreeCount();
            Console.WriteLine($"Number of trees: {treeCount}");

            WritePartTitle();
            var treeCounts = navigator.GetAllTreeCounts().ToList();
            var product = treeCounts.Aggregate((long)1, (a, b) => a * b);
            Console.WriteLine($"Number of trees for all trajectories: {product}");
        }
    }
}