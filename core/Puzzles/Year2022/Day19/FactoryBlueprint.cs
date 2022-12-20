namespace Core.Puzzles.Year2022.Day19;

public record FactoryBlueprint(
    int Id, 
    RobotBluePrint OreRobotBluePrint, 
    RobotBluePrint ClayRobotBluePrint,
    RobotBluePrint ObsidianRobotBluePrint, 
    RobotBluePrint GeodeRobotBluePrint)
{
    public bool CanBuildOreRobot(int oreCount)
    {
        return oreCount > OreRobotBluePrint.Ore;
    }

    public bool CanBuildClayRobot(int oreCount)
    {
        return oreCount > ClayRobotBluePrint.Ore;
    }

    public bool CanBuildObsidianRobot(int oreCount, int clayCount)
    {
        return oreCount > ObsidianRobotBluePrint.Ore && clayCount > ObsidianRobotBluePrint.Clay;
    }

    public bool CanBuildGeodeRobot(int oreCount, int obsidianCount)
    {
        return oreCount > GeodeRobotBluePrint.Ore && obsidianCount > GeodeRobotBluePrint.Obsidian;
    }
}