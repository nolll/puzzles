using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201822;

public enum CaveTool
{
    Torch,
    ClimbingGear,
    Neither
}

public static class CavePathFinder
{
    public static int StepCountTo(Grid<CaveRegion> grid, Coord from, Coord to)
    {
        var coordCounts = GetCoordCounts(grid, from, to);
        return coordCounts
            .Where(o => o.X == from.X && o.Y == from.Y)
            .Select(o => o.CountWhenSwitchedToTorch)
            .MinBy(o => o);
    }

    private static IList<CaveCoordCount> GetCoordCounts(Grid<CaveRegion> grid, Coord from, Coord to)
    {
        var seen = new Dictionary<(int x, int y, CaveTool tool), int>();
        var queue = new List<CaveCoordCount>
        {
            new CaveCoordCount(to.X, to.Y, CaveTool.Torch, 0),
            new CaveCoordCount(to.X, to.Y, CaveTool.ClimbingGear, 7),
            new CaveCoordCount(to.X, to.Y, CaveTool.Neither, 7)
        };
        var index = 0;
        while (index < queue.Count)
        {
            var current = queue[index];
            var currentAddress = new Coord(current.X, current.Y);
            var isStart = currentAddress.Equals(from);

            if (!isStart)
            {
                var region = grid.ReadValueAt(currentAddress);
                var adjacentCoords = grid.OrthogonalAdjacentCoordsTo(currentAddress);
                foreach (var next in adjacentCoords)
                {
                    var targetRegion = grid.ReadValueAt(next);
                    var targetTool = GetTool(region, targetRegion, current.Tool);
                    var visited = seen.TryGetValue((next.X, next.Y, targetTool), out var existingCount);
                    var cost = current.Tool == targetTool ? 1 : 8;
                    var totalCount = current.Count + cost;
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

    public int CountWhenSwitchedToTorch
    {
        get
        {
            if (Tool == CaveTool.Torch)
                return Count;

            return Count + 7;
        }
    }
}