using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202220;

[Name("Grove Positioning System")]
public class Aoc202220 : AocPuzzle
{
    [Puzzle("7b8b8bc2da7c3dc6f35e0079a36a0aea")]
    public PuzzleResult Part1(string input) => new(Run(input, 1, 1));
    
    [Puzzle("ad028751d05a122940933df675dc9eb5")]
    public PuzzleResult Part2(string input) => new(Run(input, 811_589_153, 10));

    public static long Run(string input, long multiplier, int iterationCount)
    {
        var numbers = input.Split(LineBreaks.Single)
            .Where(o => o.Length > 0)
            .Select(s => long.Parse(s) * multiplier)
            .ToList();

        var list = new LinkedList<long>();
        var set = new Dictionary<long, LinkedListNode<long>>();

        var index = 0;
        foreach (var number in numbers)
        {
            var node = list.AddLast(number);
            set.Add(index, node);
            index++;
        }

        for (var iteration = 0; iteration < iterationCount; iteration++)
        {
            for (var i = 0; i < numbers.Count; i++)
            {
                var currentNode = set[i];
                var steps = currentNode.Value % (numbers.Count - 1);

                for (var j = 0; j < Math.Abs(steps); j++)
                {
                    var value = currentNode.Value;
                    var nextNode = steps > 0 ? currentNode.NextOrFirst() : currentNode.PreviousOrLast();
                    list.Remove(currentNode);
                    currentNode = steps > 0 ? list.AddAfter(nextNode, value) : list.AddBefore(nextNode, value);
                }

                set[i] = currentNode;
            }
        }

        var array = list.ToList();
        var offset = array.IndexOf(0);

        return new[] { 1, 2, 3 }.Select(o => array[(offset + o * 1000) % array.Count]).Sum();
    }
}