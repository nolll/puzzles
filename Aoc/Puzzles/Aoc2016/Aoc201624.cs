using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Air Duct Spelunking")]
public class Aoc201624 : AocPuzzle
{
    [Puzzle("573c0267baa35fb5a2a80250ac4d8775")]
    public int Part1(string input) => Solve(input, false);

    [Puzzle("5d497a617fb2aecf0d9e02ee07665b4e")]
    public int Part2(string input) => Solve(input, true);

    public int Solve(string input, bool goBackToStartWhenDone)
    {
        var (locations, grid, robot) = Init(input);
        var paths = MapPaths(grid, locations, robot);
        return FindShortestPath(grid, locations, paths, robot, [], goBackToStartWhenDone);
    }

    private int FindShortestPath(
        Grid<char> grid,
        List<AirDuctLocation> locations,
        Dictionary<(char, char), AirDuctPath> paths,
        AirDuctRobot robot,
        Dictionary<string, int> cache,
        bool goBackToStartWhenDone)
    {
        var allPaths = GetAllPaths(grid, locations, robot.Address);
        var startPaths = GetStartPaths(allPaths);
        var stepCounts = startPaths.Select(path => FollowPath(locations, paths, path, [], cache, goBackToStartWhenDone)).ToList();

        return stepCounts.Count > 0 ? stepCounts.Min() : 0;
    }

    private int FindShortestPathFrom(
        List<AirDuctLocation> locations,
        Dictionary<(char, char), AirDuctPath> paths,
        AirDuctLocation currentLocation,
        IList<AirDuctLocation> visitedLocations,
        Dictionary<string, int> cache,
        bool goBackToStartWhenDone)
    {
        var remainingLocations = locations.Where(location => visitedLocations.All(o => o.Id != location.Id));
        var stepCounts = remainingLocations.Where(o => o.Id != currentLocation.Id)
            .Select(o => paths[(currentLocation.Id, o.Id)])
            .Select(path => FollowPath(locations, paths, path, visitedLocations, cache, goBackToStartWhenDone)).ToList();

        return stepCounts.Count > 0 ? stepCounts.Min() : 0;
    }

    private int FollowPath(
        List<AirDuctLocation> locations,
        Dictionary<(char, char), AirDuctPath> paths,
        AirDuctPath path,
        IList<AirDuctLocation> visitedLocations,
        Dictionary<string, int> cache,
        bool goBackToStartWhenDone)
    {
        var stepCount = path.StepCount;
        var newVisitedLocations = visitedLocations.Select(o => o).ToList();
        newVisitedLocations.Add(path.Target);

        if (newVisitedLocations.Count < locations.Count)
        {
            var cacheKey = GetCacheKey(path.Target.Id, visitedLocations);
            if (!cache.TryGetValue(cacheKey, out var cachedStepCount))
            {
                cachedStepCount = FindShortestPathFrom(locations, paths, path.Target, newVisitedLocations, cache, goBackToStartWhenDone);
                cache.Add(cacheKey, cachedStepCount);
            }

            stepCount += cachedStepCount;
        }
        else if (goBackToStartWhenDone)
        {
            var stepCountBackToStart = paths[(path.Target.Id, '0')].StepCount;
            stepCount += stepCountBackToStart;
        }

        return stepCount;
    }

    private static string GetCacheKey(char key, IList<AirDuctLocation> visitedLocations)
    {
        var joinedKeys = string.Join('-', visitedLocations.OrderBy(o => o.Id).Select(o => o.Id));
        return $"{key}.{joinedKeys}";
    }

    private (List<AirDuctLocation>, Grid<char>, AirDuctRobot) Init(string input)
    {
        var robot = new AirDuctRobot(new(0, 0));
        List<AirDuctLocation> locations = [];
        var grid = new Grid<char>();
        var rows = input.Split(LineBreaks.Single);
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                var address = new Coord(x, y);
                grid.MoveTo(address);
                var charToWrite = c;

                if (char.IsNumber(c))
                {
                    charToWrite = '.';
                    if (c == '0')
                        robot = new AirDuctRobot(address);
                    else
                        locations.Add(new AirDuctLocation(c, address));
                }

                grid.WriteValue(charToWrite);

                x += 1;
            }

            y += 1;
        }

        return (locations, grid, robot);
    }

    private static IList<AirDuctPath> GetStartPaths(IList<AirDuctPath> allPaths) => allPaths.ToList();

    private IList<AirDuctPath> GetAllPaths(Grid<char> grid, List<AirDuctLocation> locations, Coord startAddress)
    {
        var paths = new List<AirDuctPath>();

        foreach (var location in locations)
        {
            var coords = PathFinder.ShortestPathTo(grid, startAddress, location.Address).ToList();
            if (coords.Count > 0)
                paths.Add(new AirDuctPath(location, coords.Count));
        }

        return paths;
    }

    private Dictionary<(char, char), AirDuctPath> MapPaths(
        Grid<char> grid,
        List<AirDuctLocation> locations,
        AirDuctRobot robot)
    {
        var paths = new Dictionary<(char, char), AirDuctPath>();
        var homeLocation = new AirDuctLocation('0', robot.Address);
        var locationIncludingHomeLocation = locations.Select(o => o).ToList();
        locationIncludingHomeLocation.Add(homeLocation);
        foreach (var location in locationIncludingHomeLocation)
        {
            var otherKeys = locationIncludingHomeLocation.Where(o => o.Id != location.Id);
            foreach (var otherLocation in otherKeys)
            {
                if (paths.ContainsKey((location.Id, otherLocation.Id)) || paths.ContainsKey((otherLocation.Id, location.Id)))
                    continue;

                var stepCountToLocation = PathFinder.ShortestPathTo(grid, location.Address, otherLocation.Address).Count();
                var pathToLocation = new AirDuctPath(otherLocation, stepCountToLocation);
                var pathBack = new AirDuctPath(location, stepCountToLocation);
                paths.Add((location.Id, otherLocation.Id), pathToLocation);
                paths.Add((otherLocation.Id, location.Id), pathBack);
            }
        }

        return paths;
    }

    public record AirDuctLocation(char Id, Coord Address);
    public record AirDuctRobot(Coord Address);
    public record AirDuctPath(AirDuctLocation Target, int StepCount);
}