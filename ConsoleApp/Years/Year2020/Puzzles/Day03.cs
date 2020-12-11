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

        public override PuzzleResult RunPart1()
        {
            var navigator = new TreeNavigator(FileInput);
            var treeCount = navigator.GetSingleTreeCount();
            return new PuzzleResult($"Number of trees: {treeCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var navigator = new TreeNavigator(FileInput);
            var treeCounts = navigator.GetAllTreeCounts().ToList();
            var product = treeCounts.Aggregate((long)1, (a, b) => a * b);
            return new PuzzleResult($"Number of trees for all trajectories: {product}");
        }
    }
}