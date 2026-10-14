using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[NeedsRewrite]
[Name("Many-Worlds Interpretation")]
[Comment("Key Collector - Part 2 is too optimized. Tests fails")]
public class Aoc201918 : AocPuzzle
{
    [Puzzle("0a9fd52dc2a8f923fd89261df9e58465")]
    public int Part1(string input) => FindShortestPath(input, false);

    [Puzzle("f8dde84b510c969a3840ba944d60ddac")]
    public int Part2(string input) => FindShortestPath(input, true);

    public int FindShortestPath(string input, bool useFourRobots)
    {
        var totalStepCount = 0;
        var cache = new Dictionary<string, int>();
        var (robots, keys, doors, grid) = Init(input, useFourRobots);
        var paths = MapPaths(keys, grid, doors);

        foreach (var robot in robots)
        {
            var allPaths = GetAllPaths(keys, grid, robot.Address);
            var reachableKeys = allPaths.Select(o => o.Target).ToList();
            var keysFoundByOtherRobots = GetKeysFoundByOtherRobots(keys, reachableKeys);
            var startPaths = GetStartPaths(doors, allPaths, reachableKeys);
            var stepCounts = startPaths.Select(path => FollowPath(cache, paths, keys, path, keysFoundByOtherRobots)).ToList();
            totalStepCount += stepCounts.Count > 0 ? stepCounts.Min() : 0;
        }

        return totalStepCount;
    }

    private static IList<VaultKey> GetKeysFoundByOtherRobots(List<VaultKey> keys, IList<VaultKey> reachableKeys) => 
        keys.Where(key => reachableKeys.All(o => o.Id != key.Id)).ToList();

    private int FindShortestPathFrom(
        Dictionary<string, int> cache,
        Dictionary<(char, char), VaultPath> paths,
        List<VaultKey> keys,
        VaultKey currentKey,
        IList<VaultKey> collectedKeys)
    {
        var pathsToFollow = new List<VaultPath>();
        var remainingKeys = GetRemainingKeys(keys, collectedKeys);
        var isAllPathsOpen = true;
        foreach (var key in remainingKeys)
        {
            if (key.Id != currentKey.Id)
            {
                var path = paths[(currentKey.Id, key.Id)];
                if (path.IsOpen(collectedKeys))
                {
                    pathsToFollow.Add(path);
                }
                else
                {
                    isAllPathsOpen = false;
                }
            }
        }

        if (isAllPathsOpen)
        {
            pathsToFollow = pathsToFollow.OrderBy(o => o.StepCount).Take(1).ToList();
        }

        var stepCounts = pathsToFollow.Select(path => FollowPath(cache, paths, keys, path, collectedKeys)).ToList();

        return stepCounts.Count != 0 ? stepCounts.Min() : 0;
    }

    private static IEnumerable<VaultKey> GetRemainingKeys(List<VaultKey> keys, IList<VaultKey> collectedKeys) => 
        keys.Where(key => collectedKeys.All(o => o.Id != key.Id));

    private int FollowPath(
        Dictionary<string, int> cache,
        Dictionary<(char, char), VaultPath> paths,
        List<VaultKey> keys,
        VaultPath path,
        IList<VaultKey> collectedKeys)
    {
        var stepCount = path.StepCount;
        var newCollectedKeys = new List<VaultKey> { path.Target };
        newCollectedKeys.AddRange(collectedKeys);
        if (newCollectedKeys.Count < keys.Count)
        {
            var cacheKey = GetCacheKey(path.Target.Id, collectedKeys);
            if (!cache.TryGetValue(cacheKey, out var cachedStepCount))
            {
                cachedStepCount = FindShortestPathFrom(cache, paths, keys, path.Target, newCollectedKeys);
                cache.Add(cacheKey, cachedStepCount);
            }

            stepCount += cachedStepCount;
        }

        return stepCount;
    }

    private static string GetCacheKey(char key, IList<VaultKey> collectedKeys) => $"{key}.{JoinKeys(collectedKeys)}";
    private static string JoinKeys(IList<VaultKey> collectedKeys) => string.Join('-', collectedKeys.OrderBy(o => o.Id).Select(o => o.Id));

    private (List<VaultRobot> robots, List<VaultKey> keys, List<VaultDoor> doors, Grid<char> grid) Init(string input, bool useFourRobots)
    {
        var rows = input.Trim().Split(LineBreaks.Single);
        var width = rows.First().Length;
        var height = rows.Length;
        var keys = new List<VaultKey>();
        var doors = new List<VaultDoor>();
        var grid = new Grid<char>(width, height);
        var robots = new List<VaultRobot>();
        var y = grid.YMin;
        var robotLocation = grid.StartCoord;
        foreach (var row in rows)
        {
            var x = grid.XMin;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                var address = new Coord(x, y);
                var charToWrite = c;

                if (char.IsLower(c))
                {
                    charToWrite = '.';
                    keys.Add(new VaultKey(c, address));
                }
                else if (char.IsUpper(c))
                {
                    charToWrite = '.';
                    doors.Add(new VaultDoor(c, address));
                }
                else if (c == '@')
                {
                    robotLocation = address;
                    charToWrite = '@';
                }

                grid.WriteValueAt(address, charToWrite);

                x += 1;
            }

            y += 1;
        }

