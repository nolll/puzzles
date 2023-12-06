using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2017.Aoc201712;

public class Pipes
{
    public int PipesInGroupZero { get; }
    public int GroupCount { get; }

    public Pipes(string input)
    {
        var strRows = StringReader.ReadLines(input);
        var dictionary = new Dictionary<int, IList<int>>();
        var groups = new List<List<int>>();

        foreach (var r in strRows)
        {
            var parts = r.Replace(" ", "").Split("<->");
            var group = int.Parse(parts[0]);
            var members = parts[1].Split(',').Select(int.Parse).ToList();
            dictionary[group] = members;
        }

        while (dictionary.Keys.Count > 0)
        {
            var start = dictionary.Keys.OrderBy(o => o).First();
            var group = new List<int> { start };
            var lookup = new List<int>();
            lookup.AddRange(dictionary[start]);
            dictionary.Remove(start);
            while (lookup.Any())
            {
                var current = lookup.First();
                lookup.RemoveAt(0);

                if (!group.Contains(current))
                {
                    group.Add(current);
                    if(dictionary.TryGetValue(current, out var key))
                        lookup.AddRange(dictionary[current]);

                    dictionary.Remove(current);
                }
            }

            groups.Add(group);
        }
            
        PipesInGroupZero = groups[0].Count;
        GroupCount = groups.Count;
    }
}