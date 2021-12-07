using System;
using System.Linq;
using Core.Platform;

namespace Core.Puzzles.Year2021.Day07
{
    public class Year2021Day07 : Year2021Day
    {
        public override int Day => 7;

        public override PuzzleResult RunPart1()
        {
            var result = GetFuel1(FileInput);
            return new PuzzleResult(result, 344535);
        }

        public override PuzzleResult RunPart2()
        {
            var result = GetFuel2(FileInput);
            return new PuzzleResult(result, 95581659);
        }

        public int GetFuel1(string input)
        {
            var minDiff = int.MaxValue;
            var minDiffPos = 0;
            var positions = input.Split(',').Select(int.Parse).ToArray();
            for (int i = 0; i < positions.Length; i++)
            {
                var diff = 0;
                for (int j = 0; j < positions.Length; j++)
                {
                    var large = Math.Max(positions[i], positions[j]);
                    var small = Math.Min(positions[i], positions[j]);
                    diff += large - small;
                }

                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }

            return minDiff;
        }

        public int GetFuel2(string input)
        {
            var minCost = int.MaxValue;
            var minCostPos = 0;
            var positions = input.Split(',').Select(int.Parse).ToArray();
            var maxPos = positions.Max();
            for (int i = 0; i < maxPos; i++)
            {
                var cost = 0;
                for (int j = 0; j < positions.Length; j++)
                {
                    cost += GetCost(i, positions[j]);
                }

                if (cost < minCost)
                {
                    minCost = cost;
                    //minCostPos = positions[i];
                }
            }

            return minCost;
        }

        public int GetCost(int a, int b)
        {
            var large = Math.Max(a, b);
            var small = Math.Min(a, b);
            var diff = large - small;
            var d = 0;
            for (int k = 1; k <= diff; k++)
            {
                d += k;
            }

            return d;
        }
    }
}