using System.Collections.Generic;
using System.Linq;
using App.Common.Strings;

namespace App.Puzzles.Year2017.Day07;

public class RecursiveTowers
{
    public string BottomName { get; }
    public int AdjustedWeight { get; }

    public RecursiveTowers(string input)
    {
        var strings = PuzzleInputReader.ReadLines(input);
        var discs = new Dictionary<string, Disc>();
        foreach (var strDisc in strings)
        {
            var a = strDisc.Split("->").Select(o => o.Trim()).ToList();
            var idAndWeight = a[0];
            var children = a.Count > 1 
                ? a[1].Split(",").Select(o => o.Trim()).ToList()
                : new List<string>();

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
            {
                BottomName = key;
            }
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