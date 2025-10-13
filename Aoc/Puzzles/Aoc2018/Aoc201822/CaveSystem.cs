using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201822;

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
        return (CaveRegionType) riskLevel;
    }

    public int ResqueMan()
    {
        return CavePathFinder.StepCountTo(_cave, _target, _mouth);
    }
}