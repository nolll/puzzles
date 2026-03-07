using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs03.Ecs0303;

[Name("Plug and Play")]
public class Ecs0303 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var nodes = ParseNodes(input).ToList();
        var root = nodes.First();

        foreach (var node in nodes.Skip(1))
        {
            root.AddNode(node);
        }

        var orderedNodes = root.GetTreeOrder();
        var ids = orderedNodes.Select(o => o.Id);

        var counter = 1;
        var result = 0;
        foreach (var id in ids)
        {
            result += id * counter;
            counter++;
        }
        
        return new PuzzleResult(result, "d02f51fc7c9cf34d3a3cf5b92623309d");
    }

    private IEnumerable<Node> ParseNodes(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var (id, plug, left, right, _) = line.Split(", ").Select(o => o.Split('=').Last()).ToArray();
            yield return new Node(int.Parse(id), plug, left, right);
        }
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }

    public class Node(int id, string plug, string left, string right)
    {
        public int Id { get; } = id;
        public string Plug { get; } = plug;
        public string LeftSocket { get; } = left;
        public string RightSocket { get; } = right;
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        
        public bool AddNode(Node node)
        {
            var foundSpot = false;
            
            if (Left is null && node.Plug == LeftSocket)
            {
                Left = node;
                return true;
            }
            
            if (Left is not null)
            {
                foundSpot = Left.AddNode(node);
            }

            if (foundSpot)
                return foundSpot;
            
            if (Right is null && node.Plug == RightSocket)
            {
                Right = node;
                return true;
            }

            if (Right is not null)
            {
                foundSpot = Right.AddNode(node);
            }

            return foundSpot;
        }

        public Node[] GetTreeOrder()
        {
            Node[] list = [];
            if (Left is not null)
                list = Left.GetTreeOrder();

            list = [..list, this];
            
            if (Right is not null)
                list = [..list, ..Right.GetTreeOrder()];

            return list;
        }
    }
}