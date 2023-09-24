using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Aoc2019.Aoc201906;

public class OrbitCalculator
{
    Dictionary<string, Body> d = new Dictionary<string, Body>();

    public OrbitCalculator(string input)
    {
        var items = input.Trim().Split('\n').Select(o => o.Trim());
        foreach (var item in items)
        {
            var parts = item.Split(')');
            var parentName = parts[0];
            var childName = parts[1];

            if (!d.TryGetValue(parentName, out var parent))
            {
                parent = new Body(parentName);
                d.Add(parentName, parent);
            }

            if (!d.TryGetValue(childName, out var child))
            {
                child = new Body(childName);
                d.Add(childName, child);
            }

            if (child.Parent == null)
            {
                child.Parent = parent;
            }
        }
    }

    public int GetOrbitCount()
    {
        return d.Values.Sum(o => o.OrbitCount);
    }

    public int GetSantaDistance()
    {
        var youPath = d["YOU"].ParentPath;
        var santaPath = d["SAN"].ParentPath;

        var allNames = $"{youPath}|{santaPath}".Split('|').ToList();
        var uniqueSingles = new List<string>();
        foreach (var name in allNames)
        {
            if(name == "SAN" || name == "YOU")
                continue;

            if (allNames.Count(o => o == name) == 1)
            {
                uniqueSingles.Add(name);
            }
        }
        return uniqueSingles.Count;
    }
}