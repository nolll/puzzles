namespace Core.Puzzles.Year2022.Day19;

public record FactoryState(
    int Time, 
    int OreRobotCount, 
    int ClayRobotCount, 
    int ObsidianRobotCount,
    int GeodeRobotCount, 
    int OreCount,
    int ClayCount, 
    int ObsidianCount,
    int GeodeCount)
{
    public string CacheKey => $"{OreRobotCount},{ClayRobotCount},{ObsidianRobotCount},{GeodeRobotCount},{OreCount},{ClayCount},{ObsidianCount},{GeodeCount}";
}