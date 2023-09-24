using System.Collections.Generic;
using System.Linq;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2022.Aoc202219;

public class RobotFactory
{
    public int Part1(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
        var blueprints = lines.Select(ParseBlueprint);
        var qualityLevels = blueprints.Select(GetQualityLevel);

        return qualityLevels.Sum();
    }

    public int Part2(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false).Take(3);
        var blueprints = lines.Select(ParseBlueprint);
        var qualityLevels = blueprints.Select(o => FindBestConfiguration(o, 32).GeodeCount);

        return qualityLevels.Aggregate(1, (x, y) => x * y);
    }

    private static int GetQualityLevel(FactoryBlueprint blueprint)
    {
        var best = FindBestConfiguration(blueprint, 24);
        return blueprint.Id * best.GeodeCount;
    }

    public static FactoryState FindBestConfiguration(FactoryBlueprint blueprint, int time)
    {
        var queue = new Queue<FactoryState>();
        var seen = new HashSet<(int, int, int, int, int, int, int, int, int)>();
        var initial = new FactoryState(time, 1, 0, 0, 0, 0, 0, 0, 0);
        var best = initial;

        var maxOreCost = new List<int>
        {
            blueprint.OreRobotBlueprint.Ore,
            blueprint.ClayRobotBlueprint.Ore,
            blueprint.ObsidianRobotBlueprint.Ore,
            blueprint.GeodeRobotBlueprint.Ore
        }.Max();

        var maxClayCost = new List<int>
        {
            blueprint.OreRobotBlueprint.Clay,
            blueprint.ClayRobotBlueprint.Clay,
            blueprint.ObsidianRobotBlueprint.Clay,
            blueprint.GeodeRobotBlueprint.Clay
        }.Max();

        var maxObsidianCost = new List<int>
        {
            blueprint.OreRobotBlueprint.Obsidian,
            blueprint.ClayRobotBlueprint.Obsidian,
            blueprint.ObsidianRobotBlueprint.Obsidian,
            blueprint.GeodeRobotBlueprint.Obsidian
        }.Max();

        queue.Enqueue(initial);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            current = OptimizeState(current, maxOreCost, maxClayCost, maxObsidianCost);

            if (seen.Contains(current.CacheKey2))
                continue;

            seen.Add(current.CacheKey2);

            if (current.Time == 0)
            {
                if (current.GeodeCount > best.GeodeCount)
                    best = current;
                continue;
            }

            var canMakeGeodeRobot = blueprint.CanBuildGeodeRobot(current.OreCount, current.ObsidianCount);
            var canMakeObsidianRobot = blueprint.CanBuildObsidianRobot(current.OreCount, current.ClayCount);
            var canMakeClayRobot = blueprint.CanBuildClayRobot(current.OreCount);
            var canMakeOreRobot = blueprint.CanBuildOreRobot(current.OreCount);

            var state = current with
            {
                Time = current.Time - 1,
                OreCount = current.OreCount + current.OreRobotCount,
                ClayCount = current.ClayCount + current.ClayRobotCount,
                ObsidianCount = current.ObsidianCount + current.ObsidianRobotCount,
                GeodeCount = current.GeodeCount + current.GeodeRobotCount
            };
            
            if (canMakeGeodeRobot)
            {
                var newState = state with
                {
                    GeodeRobotCount = state.GeodeRobotCount + 1,
                    OreCount = state.OreCount - blueprint.GeodeRobotBlueprint.Ore,
                    ObsidianCount = state.ObsidianCount - blueprint.GeodeRobotBlueprint.Obsidian
                };
                queue.Enqueue(newState);
                continue;
            }

            if (canMakeObsidianRobot)
            {
                var newState = state with
                {
                    ObsidianRobotCount = state.ObsidianRobotCount + 1,
                    OreCount = state.OreCount - blueprint.ObsidianRobotBlueprint.Ore,
                    ClayCount = state.ClayCount - blueprint.ObsidianRobotBlueprint.Clay
                };
                queue.Enqueue(newState);
            }

            if (canMakeClayRobot)
            {
                var newState = state with
                {
                    ClayRobotCount = state.ClayRobotCount + 1,
                    OreCount = state.OreCount - blueprint.ClayRobotBlueprint.Ore
                };
                queue.Enqueue(newState);
            }

            if (canMakeOreRobot)
            {
                var newState = state with
                {
                    OreRobotCount = state.OreRobotCount + 1,
                    OreCount = state.OreCount - blueprint.OreRobotBlueprint.Ore
                };
                queue.Enqueue(newState);
            }

            queue.Enqueue(state);
        }

        return best;
    }

    private static FactoryState OptimizeState(FactoryState state, int maxOreCost, int maxClayCost, int maxObsidianCost)
    {
        var timeLeft = state.Time - 1;
        var oreThatCanBeSpent = state.Time * maxOreCost - state.OreRobotCount * timeLeft;
        var clayThatCanBeSpent = state.Time * maxClayCost - state.ClayRobotCount * timeLeft;
        var obsidianThatCanBeSpent = state.Time * maxObsidianCost - state.ObsidianRobotCount * timeLeft;

        return state with
        {
            OreRobotCount = state.OreRobotCount > maxOreCost ? maxOreCost : state.OreRobotCount,
            ClayRobotCount = state.ClayRobotCount > maxClayCost ? maxClayCost : state.ClayRobotCount,
            ObsidianRobotCount = state.ObsidianRobotCount > maxObsidianCost ? maxObsidianCost : state.ObsidianRobotCount,
            OreCount = state.OreCount > oreThatCanBeSpent ? oreThatCanBeSpent : state.OreCount,
            ClayCount = state.ClayCount > clayThatCanBeSpent ? clayThatCanBeSpent : state.ClayCount,
            ObsidianCount = state.ObsidianCount > obsidianThatCanBeSpent ? obsidianThatCanBeSpent : state.ObsidianCount
        };
    }

    public static FactoryBlueprint ParseBlueprint(string line)
    {
        var parts = line.Split(": ");

        var id = int.Parse(parts[0].Split(' ')[1]);
        var robotParts = parts[1].Split('.').ToArray();
        var oreParts = robotParts[0].Split(' ');
        var oreRobot = new RobotBlueprint("ore", int.Parse(oreParts[4]), 0, 0);
        var clayParts = robotParts[1].Trim().Split(' ');
        var clayRobot = new RobotBlueprint("clay", int.Parse(clayParts[4]), 0, 0);
        var obsidianParts = robotParts[2].Trim().Split(' ');
        var obsidianRobot = new RobotBlueprint("obsidian", int.Parse(obsidianParts[4]), int.Parse(obsidianParts[7]), 0);
        var geodeParts = robotParts[3].Trim().Split(' ');
        var geodeRobot = new RobotBlueprint("geode", int.Parse(geodeParts[4]), 0, int.Parse(geodeParts[7]));

        return new FactoryBlueprint(id, oreRobot, clayRobot, obsidianRobot, geodeRobot);
    }
}