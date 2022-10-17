using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2018.Day22;

public enum CaveTool
{
    Torch,
    ClimbingGear,
    Neither
}

public static class CavePathFinder
{
    public static int StepCountTo(IMatrix<CaveRegion> matrix, MatrixAddress from, MatrixAddress to)
    {
        var coordCounts = GetCoordCounts(matrix, from, to);
        var goalCounts = coordCounts.Where(o => o.X == from.X && o.Y == from.Y).ToList();
        var torchGoals = goalCounts.Where(o => o.Tool == CaveTool.Torch).ToList();
        if (torchGoals.Any())
        {
            return torchGoals.OrderBy(o => o.Count).First().Count;
        }
        var climbingGoals = goalCounts.Where(o => o.Tool == CaveTool.ClimbingGear).ToList();
        if (climbingGoals.Any())
        {
            return climbingGoals.OrderBy(o => o.Count).First().Count + 7;
        }

        return 0;
    } 
        
    private static IList<CaveCoordCount> GetCoordCounts(IMatrix<CaveRegion> matrix, MatrixAddress from, MatrixAddress to)
    {
        var seen = new Dictionary<(int x, int y, CaveTool tool), int>();
        var queue = new List<CaveCoordCount>
        {
            new CaveCoordCount(to.X, to.Y, CaveTool.Torch, 0),
            new CaveCoordCount(to.X, to.Y, CaveTool.ClimbingGear, 7)
        };
        var index = 0;
        while (index < queue.Count)
        {
            var current = queue[index];
            var currentAddress = new MatrixAddress(current.X, current.Y);
            var isStart = currentAddress.Equals(from);

            if (!isStart)
            {
                var region = matrix.ReadValueAt(currentAddress);
                var adjacentCoords = matrix.PerpendicularAdjacentCoordsTo(currentAddress);
                foreach (var next in adjacentCoords)
                {
                    var targetRegion = matrix.ReadValueAt(next);
                    var targetTool = GetTool(region, targetRegion, current.Tool);
                    var cost = current.Tool == targetTool ? 1 : 8;

                    var totalCount = current.Count + cost;
                    var visited = seen.TryGetValue((next.X, next.Y, targetTool), out var existingCount);
                    if (!visited || totalCount < existingCount)
                    {
                        seen[(next.X, next.Y, targetTool)] = totalCount;
                        queue.Add(new CaveCoordCount(next.X, next.Y, targetTool, totalCount));
                    }
                }
            }

            index++;
        }

        return queue;
    }

    private static CaveTool GetTool(CaveRegion from, CaveRegion to, CaveTool currentTool)
    {
        if (from.Type == CaveRegionType.Rocky)
        {
            if (to.Type == CaveRegionType.Wet)
                return CaveTool.ClimbingGear;

            if (to.Type == CaveRegionType.Narrow)
                return CaveTool.Torch;

            return currentTool;
        }

        if (from.Type == CaveRegionType.Wet)
        {
            if (to.Type == CaveRegionType.Rocky)
                return CaveTool.ClimbingGear;

            if (to.Type == CaveRegionType.Narrow)
                return CaveTool.Neither;

            return currentTool;
        }

        if (to.Type == CaveRegionType.Rocky)
            return CaveTool.Torch;

        if (to.Type == CaveRegionType.Wet)
            return CaveTool.Neither;

        return currentTool;
    }
}

public class CaveCoordCount
{
    public int X { get; }
    public int Y { get; }
    public CaveTool Tool { get; }
    public int Count { get; }

    public CaveCoordCount(int x, int y, CaveTool tool, int count)
    {
        X = x;
        Y = y;
        Tool = tool;
        Count = count;
    }
}