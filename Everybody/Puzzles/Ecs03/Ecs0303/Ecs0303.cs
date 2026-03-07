using System.Diagnostics;
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
            root.AddNodePart1(node);
        
        return new PuzzleResult(root.Checksum, "d02f51fc7c9cf34d3a3cf5b92623309d");
    }

    public PuzzleResult Part2(string input)
    {
        var nodes = ParseNodes(input).ToList();
        var root = nodes.First();

        foreach (var node in nodes.Skip(1)) 
            root.AddNodePart2(node);
        
        return new PuzzleResult(root.Checksum, "f70e34ae97fef1a1756adfe0db17d1ec");
    }

    public PuzzleResult Part3(string input)
    {
        var nodes = ParseNodes(input).ToList();
        var root = nodes.First();

        foreach (var node in nodes.Skip(1))
        {
            var nodeToAdd = node;
            while (nodeToAdd is not null)
            {
                nodeToAdd = root.AddNodePart3(nodeToAdd);
            }
        }

        return new PuzzleResult(root.Checksum, "c91d39a7c30ea5416f0e8adea6490f1c");
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
    
    [DebuggerDisplay("{Id}")]
    public class Node
    {
        private Connection Plug { get; }
        private Connection LeftSocket { get; }
        private Connection RightSocket { get; }
        
        public int Id { get; }
        private Node? LeftNode { get; set; }
        private Node? RightNode { get; set; }

        public Node(int id, Connection plug, Connection leftSocket, Connection rightSocket)
        {
            Id = id;
            Plug = plug;
            LeftSocket = leftSocket;
            RightSocket = rightSocket;
        }
        
        public bool AddNodePart1(Node node)
        {
            var foundSpot = false;
            
            if (LeftNode is null && node.Plug.IsStrongConnection(LeftSocket))
            {
                LeftNode = node;
                return true;
            }
            
            if (LeftNode is not null)
            {
                foundSpot = LeftNode.AddNodePart1(node);
            }

            if (foundSpot)
                return foundSpot;
            
            if (RightNode is null && node.Plug.IsStrongConnection(RightSocket))
            {
                RightNode = node;
                return true;
            }

            if (RightNode is not null)
            {
                foundSpot = RightNode.AddNodePart1(node);
            }

            return foundSpot;
        }
        
        public bool AddNodePart2(Node node)
        {
            var foundSpot = false;
            
            if (LeftNode is null && node.Plug.IsConnection(LeftSocket))
            {
                LeftNode = node;
                return true;
            }
            
            if (LeftNode is not null)
            {
                foundSpot = LeftNode.AddNodePart2(node);
            }

            if (foundSpot)
                return foundSpot;
            
            if (RightNode is null && node.Plug.IsConnection(RightSocket))
            {
                RightNode = node;
                return true;
            }

            if (RightNode is not null)
            {
                foundSpot = RightNode.AddNodePart2(node);
            }

            return foundSpot;
        }
        
        public Node? AddNodePart3(Node node)
        {
            Node? unplacedNode = node;
            
            if (LeftNode is null && node.Plug.IsConnection(LeftSocket))
            {
                LeftNode = node;
                return null;
            }
            
            if (LeftNode is not null)
            {
                if (node.Plug.IsStrongConnection(LeftSocket) && !LeftNode.Plug.IsStrongConnection(LeftSocket))
                {
                    (LeftNode, node) = (node, LeftNode);
                    unplacedNode = node;
                }
                else
                {
                    unplacedNode = LeftNode.AddNodePart3(node);
                }
            }

            if (unplacedNode is null)
                return null;
            
            if (RightNode is null && unplacedNode.Plug.IsConnection(RightSocket))
            {
                RightNode = unplacedNode;
                return null;
            }

            if (RightNode is not null)
            {
                if (unplacedNode.Plug.IsStrongConnection(RightSocket) && !RightNode.Plug.IsStrongConnection(RightSocket))
                {
                    (RightNode, unplacedNode) = (unplacedNode, RightNode);
                }
                else
                {
                    unplacedNode = RightNode.AddNodePart3(unplacedNode);
                }
            }

            return unplacedNode;
        }

        private Node[] GetTreeOrder()
        {
            Node[] list = [];
            if (LeftNode is not null)
                list = LeftNode.GetTreeOrder();

            list = [..list, this];
            
            if (RightNode is not null)
                list = [..list, ..RightNode.GetTreeOrder()];

            return list;
        }

        public int Checksum => GetTreeOrder().Select((o, i) => o.Id * (i + 1)).Sum();
    }
    
    public class Connection
    {
        public string Color { get; }
        public string Shape { get; }
        
        public Connection(string description)
        {
            (Color, Shape) = description.Split();
        }
        
        public bool IsStrongConnection(Connection c) => c.Color == Color && c.Shape == Shape;
        public bool IsConnection(Connection c) => c.Color == Color || c.Shape == Shape;
        public override string ToString() => $"{Color} {Shape}";
    }
}