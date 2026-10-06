using Pzl.Common;
using Pzl.Tools.Queues;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Digital Plumber")]
public class Aoc201712 : AocPuzzle
{
    [Puzzle("4d7ad96354959558ed0b95fa70be777c")]
    public int Part1(string input) => Solve(input)[0].Count;

    [Puzzle("0dadeecc2db53e7a3420661be4101b8f")]
    public int Part2(string input) => Solve(input).Count;

    public List<List<int>> Solve(string input)
    {
        var strRows = input.Split(LineBreaks.Single);
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
            var lookup = new Queue<int>();
            lookup.Enqueue(dictionary[start]);
            dictionary.Remove(start);
            while (lookup.Count != 0)
            {
                var current = lookup.Dequeue();

                if (group.Contains(current))
                    continue;

                group.Add(current);
                if (dictionary.TryGetValue(current, out var value))
                    lookup.Enqueue(value);

                dictionary.Remove(current);
            }

            groups.Add(group);
        }

        return groups;
    }
}