using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Recursive Circus")]
public class Aoc201707 : AocPuzzle
{
    [Puzzle("7005dac413613feef76e5931331aac39")]
    public string Part1(string input)
    {
        var towers = new RecursiveTowers(input);
        return towers.BottomName ?? "";
    }

    [Puzzle("a431cfa493227f90dd341325e0c8992b")]
    public int Part2(string input) => new RecursiveTowers(input).AdjustedWeight;
    
    public class RecursiveTowers
    {
        public string? BottomName { get; }
        public int AdjustedWeight { get; }

        public RecursiveTowers(string input)
        {
            var strings = input.Split(LineBreaks.Single);
            var discs = new Dictionary<string, Disc>();
            foreach (var strDisc in strings)
            {
                var a = strDisc.Split("->").Select(o => o.Trim()).ToList();
                var idAndWeight = a[0];
                var children = a.Count > 1 
                    ? a[1].Split(",").Select(o => o.Trim()).ToList()
                    : [];

                idAndWeight = idAndWeight.Replace("(", "").Replace(")", "");
                var b = idAndWeight.Split(' ');
                var id = b[0];
                var weight = int.Parse(b[1]);
                var disc = new Disc(id, weight, children);
                discs.Add(id, disc);
            }

            foreach (var key in discs.Keys)
            {
                var disc = discs[key];
                foreach (var childName in disc.ChildrenIds)
                {
                    var child = discs[childName];
                    child.ParentId = disc.Id;
                    disc.Children.Add(child);
                }
            }

            foreach (var key in discs.Keys)
            {
                if (discs[key].ParentId == null) 
                    BottomName = key;
            }

            var unbalanced = discs.Values.First(o => !o.IsBalanced && o.HasBalancedChildren);
            var weightDiff = unbalanced.WeightDiff;
            var groups = unbalanced.Children.GroupBy(n => n.TotalWeight).
                Select(group =>
                    new
                    {
                        Weight = group.Key,
                        Discs = group.ToList(),
                        Count = group.Count()
                    }).ToList();

            var failingDisc = groups.FirstOrDefault(o => o.Count == 1)?.Discs.First();

            AdjustedWeight = failingDisc?.Weight - weightDiff ?? 0;
        }
    }
    
    public class Disc
    {
        public string Id { get; }
        public int Weight { get; }
        public int TotalWeight => Weight + ChildrensWeight;
        public int ChildrensWeight => Children.Sum(o => o.TotalWeight);
        public IList<Disc> Children { get; }
        public IList<string> ChildrenIds { get; }
        public string? ParentId { get; set; }

        public Disc(string id, int weight, IList<string> childrenIds)
        {
            Id = id;
            Weight = weight;
            ChildrenIds = childrenIds;
            Children = new List<Disc>();
        }

        public int WeightDiff
        {
            get
            {
                var weights = Children.Select(o => o.TotalWeight).Distinct().ToList();
                if (weights.Count > 1)
                {
                    return weights.Max() - weights.Min();
                }

                return 0;
            }
        }

        public bool IsBalanced => WeightDiff == 0;
        public bool HasBalancedChildren => Children.Count(o => !o.IsBalanced) == 0;
    }
}