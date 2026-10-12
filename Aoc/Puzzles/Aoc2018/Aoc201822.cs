using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Mode Maze")]
public class Aoc201822 : AocPuzzle
{
    private readonly Coord _mouth = new(0, 0);

    [Puzzle("5df14da907f6928ed33a598ab21592eb")]
    public long Part1(string input)
    {
        var (depth, target) = Parse(input);
        var cave = BuildCave(target, depth);
        return GetTotalRiskLevel(cave, target);
    }

    [Puzzle("4e117a44b69dd25c64f6f7b08d9c3a18")]
    public int Part2(string input)
    {
        var (depth, target) = Parse(input);
        var cave = BuildCave(target, depth);
        return ResqueMan(cave, target);
    }

    private static long GetTotalRiskLevel(Grid<CaveRegion> cave, Coord target)
    {
        long riskLevel = 0;
        for (var y = 0; y <= target.Y; y++)
        {
            for (var x = 0; x <= target.X; x++)
            {
                riskLevel += cave.ReadValueAt(x, y).RiskLevel;
            }
        }

        return riskLevel;
    }

    private Grid<CaveRegion> BuildCave(Coord target, long depth)
    {
        const int padding = 15;
        var xMax = target.X + padding;
        var yMax = target.Y + padding;
        var width = xMax - 1;
        var height = yMax - 1;
        var cave = new Grid<CaveRegion>(width, height);

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var address = new Coord(x, y);
                var region = cave.ReadValueAt(address);
                region.GeologicIndex = GetGeologicIndex(cave, address, target);
                region.ErosionLevel = GetErosionLevel(region.GeologicIndex, depth);
                region.RiskLevel = GetRiskLevel(region.ErosionLevel);
                region.Type = GetRegionType(region.RiskLevel);
                cave.WriteValueAt(address, region);
            }
        }

        return cave;
    }

    private long GetGeologicIndex(Grid<CaveRegion> cave, Coord address, Coord target)
    {
        if (address.Equals(_mouth) || address.Equals(target))
            return 0;

        if (address.Y == 0)
            return address.X * 16807;

        if (address.X == 0)
            return address.Y * 48271;

        var a = cave.ReadValueAt(address.X - 1, address.Y);
        var b = cave.ReadValueAt(address.X, address.Y - 1);

        return a.ErosionLevel * b.ErosionLevel;
    }

    private long GetErosionLevel(long geologicIndex, long depth) => (geologicIndex + depth) % 20183;
    private long GetRiskLevel(long erosionLevel) => erosionLevel % 3;
    private CaveRegionType GetRegionType(long riskLevel) => (CaveRegionType)riskLevel;
    private int ResqueMan(Grid<CaveRegion> cave, Coord target) => StepCountTo(cave, target, _mouth);

    private static (int, Coord) Parse(string input)
    {
        var (depth, targetX, targetY) = Numbers.IntsFromString(input.Replace(LineBreaks.Single, ""));
        return (depth, new Coord(targetX, targetY));
    }

    private static int StepCountTo(Grid<CaveRegion> grid, Coord from, Coord to) => GetCoordCounts(grid, from, to)
        .Where(o => o.X == from.X && o.Y == from.Y)
        .Select(o => o.CountWhenSwitchedToTorch)
        .MinBy(o => o);

    private static IList<CaveCoordCount> GetCoordCounts(Grid<CaveRegion> grid, Coord from, Coord to)
    {
        var seen = new Dictionary<(int x, int y, CaveTool tool), int>();
        var queue = new List<CaveCoordCount>
        {
            new(to.X, to.Y, CaveTool.Torch, 0),
            new(to.X, to.Y, CaveTool.ClimbingGear, 7),
            new(to.X, to.Y, CaveTool.Neither, 7)
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
                    var targetTool = SwitchTool(region, targetRegion, current.Tool);
                    var visited = seen.TryGetValue((next.X, next.Y, targetTool), out var existingCount);
                    var cost = current.Tool == targetTool ? 1 : 8;
                    var totalCount = current.Count + cost;
                    if (visited && totalCount >= existingCount)
                        continue;
                    
                    seen[(next.X, next.Y, targetTool)] = totalCount;
                    queue.Add(new CaveCoordCount(next.X, next.Y, targetTool, totalCount));
                }
            }

            index++;
        }

        return queue;
    }

    private static CaveTool SwitchTool(CaveRegion from, CaveRegion to, CaveTool currentTool) => from.Type switch
    {
        CaveRegionType.Rocky => SwitchToolFromRockyRegion(to, currentTool),
        CaveRegionType.Wet => SwitchToolFromWetRegion(to, currentTool),
        _ => SwitchToolFromNarrowRegion(to, currentTool)
    };

    private static CaveTool SwitchToolFromRockyRegion(CaveRegion to, CaveTool currentTool) => to.Type switch
    {
        CaveRegionType.Wet => CaveTool.ClimbingGear,
        CaveRegionType.Narrow => CaveTool.Torch,
        _ => currentTool
    };

    private static CaveTool SwitchToolFromWetRegion(CaveRegion to, CaveTool currentTool) => to.Type switch
    {
        CaveRegionType.Rocky => CaveTool.ClimbingGear,
        CaveRegionType.Narrow => CaveTool.Neither,
        _ => currentTool
    };

    private static CaveTool SwitchToolFromNarrowRegion(CaveRegion to, CaveTool currentTool) => to.Type switch
    {
        CaveRegionType.Rocky => CaveTool.Torch,
        CaveRegionType.Wet => CaveTool.Neither,
        _ => currentTool
    };

    private record CaveCoordCount(int X, int Y, CaveTool Tool, int Count)
    {
        public int CountWhenSwitchedToTorch => Tool == CaveTool.Torch ? Count : Count + 7;
    }

    private struct CaveRegion
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

    private enum CaveTool
    {
        Torch,
        ClimbingGear,
        Neither
    }

    private enum CaveRegionType
    {
        Rocky = 0,
        Wet = 1,
        Narrow = 2
    }
}