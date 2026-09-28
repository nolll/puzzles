using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("The Treachery of Whales")]
public class Aoc202107 : AocPuzzle
{
    [Puzzle("666d31015d60e4cd37891ed574d5227f")]
    public int Part1(string input) => new CrabSubmarines().GetFuel(input, false);

    [Puzzle("7930686503708646dfb6d7f6a7e36ab2")]
    public int Part2(string input) => new CrabSubmarines().GetFuel(input, true);
    
    public class CrabSubmarines
    {
        public int GetFuel(string input, bool useCrabEngineering)
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

        public static int GetCost(int a, int b) => GetDiff(a, b);

        public int GetCrabEnginerringCost(int a, int b)
        {
            var diff = GetDiff(a, b);
            return diff * (diff + 1) / 2;
        }

        private static int GetDiff(int a, int b) => Math.Max(a, b) - Math.Min(a, b);
    }
}