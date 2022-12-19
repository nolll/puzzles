using System.Linq;
using Core.Common.Strings;
using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day19;

public class FactoryBlueprint
{
    public RobotBluePrint OreRobotBluePrint { get; }
    public RobotBluePrint ClayRobotBluePrint { get; }
    public RobotBluePrint ObsidianRobotBluePrint { get; }
    public RobotBluePrint GeodeRobotBluePrint { get; }

    public int OreRobotCount { get; }
    public int ClayRobotCount { get; }
    public int ObsidianRobotCount { get; }
    public int GeodeRobotCount { get; }

    public int OreCount { get; }
    public int ClayCount { get; }
    public int ObsidianCount { get; }
    public int GeodeCount { get; }

    public FactoryBlueprint(RobotBluePrint oreRobotBluePrint, RobotBluePrint clayRobotBluePrint, RobotBluePrint obsidianRobotBluePrint, RobotBluePrint geodeRobotBluePrint)
    {
        OreRobotBluePrint = oreRobotBluePrint;
        ClayRobotBluePrint = clayRobotBluePrint;
        ObsidianRobotBluePrint = obsidianRobotBluePrint;
        GeodeRobotBluePrint = geodeRobotBluePrint;
    }
}

public class RobotBluePrint
{
    public string Type { get; }
    public int Ore { get; }
    public int Clay { get; }

    public RobotBluePrint(string type, int ore, int clay, int obsidian)
    {
        Type = type;
        Ore = ore;
        Clay = clay;
    }
}

public class RobotFactory
{
    public int Part1(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
        var blueprints = lines.Select(ParseBlueprint);
        return 0;
    }

    private FactoryBlueprint ParseBlueprint(string line)
    {
        var parts = line.Split(": ");

        var id = int.Parse(parts[0].Split(' ')[1]);
        var robotParts = parts[1].Split('.').ToArray();
        var oreParts = robotParts[0].Split(' ');
        var oreRobot = new RobotBluePrint("ore", int.Parse(oreParts[4]), 0, 0);
        var clayParts = robotParts[1].Split(' ');
        var clayRobot = new RobotBluePrint("clay", int.Parse(clayParts[4]), 0, 0);
        var obsidianParts = robotParts[1].Split(' ');
        var obsidianRobot = new RobotBluePrint("obsidian", int.Parse(obsidianParts[4]), int.Parse(obsidianParts[7]), 0);
        var geodeParts = robotParts[1].Split(' ');
        var geodeRobot = new RobotBluePrint("geode", 0, int.Parse(geodeParts[4]), int.Parse(geodeParts[7]));

        return new FactoryBlueprint(oreRobot, clayRobot, obsidianRobot, geodeRobot);
    }
}

public class Year2022Day19Tests
{
    [Test]
    public void Part1()
    {
        var factory = new RobotFactory();
        var result = factory.Part1(Input);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = """
Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.
""";
}