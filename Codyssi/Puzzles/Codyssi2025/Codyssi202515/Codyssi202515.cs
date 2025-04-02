using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202515;

[Name("Artifacts at Atlantis")]
public class Codyssi202515 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var nodes = ParseNodes(input.Split(LineBreaks.Double).First());
        var root = nodes.First();
        root.Add(nodes.Skip(1));

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
        var nodes = ParseNodes(input.Split(LineBreaks.Double).First());
        var root = nodes.First();
        root.Add(nodes.Skip(1));

        var special = new Node("special", 500_000); 
        root.Add(special);
        var path = GetPathTo(special);
        var result = string.Join("-",path.Select(o => o.Name));

        return new PuzzleResult(result, "4b91364b84392b399b44d31d662a9fa1");
    }

    public PuzzleResult Part3(string input)
    {
        var nodes = ParseNodes(input.Split(LineBreaks.Double).First());
        var root = nodes.First();
        root.Add(nodes.Skip(1));

        var specials = ParseNodes(input.Split(LineBreaks.Double).Last());
        root.Add(specials);
        var specialsPaths = specials.Select(GetPathTo).ToArray();
        var common = GetLowestCommonAncestor(specialsPaths);

        return new PuzzleResult(common?.Name, "cdb171b505a56eed22f6483b7e0bf002");
    }
    
    public class Node(string name, int id)
    {
        private readonly Node?[] _children = [null, null];
        public string Name { get; } = name;
        public int Id { get; } = id;
        public int Level { get; private set; }
        public Node? Parent { get; private set; }

        public void Add(Node node, int level = 1)
        {
            var targetIndex = node.Id > Id ? 1 : 0;
            if (_children[targetIndex] is null)
            {
                node.Level = level;
                node.Parent = this;
                _children[targetIndex] = node;
            }
            else
            {
                _children[targetIndex]?.Add(node, level + 1);
            }
        }
        
        public void Add(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                Add(node);
            }
        }
    }

    private static Node[] ParseNodes(string input) => input
        .Split(LineBreaks.Single)
        .Select(o => o.Split(" | "))
        .Select(o => new Node(o[0], int.Parse(o[1])))
        .ToArray();

    private static Node[] GetPathTo(Node node)
    {
        var path = new List<Node>();
        var current = node;
        while (current.Parent != null)
        {
            current = current.Parent;
            path.Add(current);
        }

        return path.Reversed().ToArray();
    }

    private static Node GetLowestCommonAncestor(Node[][] paths)
    {
        for (var i = 0; i < paths.Select(o => o.Length).Min(); i++)
        {
            if (paths[0][i].Name == paths[1][i].Name)
                continue;
            
            return paths[0][i].Parent!;
        }

        throw new Exception("Common ancestor not found");
    }
}