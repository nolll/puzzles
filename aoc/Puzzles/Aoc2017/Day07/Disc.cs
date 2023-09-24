using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Aoc2017.Day07;

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