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

        var special = new Node("special", 500_000); 
        root.Add(special);

        var path = new List<Node>();
        Node? current = special;
        while (current.Parent != null)
        {
            current = current.Parent;
            path.Add(current);
        }

        var result = string.Join("-",path.Reversed().Select(o => o.Name));

        return new PuzzleResult(result, "4b91364b84392b399b44d31d662a9fa1");
    }

    public PuzzleResult Part3(string input)
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

        var specials = input.Split(LineBreaks.Double)
            .Last()
            .Split(LineBreaks.Single)
            .Select(o => o.Split(" | "))
            .Select(o => (name: o[0], id: int.Parse(o[1])))
            .ToList();

        var i1 = specials[0];
        var i2 = specials[1];

        var s1 = new Node(i1.name, i1.id);
        var s2 = new Node(i2.name, i2.id);
        root.Add(s1);
        root.Add(s2);

        var s1path = new List<Node>();
        Node? current1 = s1;
        while (current1.Parent != null)
        {
            current1 = current1.Parent;
            s1path.Add(current1);
        }
        
        var s2path = new List<Node>();
        Node? current2 = s2;
        while (current2.Parent != null)
        {
            current2 = current2.Parent;
            s2path.Add(current2);
        }

        s1path.Reverse();
        s2path.Reverse();

        Node? last = null;
        for (var i = 0; i < Math.Min(s1path.Count, s2path.Count); i++)
        {
            if (s1path[i].Name == s2path[i].Name)
                continue;
            
            last = s1path[i].Parent;
            break;
        }

        return new PuzzleResult(last.Name, "cdb171b505a56eed22f6483b7e0bf002");
    }
    
    public class Node(string name, int id)
    {
        public string Name { get; } = name;
        public int Id { get; } = id;
        public int Level { get; set; }
        public Node?[] Children = [null, null];
        public Node? Parent { get; set; }

        public void Add(Node node, int level = 1)
        {
            var targetIndex = node.Id > Id ? 1 : 0;
            if (Children[targetIndex] is null)
            {
                node.Level = level;
                node.Parent = this;
                Children[targetIndex] = node;
            }
            else
            {
                Children[targetIndex].Add(node, level + 1);
            }
        }
    }
}