        if (useFourRobots)
        {
            grid.WriteValueAt(robotLocation.X, robotLocation.Y - 1, '#');
            grid.WriteValueAt(robotLocation.X - 1, robotLocation.Y, '#');
            grid.WriteValueAt(robotLocation, '#');
            grid.WriteValueAt(robotLocation.X + 1, robotLocation.Y, '#');
            grid.WriteValueAt(robotLocation.X, robotLocation.Y + 1, '#');

            var robot1Location = new Coord(robotLocation.X - 1, robotLocation.Y - 1);
            grid.WriteValueAt(robot1Location, '.');
            var robot1 = new VaultRobot(robot1Location);
            robots.Add(robot1);

            var robot2Location = new Coord(robotLocation.X + 1, robotLocation.Y - 1);
            grid.WriteValueAt(robot2Location, '.');
            var robot2 = new VaultRobot(robot2Location);
            robots.Add(robot2);

            var robot3Location = new Coord(robotLocation.X - 1, robotLocation.Y + 1);
            grid.WriteValueAt(robot3Location, '.');
            var robot3 = new VaultRobot(robot3Location);
            robots.Add(robot3);

            var robot4Location = new Coord(robotLocation.X + 1, robotLocation.Y + 1);
            grid.WriteValueAt(robot4Location, '.');
            var robot4 = new VaultRobot(robot4Location);
            robots.Add(robot4);
        }
        else
        {
            var robot = new VaultRobot(robotLocation);
            grid.WriteValueAt(robotLocation, '.');
            robots.Add(robot);
        }

        return (robots, keys, doors, grid);
    }

    private IList<VaultPath> GetStartPaths(List<VaultDoor> doors, IList<VaultPath> allPaths, List<VaultKey> reachableKeys)
    {
        var paths = new List<VaultPath>();

        foreach (var path in allPaths)
        {
            var blockingDoors = FilterDoors(FindBlockingDoors(doors, path.Coords), reachableKeys);
            if (!blockingDoors.Any())
                paths.Add(path);
        }

        return paths;
    }

    private IList<VaultDoor> FilterDoors(IEnumerable<VaultDoor> blockingDoors, IList<VaultKey> reachableKeys) => 
        blockingDoors.Where(door => reachableKeys.Any(o => o.Id == char.ToLower(door.Id))).ToList();

    private IList<VaultPath> GetAllPaths(List<VaultKey> keys, Grid<char> grid, Coord startAddress)
    {
        var paths = new List<VaultPath>();

        foreach (var key in keys)
        {
            var coords = PathFinder.ShortestPathTo(grid, startAddress, key.Address).ToList();
            if (coords.Count > 0)
                paths.Add(new VaultPath(key, coords, new List<char>()));
        }

        return paths;
    }

    private Dictionary<(char, char), VaultPath> MapPaths(List<VaultKey> keys, Grid<char> grid, List<VaultDoor> doors)
    {
        var paths = new Dictionary<(char, char), VaultPath>();
        foreach (var key in keys)
        {
            var otherKeys = keys.Where(o => o.Id != key.Id);
            foreach (var otherKey in otherKeys)
            {
                var coords = PathFinder.ShortestPathTo(grid, key.Address, otherKey.Address).ToList();
                var blockingDoors = FindBlockingDoors(doors, coords);
                var keysNeeded = blockingDoors.Select(o => char.ToLower(o.Id)).ToList();
                var path = new VaultPath(otherKey, coords, keysNeeded);
                paths.Add((key.Id, otherKey.Id), path);
            }
        }

        return paths;
    }

    private IEnumerable<VaultDoor> FindBlockingDoors(List<VaultDoor> doors, IEnumerable<Coord> coords) => 
        coords.SelectMany(coord => doors.Where(door => door.Address.Equals(coord)));

    public record VaultDoor(char Id, Coord Address);
    public record VaultKey(char Id, Coord Address);

    public class VaultPath(VaultKey target, IList<Coord> coords, IList<char> keysNeeded)
    {
        public int StepCount { get; } = coords.Count;
        public VaultKey Target { get; } = target;
        public IList<Coord> Coords { get; } = coords;
        public bool IsOpen(IList<VaultKey> collectedKeys) => keysNeeded.All(key => collectedKeys.Any(o => o.Id == key));
    }

    public record VaultRobot(Coord Address);
}