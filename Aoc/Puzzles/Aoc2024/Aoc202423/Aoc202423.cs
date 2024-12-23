using Pzl.Common;
using Pzl.Tools.HashSets;
using Pzl.Tools.Queues;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202423;

[Name("LAN Party")]
public class Aoc202423 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var pairs = input.Split(LineBreaks.Single).Select(o => o.Split('-'));
        var connections = new HashSet<(string, string)>();
        var computers = new HashSet<string>();
        foreach (var pair in pairs)
        {
            computers.AddRange(pair);
            connections.Add((pair[0], pair[1]));
            connections.Add((pair[1], pair[0]));
        }

        var seen = new HashSet<string>();
        var ca = computers.ToArray();
        for (var i = 0; i < ca.Length; i++)
        {
            for (var j = i + 1; j < ca.Length; j++)
            {
                if (i == j)
                    continue;
                
                for (var k = j + 1; k < ca.Length; k++)
                {
                    if (k == j || k == i)
                        continue;

                    var a = ca[i];
                    var b = ca[j];
                    var c = ca[k];
                    
                    if (!(a.StartsWith('t') || b.StartsWith('t') || c.StartsWith('t')))
                        continue;
                    
                    if (!(connections.Contains((a, b)) && 
                          connections.Contains((b, c)) &&
                          connections.Contains((c, a))))
                        continue;
                    
                    var id = string.Join(",", new List<string> { a, b, c }.OrderBy(o => o));
                    seen.Add(id);
                }
            }    
        }
        
        return new PuzzleResult(seen.Count, "97ab68c276be721e860fa345dd875ad5");
    }

    public PuzzleResult Part2(string input)
    {
        var pairs = input.Split(LineBreaks.Single).Select(o => o.Split('-'));
        var connections = new Dictionary<string, List<string>>();
        var computers = new HashSet<string>();
        foreach (var pair in pairs)
        {
            computers.AddRange(pair);
            if(!connections.TryAdd(pair[0], [pair[1]]))
                connections[pair[0]].Add(pair[1]);
            
            if(!connections.TryAdd(pair[1], [pair[0]]))
                connections[pair[1]].Add(pair[0]);
        }
        
        var bestGroup = new List<string>();

        while (computers.Count > 0)
        {
            var first = computers.First();
            var currentGroup = new List<string>{first};
            var queue = new Queue<string>(connections[first]);
            computers.Remove(first);
            while (queue.Count > 0)
            {
                var computer = queue.Dequeue();
            
                if (currentGroup.All(o => connections[computer].Contains(o)))
                {
                    currentGroup.Add(computer);
                    queue.Enqueue(connections[computer]);
                }
                else
                {
                    if (currentGroup.Count > bestGroup.Count)
                        bestGroup = currentGroup;
                }
            }
        }

        var s = string.Join(",", bestGroup.Order());
        
        return new PuzzleResult(s, "e5522cb6dd3d3913820759dee7696eb4");
    }
}