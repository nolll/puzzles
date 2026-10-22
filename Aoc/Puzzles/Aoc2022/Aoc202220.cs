using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Grove Positioning System")]
public class Aoc202220 : AocPuzzle
{
    [Puzzle("7b8b8bc2da7c3dc6f35e0079a36a0aea")]
    public long Part1(string input) => Solve(input, 1, 1);
    
    [Puzzle("ad028751d05a122940933df675dc9eb5")]
    public long Part2(string input) => Solve(input, 811_589_153, 10);

    public static long Solve(string input, long multiplier, int iterationCount)
    {
        var numbers = input.Split(LineBreaks.Single)
            .Where(o => o.Length > 0)
            .Select(s => long.Parse(s) * multiplier)
            .ToList();

        var list = new LinkedList<long>();
        var set = new Dictionary<long, LinkedListNode<long>>();
        
        foreach (var (number, index) in numbers.Select((o, i) => (o, i)))
        {
            var node = list.AddLast(number);
            set.Add(index, node);
        }

        for (var iteration = 0; iteration < iterationCount; iteration++)
        {
            for (var i = 0; i < numbers.Count; i++)
            {
                var currentNode = set[i];
                var steps = currentNode.Value % (numbers.Count - 1);

                for (var j = 0; j < Math.Abs(steps); j++)
                {
                    var nextNode = steps > 0 ? currentNode.NextOrFirst() : currentNode.PreviousOrLast();
                    list.Remove(currentNode);
                    currentNode = steps > 0 ? list.AddAfter(nextNode, currentNode.Value) : list.AddBefore(nextNode, currentNode.Value);
                }

                set[i] = currentNode;
            }
        }

        var array = list.ToList();
        var offset = array.IndexOf(0);

        return Enumerable.Range(1, 3).Select(o => array[(offset + o * 1000) % array.Count]).Sum();
    }
}