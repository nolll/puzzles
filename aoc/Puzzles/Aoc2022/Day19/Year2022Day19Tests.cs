using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2022.Day19;

public class Year2022Day19Tests
{
    [Test]
    public void Part1_First()
    {
        const string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.";
        var blueprint = RobotFactory.ParseBlueprint(input);
        var best = RobotFactory.FindBestConfiguration(blueprint, 24);
        var result = best.GeodeCount;

        Assert.That(result, Is.EqualTo(9));
    }

    [Test]
    public void Part1_Second()
    {
        const string input = "Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";
        var blueprint = RobotFactory.ParseBlueprint(input);
        var best = RobotFactory.FindBestConfiguration(blueprint, 24);
        var result = best.GeodeCount;

        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void Part1()
    {
        var factory = new RobotFactory();
        var result = factory.Part1(Input);

        Assert.That(result, Is.EqualTo(33));
    }

    [Test]
    public void Part2_First()
    {
        const string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.";
        var blueprint = RobotFactory.ParseBlueprint(input);
        var best = RobotFactory.FindBestConfiguration(blueprint, 32);
        var result = best.GeodeCount;

        Assert.That(result, Is.EqualTo(56));
    }

    [Test]
    public void Part2_Second()
    {
        const string input = "Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";
        var blueprint = RobotFactory.ParseBlueprint(input);
        var best = RobotFactory.FindBestConfiguration(blueprint, 32);
        var result = best.GeodeCount;

        Assert.That(result, Is.EqualTo(62));
    }

    [Test]
    public void Part2()
    {
        var factory = new RobotFactory();
        var result = factory.Part2(Input);

        Assert.That(result, Is.EqualTo(3472));
    }

    private const string Input = """
Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.
""";
}