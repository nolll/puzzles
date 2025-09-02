using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs01.Ecs0102;

[Name("Tangled Trees")]
public class Ecs0102 : EverybodyStoryPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var root = new TreeNode("", "", 0);
        var leftNodes = new List<TreeNode>();
        var rightNodes = new List<TreeNode>();
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var id = parts[1].Replace("id=", "");
            var leftParts = parts[2].Replace("left=[", "").Replace("]", "").Split(',');
            var rightParts = parts[3].Replace("right=[", "").Replace("]", "").Split(',');
            var leftNode = new TreeNode(id, leftParts.Last(), int.Parse(leftParts.First()));
            root.AddLeft(leftNode);
            leftNodes.Add(leftNode);
            var rightNode = new TreeNode(id, rightParts.Last(), int.Parse(rightParts.First()));
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
        var lines = input.Split(LineBreaks.Single);
        var root = new TreeNode("", "", 0);
        var lSet = new Dictionary<string, TreeNode>();
        var rSet = new Dictionary<string, TreeNode>();
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var parts = line.Split(' ');
            if (parts.Length == 2)
            {
                var swapId = parts[1];
                var node1 = lSet[swapId];
                var node2 = rSet[swapId];
                var score1 = node1.Score;
                var name1 = node1.Name;
                var score2 = node2.Score;
                var name2 = node2.Name;
                node1.Score = score2;
                node1.Name = name2;
                node2.Score = score1;
                node2.Name = name1;
                continue;
            }

            var id = parts[1].Replace("id=", "");
            var leftParts = parts[2].Replace("left=[", "").Replace("]", "").Split(',');
            var rightParts = parts[3].Replace("right=[", "").Replace("]", "").Split(',');
            var leftNode = new TreeNode(id, leftParts.Last(), int.Parse(leftParts.First()));
            root.AddLeft(leftNode);
            lSet.Add(id, leftNode);
            var rightNode = new TreeNode(id, rightParts.Last(), int.Parse(rightParts.First()));
            root.AddRight(rightNode);
            rSet.Add(id, rightNode);
        }

        var l = lSet.Values.GroupBy(o => o.Level).OrderByDescending(o => o.Count()).First().OrderBy(o => o.SortString);
        var r = rSet.Values.GroupBy(o => o.Level).OrderByDescending(o => o.Count()).First().OrderBy(o => o.SortString);
        var ls = string.Join("", l.Select(o => o.Name));
        var rs = string.Join("", r.Select(o => o.Name));
        
        return new PuzzleResult(ls + rs, "f9758c5ab09c84d7c166731aedc8beaa");
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}

[DebuggerDisplay("{Score},{Name}")]
public class TreeNode(string id, string name, int score)
{
    private TreeNode? _left;
    private TreeNode? _right;

    public string Id { get; } = id;
    public string Name { get; set; } = name;
    public int Score { get; set; } = score;
    public int Level { get; set; }
    public TreeNode? Parent { get; set; }
    public int SortOrder { get; set; }
    public string SortString { get; set; } = "";

    public void AddLeft(TreeNode node)
    {
        if (_left == null)
        {
            _left = node;
            node.Parent = this;
            node.Level = Level + 1;
            node.SortString = SortString + "L";
            node.SortOrder = SortOrder - 1;
        }
        else
        {
            node.SortOrder -= 1;
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
            node.SortString = SortString + "R";
            node.SortOrder = SortOrder + 1;
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