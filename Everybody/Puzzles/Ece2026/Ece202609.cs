using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

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
    public int Part2(string input) => SolvePart2And3(input);

    [Puzzle("")]
    public int Part3(string input) => SolvePart2And3(input);

    private int SolvePart2And3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var total = 0;
        foreach (var line in lines)
        {
            var (_, growth, limit) = Numbers.IntsFromString(line);
            var branch = new Branch(growth, limit, []);
            
            var time = 0;
            while (branch.CanGrowMoreLeaves)
            {
                time++;
                branch.Grow();
            }

            total += time;
        }

        return total;
    }

    [DebuggerDisplay("{Size},{TotalSize}")]
    private class Branch(int growth, int limit, List<Branch> children, int size = 0)
    {
        public int Size { get; set; } = size;
        private List<Branch> Children { get; set; } = children;
        public int TotalSize => Size + Children.Sum(o => o.TotalSize) + JointSize;
        public int TotalLeafCount => LeafCount + Children.Sum(o => o.TotalLeafCount);
        public bool CanGrowBigger => TotalSize < limit;
        public bool CanGrowMoreLeaves => TotalLeafCount < limit;
        private int JointSize => Children.Count > 0 ? 1 : 0;
        private int LeafCount => Children.Count > 0 ? 0 : 1;

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