using System.Diagnostics;
using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

// Thanks to Jonathan Paulson for the optimized part 3 solution
[Name("The Sulphurprise")]
public class Ece202609 : EverybodyEventPuzzle
{
    [Puzzle("f4f4fcb82b79e28ff3635e3972f5f32f")]
    public int Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var total = 0;
        foreach (var line in lines)
        {
            var (_, growth, limit) = Numbers.IntsFromString(line);
            var branch = new Branch(growth, limit, []);

            var time = 0;
            while (branch.CanGrowBigger)
            {
                time++;
                branch.Grow();
            }

            total += time;
        }

        return total;
    }

    [Puzzle("f3a92d07a4ebfef85261232435765f80")]
    public BigInteger Part2(string input) => SolvePart2And3(input);

    [Puzzle("c0eb6c1d709a7950e4b93831febc93bd")]
    public BigInteger Part3(string input) => SolvePart2And3(input);

    private BigInteger SolvePart2And3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var total = new BigInteger(0);
        var cache = new Dictionary<(long, BigInteger, long), BigInteger>();
        foreach (var line in lines)
        {
            var (_, growth, limit) = Numbers.LongsFromString(line);

            var lo = new BigInteger(0);
            var hi = new BigInteger(1);
            while (BranchesAfterTime(1, hi, growth, cache) + 1 < limit)
                hi *= 2;

            while (lo < hi)
            {
                var mid = (lo + hi) / 2;
                if (BranchesAfterTime(1, mid, growth, cache) + 1 >= limit)
                    hi = mid;
                else
                    lo = mid + 1;
            }

            total += lo + 1;
        }

        return total;
    }

    private BigInteger BranchesAfterTime(long x, BigInteger t, long growth, Dictionary<(long, BigInteger, long), BigInteger> cache)
    {
        if (cache.TryGetValue((x, t, growth), out var cached))
            return cached;

        if (t <= 0)
        {
            cache.Add((x, t, growth), 0);
            return 0;
        }

        var dt = growth - x;
        if (t < dt)
        {
            cache.Add((x, t, growth), 0);
            return 0;
        }

        var result = 1 + 2 * BranchesAfterTime(growth / 2, t - dt, growth, cache) + BranchesAfterTime(1, t - dt, growth, cache);
        cache.Add((x, t, growth), result);
        return result;
    }

    [DebuggerDisplay("{Size},{TotalSize}")]
    private class Branch(int growth, int limit, List<Branch> children, int size = 0)
    {
        public int Size { get; set; } = size;
        private List<Branch> Children { get; set; } = children;
        public int TotalSize => Size + Children.Sum(o => o.TotalSize) + JointSize;
        public bool CanGrowBigger => TotalSize < limit;
        private int JointSize => Children.Count > 0 ? 1 : 0;

        public void Grow()
        {
            Size += 1;
            if (Size % growth == 0)
                Split();

            foreach (var child in Children)
            {
                child.Grow();
            }
        }

        private void Split()
        {
            Size /= 2;
            Children =
            [
                new Branch(growth, limit, Children, Size - 1),
                new Branch(growth, limit, [])
            ];
        }
    }
}