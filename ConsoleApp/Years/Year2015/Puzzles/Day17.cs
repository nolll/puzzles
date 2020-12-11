using System.Linq;
using Core.Eggnog;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day17 : Day2015
    {
        public Day17() : base(17)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var container = new EggnogContainers(FileInput);
            var combinations = container.GetCombinations(150);
            return new PuzzleResult($"Combinations: {combinations.Count}");
        }

        public override PuzzleResult RunPart2()
        {
            var container = new EggnogContainers(FileInput);
            var combinations = container.GetCombinationsWithLeastContainers(150);
            var containerCount = combinations.First().Count;
            return new PuzzleResult($"Combinations with {containerCount} containers: {combinations.Count}");
        }
    }
}