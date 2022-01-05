namespace Core.Puzzles.Year2018.Day22;

public class CaveRegion
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