using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Digital Plumber")]
public class Aoc201712 : AocPuzzle
{
    [Puzzle("4d7ad96354959558ed0b95fa70be777c")]
    public int Part1(string input) => new Pipes(input).PipesInGroupZero;

    [Puzzle("0dadeecc2db53e7a3420661be4101b8f")]
    public int Part2(string input) => new Pipes(input).GroupCount;
    
    public class Pipes
    {
        public int PipesInGroupZero { get; }
        public int GroupCount { get; }

        public Pipes(string input)
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
                var lookup = new List<int>();
                lookup.AddRange(dictionary[start]);
                dictionary.Remove(start);
                while (lookup.Any())
                {
                    var current = lookup.First();
                    lookup.RemoveAt(0);

                    if (group.Contains(current))
                        continue;
                
                    group.Add(current);
                    if(dictionary.TryGetValue(current, out var value))
                        lookup.AddRange(value);

                    dictionary.Remove(current);
                }

                groups.Add(group);
            }
            
            PipesInGroupZero = groups[0].Count;
            GroupCount = groups.Count;
        }
    }
}