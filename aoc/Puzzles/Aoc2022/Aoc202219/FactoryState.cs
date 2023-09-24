namespace Aoc.Puzzles.Aoc2022.Aoc202219;

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
    public int RobotCount => OreRobotCount + ClayRobotCount + ObsidianRobotCount + GeodeRobotCount;
    public string CacheKey => $"{OreRobotCount},{ClayRobotCount},{ObsidianRobotCount},{GeodeRobotCount},{OreCount},{ClayCount},{ObsidianCount},{GeodeCount}";
    public (int, int, int, int, int, int, int, int, int) CacheKey2 => (OreRobotCount, ClayRobotCount, ObsidianRobotCount, GeodeRobotCount, OreCount, ClayCount, ObsidianCount, GeodeCount, Time);
}