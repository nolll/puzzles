using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2022.Day19;

public class RobotFactory
{
    public int Part1(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
        var blueprints = lines.Select(ParseBlueprint);
        var qualityLevels = blueprints.Select(GetQualityLevel).ToList();

        return qualityLevels.Sum();
    }

    private int GetQualityLevel(FactoryBlueprint blueprint)
    {
        var best = FindBestConfiguration(blueprint);
        return blueprint.Id * best.GeodeCount;
    }

    private FactoryState FindBestConfiguration(FactoryBlueprint blueprint)
    {
        var queue = new Queue<FactoryState>();
        var seen = new Dictionary<string, FactoryState>();
        var initial = new FactoryState(24, 1, 0, 0, 0, 0, 0, 0, 0);
        var best = initial;
        queue.Enqueue(initial);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (seen.TryGetValue(current.CacheKey, out var seenState) && seenState.Time >= current.Time)
                continue;

            seen[current.CacheKey] = current;

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

            var robotsWereMade = canMakeOreRobot || canMakeClayRobot || canMakeObsidianRobot || canMakeGeodeRobot;
            if (!robotsWereMade)
                queue.Enqueue(state);
        }

        return best;
        //return seen.Values.MaxBy(o => o.GeodeCount);
    }

    private FactoryBlueprint ParseBlueprint(string line)
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