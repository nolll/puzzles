using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs03.Ecs0303;

[Name("Plug and Play")]
public class Ecs0303 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input) => 
        new(Solve(input, new Options()), "d02f51fc7c9cf34d3a3cf5b92623309d");

    public PuzzleResult Part2(string input) => 
        new(Solve(input, new Options(true)), "f70e34ae97fef1a1756adfe0db17d1ec");

    public PuzzleResult Part3(string input) => 
        new(Solve(input, new Options(true, true)), "c91d39a7c30ea5416f0e8adea6490f1c");

    private static int Solve(string input, Options options)
    {
        var nodes = ParseNodes(input).ToList();
        var root = nodes.First();

        foreach (var node in nodes.Skip(1))
        {
            var nodeToAdd = node;
            while (nodeToAdd is not null) 
                nodeToAdd = root.AddNode(nodeToAdd, options);
        }

        return root.Checksum;
    }
    
    private static IEnumerable<Node> ParseNodes(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var (id, plug, left, right, _) = line.Split(", ").Select(o => o.Split('=').Last()).ToArray();
            yield return new Node(int.Parse(id), new Connection(plug), new Connection(left), new Connection(right));
        }
    }
    
    public class Node(int id, Connection plug, Connection leftSocket, Connection rightSocket)
    {
        private int Id { get; } = id;
        private Connection Plug { get; } = plug;
        private Connection LeftSocket { get; } = leftSocket;
        private Connection RightSocket { get; } = rightSocket;
        
        private Node? LeftNode { get; set; }
        private Node? RightNode { get; set; }

        public Node? AddNode(Node? node, Options options)
        {
            if (node is null)
                return null;
            
            if (LeftNode is null && IsConnection(LeftSocket))
            {
                LeftNode = node;
                return null;
            }
            
            if (LeftNode is not null)
            {
                if (options.IsReplacentsEnabled && node.Plug.IsStrongConnection(LeftSocket) && !LeftNode.Plug.IsStrongConnection(LeftSocket))
                    (LeftNode, node) = (node, LeftNode);
                else
                    node = LeftNode.AddNode(node, options);
            }

            if (node is null)
                return null;
            
            if (RightNode is null && IsConnection(RightSocket))
            {
                RightNode = node;
                return null;
            }

            if (RightNode is null)
                return node;
            
            if (options.IsReplacentsEnabled && node.Plug.IsStrongConnection(RightSocket) && !RightNode.Plug.IsStrongConnection(RightSocket))
                (RightNode, node) = (node, RightNode);
            else
                node = RightNode.AddNode(node, options);

            return node;

            bool IsConnection(Connection socket) => 
                options.UseWeakConnections 
                    ? node.Plug.IsConnection(socket) 
                    : node.Plug.IsStrongConnection(socket);
        }

        private Node[] TraverseTree() =>
        [
            ..LeftNode?.TraverseTree() ?? [],
            this,
            ..RightNode?.TraverseTree() ?? []
        ];

        public int Checksum => TraverseTree().Select((o, i) => o.Id * (i + 1)).Sum();
    }
    
    public class Connection
    {
        private string Color { get; }
        private string Shape { get; }
        
        public Connection(string description) => (Color, Shape) = description.Split();
        public bool IsStrongConnection(Connection c) => c.Color == Color && c.Shape == Shape;
        public bool IsConnection(Connection c) => c.Color == Color || c.Shape == Shape;
    }

    public record Options(bool UseWeakConnections = false, bool IsReplacentsEnabled = false);
}