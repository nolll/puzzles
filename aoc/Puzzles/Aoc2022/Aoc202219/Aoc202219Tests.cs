using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2022.Aoc202219;

public class Aoc202219Tests
{
    [Test]
    public void Part1_First()
    {
        const string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.";
        var blueprint = RobotFactory.ParseBlueprint(input);
        var best = RobotFactory.FindBestConfiguration(blueprint, 24);
        var result = best.GeodeCount;

        result.Should().Be(9);
    }

    [Test]
    public void Part1_Second()
    {
        const string input = "Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";
        var blueprint = RobotFactory.ParseBlueprint(input);
        var best = RobotFactory.FindBestConfiguration(blueprint, 24);
        var result = best.GeodeCount;

        result.Should().Be(12);
    }

    [Test]
    public void Part1()
    {
        var factory = new RobotFactory();
        var result = factory.Part1(Input);

        result.Should().Be(33);
    }

    [Test]
    public void Part2_First()
    {
        const string input = "Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.";
        var blueprint = RobotFactory.ParseBlueprint(input);
        var best = RobotFactory.FindBestConfiguration(blueprint, 32);
        var result = best.GeodeCount;

        result.Should().Be(56);
    }

    [Test]
    public void Part2_Second()
    {
        const string input = "Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";
        var blueprint = RobotFactory.ParseBlueprint(input);
        var best = RobotFactory.FindBestConfiguration(blueprint, 32);
        var result = best.GeodeCount;

        result.Should().Be(62);
    }

    [Test]
    public void Part2()
    {
        var factory = new RobotFactory();
        var result = factory.Part2(Input);

        result.Should().Be(3472);
    }

    private const string Input = """
Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.
""";
}