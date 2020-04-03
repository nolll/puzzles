namespace Core.ModeMaze
{
    public class CaveRegion
    {
        public CaveRegionType Type { get; set; }
        public long GeologicIndex { get; set; }
        public long ErosionLevel { get; set; }
        public long RiskLevel { get; set; }
    }
}