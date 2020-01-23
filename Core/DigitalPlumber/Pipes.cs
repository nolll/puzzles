using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.DigitalPlumber
{
    public class Pipes
    {
        public int PipesLeadingToZero { get; }

        public Pipes(string input)
        {
            var strRows = PuzzleInputReader.Read(input);
            var groups = new Dictionary<int, IList<int>>();

            foreach (var r in strRows)
            {
                var parts = r.Replace(" ", "").Split("<->");
                var group = int.Parse(parts[0]);
                var members = parts[1].Split(',').Select(int.Parse).ToList();
                groups[group] = members;
            }

            const int start = 0;
            var connections = new List<int> {start};
            var lookup = new List<int>();
            lookup.AddRange(groups[start]);
            while (lookup.Any())
            {
                var current = lookup.First();
                lookup.RemoveAt(0);

                if (!connections.Contains(current))
                {
                    connections.Add(current);
                    lookup.AddRange(groups[current]);
                }
            }

            PipesLeadingToZero = connections.Count;
        }
    }
}