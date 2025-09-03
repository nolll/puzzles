using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0102;

[Name("Tangled Trees")]
public class Ecs0102 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input) => new(Run(SimpleSwap, input), "d01fa4a99d218a85cc2d618feac1fc3a");
    public PuzzleResult Part2(string input) => new(Run(SimpleSwap, input), "f9758c5ab09c84d7c166731aedc8beaa");
    public PuzzleResult Part3(string input) => new(Run(FullSwap, input), "034d6deb943709125409c3ed3f859821");

    private static string Run(Action<TreeNode, string> swap, string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var root = new TreeNode("", "", 0);
        foreach (var line in lines)
        {
            if (line.StartsWith("SWAP"))
            {
                swap(root, ParseSwapId(line));
                continue;
            }

            var (leftNode, rightNode) = ParseNodes(line);
            root.AddLeft(leftNode);
            root.AddRight(rightNode);
        }
        
        return GetCombinedMessage(root);
    }

    private static void SimpleSwap(TreeNode root, string swapId)
    {
        var matchingNodes = GetAllNodes(root).Where(o => o.Id == swapId).ToArray();
        var node1 = matchingNodes.First();
        var node2 = matchingNodes.Last();
        (node1.Score, node2.Score) = (node2.Score, node1.Score);
        (node1.Name, node2.Name) = (node2.Name, node1.Name);
    }
    
    private static void FullSwap(TreeNode root, string swapId)
    {
        var matchingNodes = GetAllNodes(root).Where(o => o.Id == swapId).ToArray();
        var node1 = matchingNodes.First();
        var node2 = matchingNodes.Last();
        
        var sort1 = node1.SortString;
        var sort2 = node2.SortString;
        var parent1 = node1.Parent!;
        var parent2 = node2.Parent!;
                
        if(sort1 == "L")
            parent1.SetLeft(node2);
        else
            parent1.SetRight(node2);
                
        if(sort2 == "L")
            parent2.SetLeft(node1);
        else
            parent2.SetRight(node1);
    }

    private static (TreeNode leftNode, TreeNode rightNode) ParseNodes(string line)
    {
        var parts = line.Split(' ');
        var id = parts[1].Replace("id=", "");
        var leftParts = parts[2].Replace("left=[", "").Replace("]", "").Split(',');
        var rightParts = parts[3].Replace("right=[", "").Replace("]", "").Split(',');
        var leftNode = new TreeNode(id, leftParts.Last(), int.Parse(leftParts.First()));
        var rightNode = new TreeNode(id, rightParts.Last(), int.Parse(rightParts.First()));
        return (leftNode, rightNode);
    }
    
    private static string ParseSwapId(string line) => line.Split(' ')[1];

    private static IEnumerable<TreeNode> GetAllNodes(TreeNode rootLeft)
    {
        var q = new Queue<TreeNode>();
        q.Enqueue(rootLeft);

        while (q.Any())
        {
            var n = q.Dequeue();
            yield return n;
            
            if(n.Left is not null)
                q.Enqueue(n.Left);
            
            if(n.Right is not null)
                q.Enqueue(n.Right);
        }
    }

    private static string GetCombinedMessage(TreeNode node) => GetMessage(node.Left) + GetMessage(node.Right);

    private static string GetMessage(TreeNode? node)
    {
        if (node is null) 
            return "";
        
        var nodeNames = GetAllNodes(node).GroupBy(o => o.Level).OrderByDescending(o => o.Count()).ThenBy(o => o.Key)
            .First()
            .OrderBy(o => o.SortOrder)
            .Select(o => o.Name);

        return string.Join("", nodeNames);
    }
}

[DebuggerDisplay("{Score},{Name}")]
public class TreeNode(string id, string name, int score)
{
    public TreeNode? Left { get; private set; }
    public TreeNode? Right { get; private set; }
    public TreeNode? Parent { get; private set; }
    
    public string Id { get; } = id;
    public string Name { get; set; } = name;
    public int Score { get; set; } = score;
    public int Level => Parent?.Level + 1 ?? 0;
    public string SortOrder => (Parent?.SortOrder ?? "") + SortString;
    public string SortString { get; private set; } = "";

    public void AddLeft(TreeNode node)
    {
        if (Left == null)
            SetLeft(node);
        else
            Left.Add(node);
    }
    
    public void AddRight(TreeNode node)
    {
        if (Right == null)
            SetRight(node);
        else
            Right.Add(node);
    }

    public void SetLeft(TreeNode node)
    {
        Left = node;
        node.Parent = this;
        node.SortString = "L";
    }
    
    public void SetRight(TreeNode node)
    {
        Right = node;
        node.Parent = this;
        node.SortString = "R";
    }

    private void Add(TreeNode node)
    {
        if(node.Score < Score)
            AddLeft(node);
        else
            AddRight(node);
    }
}