using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0102;

[Name("Tangled Trees")]
public class Ecs0102 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var root = new TreeNode("", 0);
        var leftNodes = new List<TreeNode>();
        var rightNodes = new List<TreeNode>();
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var leftParts = parts[2].Replace("left=[", "").Replace("]", "").Split(',');
            var rightParts = parts[3].Replace("right=[", "").Replace("]", "").Split(',');
            var leftNode = new TreeNode(leftParts.Last(), int.Parse(leftParts.First()));
            root.AddLeft(leftNode);
            leftNodes.Add(leftNode);
            var rightNode = new TreeNode(rightParts.Last(), int.Parse(rightParts.First()));
            root.AddRight(rightNode);
            rightNodes.Add(rightNode);
        }

        var l = leftNodes.GroupBy(o => o.Level).OrderByDescending(o => o.Count()).First().OrderBy(o => o.Score);
        var r = rightNodes.GroupBy(o => o.Level).OrderByDescending(o => o.Count()).First().OrderBy(o => o.Score);
        var ls = string.Join("", l.Select(o => o.Name));
        var rs = string.Join("", r.Select(o => o.Name));
        
        return new PuzzleResult(ls + rs, "d01fa4a99d218a85cc2d618feac1fc3a");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}

public class TreeNode(string name, int score)
{
    private TreeNode? _left;
    private TreeNode? _right;
    
    public string Name { get; } = name;
    public int Score { get; } = score;
    public int Level { get; set; } = 0;
    public TreeNode? Parent { get; set; }

    public void AddLeft(TreeNode node)
    {
        if (_left == null)
        {
            _left = node;
            node.Parent = this;
            node.Level = Level + 1;
        }
        else
        {
            _left.Add(node);
        }
    }
    
    public void AddRight(TreeNode node)
    {
        if (_right == null)
        {
            _right = node;
            node.Parent = this;
            node.Level = Level + 1;
        }
        else
        {
            _right.Add(node);
        }
    }

    private void Add(TreeNode node)
    {
        if(node.Score < Score)
            AddLeft(node);
        else
            AddRight(node);
    }
}