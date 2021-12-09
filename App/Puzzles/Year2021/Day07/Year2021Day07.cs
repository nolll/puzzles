using System;
using System.Linq;
using App.Platform;

namespace App.Puzzles.Year2021.Day07
{
    public class Year2021Day07 : Puzzle
    {
        public override PuzzleResult RunPart1()
        {
            var result = GetFuel1(FileInput, false);
            return new PuzzleResult(result, 344535);
        }

        public override PuzzleResult RunPart2()
        {
            var result = GetFuel1(FileInput, true);
            return new PuzzleResult(result, 95581659);
        }
        
        public int GetFuel1(string input, bool useCrabEngineering)
        {
            Func<int, int, int> getCost = useCrabEngineering
                ? GetCrabEnginerringCost
                : GetCost;

            var minCost = int.MaxValue;
            var positions = input.Split(',').Select(int.Parse).ToArray();
            var maxPos = positions.Max();
            for (var i = 0; i < maxPos; i++)
            {
                var cost = positions.Sum(o => getCost(i, o));

                if (cost < minCost) 
                    minCost = cost;
            }

            return minCost;
        }

        public static int GetCost(int a, int b)
        {
            return GetDiff(a, b);
        }

        public int GetCrabEnginerringCost(int a, int b)
        {
            var diff = GetDiff(a, b);
            return diff * (diff + 1) / 2;
        }

        private static int GetDiff(int a, int b)
        {
            return Math.Max(a, b) - Math.Min(a, b);
        }
    }
}