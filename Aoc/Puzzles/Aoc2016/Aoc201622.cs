using System.Text.RegularExpressions;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Grid Computing")]
public class Aoc201622 : AocPuzzle
{
    [Puzzle("75405bd6fc453111e999ebdc18ba4f78")]
    public int Part1(string input) => GetViablePairCount(input);

    [Puzzle("112a5875109cbca20cbe3dd1d02fe9fd")]
    public int Part2(string input) => MoveStorage(input);

    private static readonly Regex WhiteSpaceRegex = new("[ ]{2,}");

    private int GetViablePairCount(string input) => GetNodesThatCanMove(input).Count;

    private IList<Coord> GetNodesThatCanMove(string input)
    {
        var storage = ParseGrid(input);
        return GetNodesThatCanMove(storage);
    }

    private static IList<Coord> GetNodesThatCanMove(Grid<StorageNode> storage)
    {
        var nodes = new List<Coord>();

        for (var ya = 0; ya < storage.Height; ya++)
        {
            for (var xa = 0; xa < storage.Width; xa++)
            {
                for (var yb = 0; yb < storage.Height; yb++)
                {
                    for (var xb = 0; xb < storage.Width; xb++)
                    {
                        if (xa != xb || ya != yb)
                        {
                            var nodeA = storage.ReadValueAt(xa, ya);
                            var nodeB = storage.ReadValueAt(xb, yb);
                            var nodeAHasData = nodeA.Used > 0;
                            var nodeACanFitOnNodeB = nodeA.Used <= nodeB.Avail;
                            if (nodeAHasData && nodeACanFitOnNodeB)
                            {
                                nodes.Add(new Coord(xa, ya));
                            }
                        }
                    }
                }
            }
        }

        return nodes;
    }

    private int MoveStorage(string input)
    {
        var storage = ParseGrid(input);
        var grid = new Grid<char>(storage.Width, storage.Height, '#');
        var nodesThatCanMove = GetNodesThatCanMove(storage);
        foreach (var address in nodesThatCanMove)
        {
            grid.MoveTo(address);
            grid.WriteValue('.');
        }

        var startAddress = new Coord(0, 0);
        for (var y = 0; y < storage.Height; y++)
        {
            for (var x = 0; x < storage.Width; x++)
            {
                var node = storage.ReadValueAt(x, y);
                if (node.Used == 0)
                    startAddress = new Coord(x, y);
            }
        }

        var topLeft = new Coord(0, 0);
        var topRight = new Coord(grid.Width - 1, 0);
        var goal = new Coord(topRight.X - 1, topRight.Y);
        var distance1 = PathFinder.ShortestPathTo(grid, startAddress, goal).Count();
        var distance2 = PathFinder.ShortestPathTo(grid, goal, topLeft).Count();
        return distance1 + distance2 * 5 + 1;
    }

    private Grid<StorageNode> ParseGrid(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var dataRows = rows.Skip(2);
        var grid = new Grid<StorageNode>();

        foreach (var row in dataRows)
        {
            var parts = RemoveExtraSpaces(row).Split(' ');

            var nodeName = parts[0];
            var lastPartOfName = nodeName.Split('/').Last();
            var coordParts = lastPartOfName.Split('-');
            var x = int.Parse(coordParts[1].Replace("x", ""));
            var y = int.Parse(coordParts[2].Replace("y", ""));
            var used = int.Parse(parts[2].Replace("T", ""));
            var avail = int.Parse(parts[3].Replace("T", ""));

            grid.MoveTo(x, y);
            grid.WriteValue(new StorageNode(used, avail));
        }

        return grid;
    }

    private string RemoveExtraSpaces(string s) => WhiteSpaceRegex.Replace(s, " ");

    private record struct StorageNode(int Used, int Avail);
}