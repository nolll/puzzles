namespace Aoc.Puzzles.Year2022.Day19;

public record FactoryBlueprint(
    int Id, 
    RobotBlueprint OreRobotBlueprint, 
    RobotBlueprint ClayRobotBlueprint,
    RobotBlueprint ObsidianRobotBlueprint, 
    RobotBlueprint GeodeRobotBlueprint)
{
    public bool CanBuildOreRobot(int oreCount)
    {
        return oreCount >= OreRobotBlueprint.Ore;
    }

    public bool CanBuildClayRobot(int oreCount)
    {
        return oreCount >= ClayRobotBlueprint.Ore;
    }

    public bool CanBuildObsidianRobot(int oreCount, int clayCount)
    {
        return oreCount >= ObsidianRobotBlueprint.Ore && clayCount >= ObsidianRobotBlueprint.Clay;
    }

    public bool CanBuildGeodeRobot(int oreCount, int obsidianCount)
    {
        return oreCount >= GeodeRobotBlueprint.Ore && obsidianCount >= GeodeRobotBlueprint.Obsidian;
    }
}