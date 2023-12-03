namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201822;

public struct CaveRegion
{
    public CaveRegionType Type { get; set; }
    public long GeologicIndex { get; set; }
    public long ErosionLevel { get; set; }
    public long RiskLevel { get; set; }

    public override string ToString()
    {
        if (Type == CaveRegionType.Rocky)
            return ".";
        if (Type == CaveRegionType.Wet)
            return "=";
        return "|";
    }
}