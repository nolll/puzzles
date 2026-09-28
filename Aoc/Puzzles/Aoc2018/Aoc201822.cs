using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Mode Maze")]
public class Aoc201822 : AocPuzzle
{
    [Puzzle("5df14da907f6928ed33a598ab21592eb")]
    public long Part1(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var depth = int.Parse(rows.First().Split(' ').Last());
        var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
        var targetX = targetCoords.First();
        var targetY = targetCoords.Last();

        return new CaveSystem(depth, targetX, targetY).TotalRiskLevel;
    }

    [Puzzle("4e117a44b69dd25c64f6f7b08d9c3a18")]
    public int Part2(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        var depth = int.Parse(rows.First().Split(' ').Last());
        var targetCoords = rows.Last().Split(' ').Last().Split(',').Select(int.Parse).ToList();
        var targetX = targetCoords.First();
        var targetY = targetCoords.Last();
        var caveSystem = new CaveSystem(depth, targetX, targetY);

        return caveSystem.ResqueMan();
    }

    public class CaveSystem
    {
        private readonly long _depth;
        private Grid<CaveRegion> _cave = new();
        private readonly Coord _mouth;
        private readonly Coord _target;

        public long TotalRiskLevel { get; }

        public CaveSystem(long depth, int targetX, int targetY)
        {
            _depth = depth;
            _mouth = new Coord(0, 0);
            _target = new Coord(targetX, targetY);
            BuildCave(_target);
            TotalRiskLevel = GetTotalRiskLevel();
        }

        private long GetTotalRiskLevel()
        {
            long riskLevel = 0;
            for (var y = 0; y <= _target.Y; y++)
            {
                for (var x = 0; x <= _target.X; x++)
                {
                    riskLevel += _cave.ReadValueAt(x, y).RiskLevel;
                }
            }

            return riskLevel;
        }

        private void BuildCave(Coord target)
        {
            const int padding = 15;
            var xMax = target.X + padding;
            var yMax = target.Y + padding;
            var width = xMax - 1;
            var height = yMax - 1;
            _cave = new Grid<CaveRegion>(width, height);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var address = new Coord(x, y);
                    var region = _cave.ReadValueAt(address);
                    region.GeologicIndex = GetGeologicIndex(address);
                    region.ErosionLevel = GetErosionLevel(region.GeologicIndex);
                    region.RiskLevel = GetRiskLevel(region.ErosionLevel);
                    region.Type = GetRegionType(region.RiskLevel);
                    _cave.WriteValueAt(address, region);
                }
            }
        }

        private long GetGeologicIndex(Coord address)
        {
            if (address.Equals(_mouth) || address.Equals(_target))
                return 0;

            if (address.Y == 0)
                return address.X * 16807;

            if (address.X == 0)
                return address.Y * 48271;

            var a = _cave.ReadValueAt(address.X - 1, address.Y);
            var b = _cave.ReadValueAt(address.X, address.Y - 1);

            return a.ErosionLevel * b.ErosionLevel;
        }

        private long GetErosionLevel(long geologicIndex)
        {
            return (geologicIndex + _depth) % 20183;
        }

        private long GetRiskLevel(long erosionLevel)
        {
            return erosionLevel % 3;
        }

        private CaveRegionType GetRegionType(long riskLevel)
        {
            return (CaveRegionType)riskLevel;
        }

        public int ResqueMan()
        {
            return CavePathFinder.StepCountTo(_cave, _target, _mouth);
        }
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

    public struct CaveRegion
    {
        public CaveRegionType Type { get; set; }
        public long GeologicIndex { get; set; }
        public long ErosionLevel { get; set; }
        public long RiskLevel { get; set; }

        public override string ToString() => Type switch
        {
            CaveRegionType.Rocky => ".",
            CaveRegionType.Wet => "=",
            _ => "|"
        };
    }
    
    public enum CaveTool
    {
        Torch,
        ClimbingGear,
        Neither
    }
    
    public enum CaveRegionType
    {
        Rocky = 0,
        Wet = 1,
        Narrow = 2
    }
}