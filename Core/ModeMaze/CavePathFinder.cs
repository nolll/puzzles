using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ModeMaze
{
    public enum CaveTool
    {
        Torch,
        ClimbingGear,
        Neither
    }

    public static class CavePathFinder
    {
        public static int StepCountTo(Matrix<CaveRegion> matrix, MatrixAddress from, MatrixAddress to)
        {
            var coordCounts = GetCoordCounts(matrix, from, to);
            var goalCounts = coordCounts.Where(o => o.X == from.X && o.Y == from.Y).ToList();
            return goalCounts.Any() ? goalCounts.Min(o => o.Count) : 0;
        }

        private static IList<CaveCoordCount> GetCoordCounts(Matrix<CaveRegion> matrix, MatrixAddress from, MatrixAddress to)
        {
            var queue = new List<CaveCoordCount> { new CaveCoordCount(to.X, to.Y, CaveTool.Torch, 0) };
            var index = 0;
            while (index < queue.Count)
            {
                var current = queue[index];
                matrix.MoveTo(current.X, current.Y);
                var region = matrix.ReadValue();
                var adjacentCoords = matrix.Adjacent4Coords;

                foreach (var next in adjacentCoords)
                {
                    var targetRegion = matrix.ReadValueAt(next);
                    var targetTool = GetTool(region, targetRegion, current.Tool);
                    var cost = current.Tool == targetTool ? 1 : 8;

                    var totalCount = current.Count + cost;
                    var existing = queue.Where(q => q.X == next.X && q.Y == next.Y).OrderBy(o => o.Count).FirstOrDefault();
                    var isLowerThanExisting = existing == null || existing.Count > totalCount;
                    if (isLowerThanExisting)
                        queue.Add(new CaveCoordCount(next.X, next.Y, targetTool, totalCount));
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
}