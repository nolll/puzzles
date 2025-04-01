using System.Runtime.CompilerServices;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202515;

[Name("Artifacts at Atlantis")]
public class Codyssi202515 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var items = input.Split(LineBreaks.Double)
            .First()
            .Split(LineBreaks.Single)
            .Select(o => o.Split(" | "))
            .Select(o => (name: o[0], id: int.Parse(o[1])))
            .ToList();

        var rootItem = items.First();
        var root = new Node(rootItem.name, rootItem.id);
        var nodes = new List<Node> { root };

        foreach (var item in items.Skip(1))
        {
            var node = new Node(item.name, item.id);
            nodes.Add(node);
            root.Add(node);
        }

        var levelCount = nodes.Max(o => o.Level) + 1;
        var bestSum = 0;
        for (var level = 0; level < levelCount; level++)
        {
            bestSum = Math.Max(bestSum, nodes.Where(o => o.Level == level).Sum(o => o.Id));
        }

        var result = bestSum * levelCount;

        return new PuzzleResult(result, "8b00815147aec7076ca7268d8709583c");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
    
    public class Node(string name, int id)
    {
        public string Name { get; } = name;
        public int Id { get; } = id;
        public int Level { get; set; }
        public Node?[] Children = [null, null];

        public void Add(Node node, int level = 1)
        {
            var targetIndex = node.Id > Id ? 1 : 0;
            if (Children[targetIndex] is null)
            {
                node.Level = level;
                Children[targetIndex] = node;
            }
            else
            {
                Children[targetIndex].Add(node, level + 1);
            }
        }
    }
}